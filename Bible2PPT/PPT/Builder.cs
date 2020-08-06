using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bible2PPT.Bibles;
using Bible2PPT.Data;
using Bible2PPT.Services;
using Microsoft.Extensions.DependencyInjection;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    class Builder : JobManager
    {
        private HiddenPowerPoint PowerPoint { get; }
        private ZippedBibleService ZippedBibleService { get; }
        private IServiceScopeFactory ScopeFactory { get; }

        public Builder(HiddenPowerPoint ppt, ZippedBibleService bibleService, IServiceScopeFactory scopeFactory)
        {
            PowerPoint = ppt;
            ZippedBibleService = bibleService;
            ScopeFactory = scopeFactory;
        }

        public void OpenTemplate()
        {
            void ExtractTemplate()
            {
                if (File.Exists(AppConfig.TemplatePath))
                {
                    return;
                }

                using var ms = Resources.GetStream(@"Template.pptx");
                using var fs = File.OpenWrite(AppConfig.TemplatePath);
                ms.CopyTo(fs);
            }
            ExtractTemplate();
            Process.Start(new ProcessStartInfo
            {
                FileName = AppConfig.TemplatePath,
                UseShellExecute = true,
            });
        }

        protected override async Task ProcessAsync(Job job, CancellationToken token)
        {
            await base.ProcessAsync(job, token).ConfigureAwait(false);

            // (targetEachVerses, mainBook, mainChapter)
            var queue = new ConcurrentQueue<(IAsyncEnumerable<IEnumerable<Verse>>, Book, Chapter)>();
            using var sync = new AutoResetEvent(false);

            var queries = job.QueryString.Split().Select(VerseQuery.Parse).ToList();
            var e = new JobProgressEventArgs(job, null, 0, queries.Count, 0, 0);
            OnJobProgress(e);

            var produce = Task.Run(async () =>
            {
                var eachBooks = await ZippedBibleService.GetEachBooksAsync(job.Bibles, token).ConfigureAwait(false);

                List<Book> LookupEachBook(VerseQuery query)
                {
                    return eachBooks.Select(
                        books => books.FirstOrDefault(
                            book => book.Abbreviation == query.BookAbbreviation)).ToList();
                }

                foreach (var query in queries)
                {
                    var targetEachBook = LookupEachBook(query);

                    // 해당 책이 있는 성경에서 해당 책을 대표로 사용
                    var mainBook = targetEachBook.FirstOrDefault(i => i != null);
                    if (mainBook == null)
                    {
                        goto PROGRESS_QUERY;
                    }

                    // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
                    var targetEachChapters = ZippedBibleService.GetChaptersAsync(targetEachBook, token)
                        .Where(eachChapter => eachChapter.Any(chapter =>
                            (query.EndChapterNumber == null)
                            ? (chapter.Number >= query.StartChapterNumber)
                            : (chapter.Number >= query.StartChapterNumber) && (chapter.Number <= query.EndChapterNumber)
                        ));
                    e = new JobProgressEventArgs(job, e.CurrentChapter, e.QueriesDone, e.Queries, e.ChaptersDone, e.Chapters + (await targetEachChapters.ToListAsync().ConfigureAwait(false)).Count());
                    await foreach (var targetEachChapter in targetEachChapters)
                    {
                        // 해당 장이 있는 성경의 책에서 해당 장을 대표로 사용
                        var mainChapter = targetEachChapter.FirstOrDefault(i => i != null);
                        if (mainChapter == null)
                        {
                            goto PROGRESS_CHAPTER;
                        }

                        e = new JobProgressEventArgs(job, mainChapter, e.QueriesDone, e.Queries, e.ChaptersDone, e.Chapters);

                        var startVerseNumber = (mainChapter.Number == query.StartChapterNumber) ? query.StartVerseNumber : 1;
                        var endVerseNumber = (mainChapter.Number == query.EndChapterNumber) ? query.EndVerseNumber : null;

                        var targetEachVerses = ZippedBibleService.GetVersesAsync(targetEachChapter, token)
                            .Where(eachVerse => eachVerse.Any(verse =>
                                (endVerseNumber == null)
                                ? (verse.Number >= startVerseNumber)
                                : (verse.Number >= startVerseNumber) && (verse.Number <= endVerseNumber)
                            ));
                        queue.Enqueue((targetEachVerses, mainBook, mainChapter));
                        sync.WaitOne();

                    PROGRESS_CHAPTER:
                        e = new JobProgressEventArgs(job, e.CurrentChapter, e.QueriesDone, e.Queries, e.ChaptersDone + 1, e.Chapters);
                    }

                PROGRESS_QUERY:
                    e = new JobProgressEventArgs(job, e.CurrentChapter, e.QueriesDone + 1, e.Queries, e.ChaptersDone, e.Chapters);
                }
            });

            var chaptersDone = 0;

            if (job.SplitChaptersIntoFiles)
            {
                while (queue.Any()
                    || !(produce.IsCompleted || (produce.Status == TaskStatus.RanToCompletion)))
                {
                    if (queue.TryDequeue(out var item))
                    {
                        sync.Set();
                        var targetEachVerses = item.Item1;
                        var mainBook = item.Item2;
                        var mainChapter = item.Item3;
                        var output = Path.Combine(job.OutputDestination, mainBook.Name, $"{mainChapter.Number:000}.pptx");
                        CreateDirectoryIfNotExists(Path.GetDirectoryName(output));
                        using (var ppt = new PPTManager(PowerPoint.Instance, job, output))
                        {
                            await ppt.AppendChapter(targetEachVerses, mainBook, mainChapter, token).ConfigureAwait(false);
                            ppt.Save();
                        }
                        OnJobProgress(new JobProgressEventArgs(job, null, e.QueriesDone, e.Queries, ++chaptersDone, e.Chapters));
                    }
                }
            }
            else
            {
                using var ppt = new PPTManager(PowerPoint.Instance, job, job.OutputDestination);
                while (queue.Any()
                    || !(produce.IsCompleted || (produce.Status == TaskStatus.RanToCompletion)))
                {
                    if (queue.TryDequeue(out var item))
                    {
                        sync.Set();
                        var targetEachVerses = item.Item1;
                        var mainBook = item.Item2;
                        var mainChapter = item.Item3;
                        await ppt.AppendChapter(targetEachVerses, mainBook, mainChapter, token).ConfigureAwait(false);
                        OnJobProgress(new JobProgressEventArgs(job, null, e.QueriesDone, e.Queries, ++chaptersDone, e.Chapters));
                    }
                }
                ppt.Save();
            }
            await produce.ConfigureAwait(false);
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public new void Queue(Job job)
        {
            using (var scope = ScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<BibleContext>();
                foreach (var i in job.Bibles)
                {
                    db.Bibles.Attach(i);
                }
                db.Jobs.Add(job);
                db.SaveChanges();
            }

            base.Queue(job);
        }
    }
}
