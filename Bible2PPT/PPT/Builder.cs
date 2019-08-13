using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Bible2PPT.Bibles;
using Bible2PPT.Data;
using Microsoft;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    class Builder : JobManager
    {
        private static PowerPoint.Application POWERPNT;

        public Builder()
        {
            if (POWERPNT == null)
            {
                POWERPNT = new PowerPoint.Application();
                try
                {
                    POWERPNT.Visible = MsoTriState.msoFalse;
                }
                catch { }
            }
        }

        private static async Task<IEnumerable<IEnumerable<Book>>> GetEachBooksAsync(IEnumerable<Bible> bibles, CancellationToken token)
        {
        RETRY:
            try
            {
                return await TaskEx.WhenAll(bibles
                    .Select(bible => bible.Source.GetBooksAsync(bible))
                    .ToList());
            }
            // 취소할 때까지 계속 재시도
            catch (OperationCanceledException) when (!token.IsCancellationRequested)
            {
                await TaskEx.Delay(3000);
                goto RETRY;
            }
        }

        private static async Task<IEnumerable<IEnumerable<Chapter>>> GetEachChaptersAsync(IEnumerable<Book> books, CancellationToken token)
        {
        RETRY:
            try
            {
                // 해당 책이 없는 성경도 있으므로 주의해서 장 정보 가져오기
                return await TaskEx.WhenAll(books
                    .Select(book =>
                        book?.Source.GetChaptersAsync(book)
                        ?? TaskEx.FromResult(new List<Chapter>()))
                    .ToList());
            }
            // 취소할 때까지 계속 재시도
            catch (OperationCanceledException) when (!token.IsCancellationRequested)
            {
                await TaskEx.Delay(3000);
                goto RETRY;
            }
        }

        private static IEnumerable<IEnumerable<Chapter>> Inverse(IEnumerable<IEnumerable<Chapter>> eachTargetChapters)
        {
            // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
            // GetEnumerator() 반환형이 struct라 값 복사로 무한 반복되기를 예방하기 위해 캐스팅
            var targetChapterEnumerators = eachTargetChapters.Select(i => (IEnumerator<Chapter>)i.GetEnumerator()).ToList();

            var startChapterNumber = eachTargetChapters.Where(i => i.Any()).Min(i => i.First().Number);
            for (var chapterNumber = startChapterNumber; ;)
            {
                // 다음 장이 있는지 확인
                var moved = new Dictionary<IEnumerator<Chapter>, bool>();
                var nextChapterNumber = chapterNumber;
                foreach (var i in targetChapterEnumerators)
                {
                    if (i.MoveNext())
                    {
                        moved[i] = true;
                        nextChapterNumber = Math.Max(nextChapterNumber, i.Current.Number);
                    }
                }

                // 현재 장이 마지막이었으면 종료
                if (!moved.Any())
                {
                    break;
                }

                for (; chapterNumber <= nextChapterNumber; chapterNumber++)
                {
                    var eachChapter = new List<Chapter>();
                    foreach (var i in targetChapterEnumerators)
                    {
                        // 범위를 넘어가면 더 페이지가 없음
                        if (i.Current == null)
                        {
                            eachChapter.Add(null);
                            continue;
                        }

                        // 장 번호가 앞서가면 앞 장이 비었음
                        if (i.Current.Number > chapterNumber)
                        {
                            eachChapter.Add(null);
                            continue;
                        }

                        if (!moved[i])
                        {
                            i.MoveNext();
                        }
                        eachChapter.Add(i.Current);
                        moved[i] = false;
                    }
                    yield return eachChapter;
                }
            }
        }

        private static async Task<IEnumerable<IEnumerable<Verse>>> GetEachVersesAsync(IEnumerable<Chapter> chapters, CancellationToken token)
        {
        RETRY:
            try
            {
                return await TaskEx.WhenAll(chapters
                    .Select(chapter =>
                        chapter?.Source.GetVersesAsync(chapter)
                        ?? TaskEx.FromResult(new List<Verse>()))
                    .ToList());
            }
            // 취소할 때까지 계속 재시도
            catch (OperationCanceledException) when (!token.IsCancellationRequested)
            {
                await TaskEx.Delay(3000);
                goto RETRY;
            }
        }

        private static IEnumerable<IEnumerable<Verse>> Inverse(IEnumerable<IEnumerable<Verse>> eachTargetVerses)
        {
            // GetEnumerator() 반환형이 struct라 값 복사로 무한 반복되기를 예방하기 위해 캐스팅
            var targetVerseEnumerators = eachTargetVerses.Select(i => (IEnumerator<Verse>)i.GetEnumerator()).ToList();

            var startVerseNumber = eachTargetVerses.Where(i => i.Any()).Min(i => i.First().Number);
            for (var verseNumber = startVerseNumber; ;)
            {
                // 다음 절이 있는지 확인
                var moved = new Dictionary<IEnumerator<Verse>, bool>();
                var nextVerseNumber = verseNumber;
                foreach (var i in targetVerseEnumerators)
                {
                    if (i.MoveNext())
                    {
                        moved[i] = true;
                        nextVerseNumber = Math.Max(nextVerseNumber, i.Current.Number);
                    }
                }

                // 현재 절이 마지막이었으면 종료
                if (!moved.Any())
                {
                    break;
                }

                for (; verseNumber <= nextVerseNumber; verseNumber++)
                {
                    var eachVerse = new List<Verse>();
                    foreach (var i in targetVerseEnumerators)
                    {
                        // 범위를 넘어가면 더 페이지가 없음
                        if (i.Current == null)
                        {
                            eachVerse.Add(null);
                            continue;
                        }

                        // 절 번호가 앞서가면 앞 절이 비었음
                        if (i.Current.Number > verseNumber)
                        {
                            eachVerse.Add(null);
                            continue;
                        }

                        if (!moved[i])
                        {
                            i.MoveNext();
                        }
                        eachVerse.Add(i.Current);
                        moved[i] = false;
                    }
                    yield return eachVerse;
                }
            }
        }

        public void OpenTemplate()
        {
            void ExtractTemplate()
            {
                if (File.Exists(AppConfig.TemplatePath))
                {
                    return;
                }

                using (var ms = new MemoryStream(Properties.Resources.Template))
                using (var fs = File.OpenWrite(AppConfig.TemplatePath))
                {
                    ms.CopyTo(fs);
                }
            }
            ExtractTemplate();
            System.Diagnostics.Process.Start(AppConfig.TemplatePath);
        }

        protected override async Task ProcessAsync(Job job, CancellationToken token)
        {
            await base.ProcessAsync(job, token);

            // (targetEachVerses, mainBook, mainChapter)
            var queue = new ConcurrentQueue<Tuple<IEnumerable<IEnumerable<Verse>>, Book, Chapter>>();
            var sync = new AutoResetEvent(false);

            var queries = job.QueryString.Split().Select(VerseQuery.Parse).ToList();
            var e = new JobProgressEventArgs(job, null, 0, queries.Count, 0, 0);
            OnJobProgress(e);

            var produce = TaskEx.Run(async () =>
            {
                var eachBooks = await GetEachBooksAsync(job.Bibles, token);

                foreach (var query in queries)
                {
                    var targetEachBook = eachBooks.Select(books => books.FirstOrDefault(book => book.Abbreviation == query.BookAbbreviation)).ToList();

                    // 해당 책이 있는 성경에서 해당 책을 대표로 사용
                    var mainBook = targetEachBook.FirstOrDefault(i => i != null);
                    if (mainBook == null)
                    {
                        goto PROGRESS_QUERY;
                    }

                    var eachTargetChapters = (await GetEachChaptersAsync(targetEachBook, token))
                        .Select(chapters => chapters
                            .Where(chapter =>
                                (query.EndChapterNumber == null)
                                ? (chapter.Number >= query.StartChapterNumber)
                                : (chapter.Number >= query.StartChapterNumber) && (chapter.Number <= query.EndChapterNumber))
                            .ToList())
                        .ToList();

                    // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
                    var targetEachChapters = Inverse(eachTargetChapters);
                    e = new JobProgressEventArgs(job, e.CurrentChapter, e.QueriesDone, e.Queries, e.ChaptersDone, e.Chapters + targetEachChapters.Count());
                    foreach (var targetEachChapter in targetEachChapters)
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

                        var eachTargetVerses = (await GetEachVersesAsync(targetEachChapter, token))
                            .Select(verses => verses
                                .Where(verse =>
                                    (endVerseNumber == null)
                                    ? (verse.Number >= startVerseNumber)
                                    : (verse.Number >= startVerseNumber) && (verse.Number <= endVerseNumber))
                                .ToList())
                            .ToList();

                        var targetEachVerses = Inverse(eachTargetVerses);
                        queue.Enqueue(Tuple.Create(targetEachVerses, mainBook, mainChapter));
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
                        var output = Path.Combine(job.OutputDestination, mainBook.Name, mainChapter.Number.ToString(@"000\.pptx"));
                        CreateDirectoryIfNotExists(Path.GetDirectoryName(output));
                        using (var ppt = new PPTManager(POWERPNT, job, output))
                        {
                            ppt.AppendChapter(targetEachVerses, mainBook, mainChapter, token);
                            ppt.Save();
                        }
                        OnJobProgress(new JobProgressEventArgs(job, null, e.QueriesDone, e.Queries, ++chaptersDone, e.Chapters));
                    }
                }
            }
            else
            {
                using (var ppt = new PPTManager(POWERPNT, job, job.OutputDestination))
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
                            ppt.AppendChapter(targetEachVerses, mainBook, mainChapter, token);
                            OnJobProgress(new JobProgressEventArgs(job, null, e.QueriesDone, e.Queries, ++chaptersDone, e.Chapters));
                        }
                    }
                    ppt.Save();
                }
            }
            await produce;
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    try
                    {
                        if (POWERPNT != null && POWERPNT.Presentations.Count == 0)
                        {
                            POWERPNT.Quit();
                            POWERPNT = null;
                        }
                    }
                    catch { }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
