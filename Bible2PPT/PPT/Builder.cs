using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bible2PPT.Bibles;
using Microsoft;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    using Element = Tuple<Work, CancellationToken, IProgress<BuildProgress>>;

    class Builder : IDisposable
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

        private readonly ConcurrentQueue<Element> Queue = new ConcurrentQueue<Element>();

        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public void Push(Work work, CancellationToken cancellationToken, IProgress<BuildProgress> progress, IProgress<BuildResult> end)
        {
            Queue.Enqueue(Tuple.Create(work, cancellationToken, progress));
            TaskEx.Run(async () =>
            {
                try
                {
                    semaphore.Wait(cancellationToken);
                    while (Queue.TryDequeue(out var item))
                    {
                        if (item.Item2.IsCancellationRequested)
                        {
                            end.Report(new BuildResult
                            {
                                Work = item.Item1,
                            });
                            continue;
                        }

                        end.Report(await DoWorkAsync(item.Item1, item.Item2, item.Item3));
                        break;
                    }
                }
                catch { }
                finally
                {
                    semaphore.Release();
                }
            });
        }

        private static async Task<IEnumerable<IEnumerable<Book>>> GetEachBooksAsync(IEnumerable<Bible> bibles, CancellationToken cancellationToken)
        {
        RETRY:
            try
            {
                return (await TaskEx.WhenAll(bibles
                    .Select(bible => bible.Source.GetBooksAsync(bible))
                    .ToList()));
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // TODO: UI와 계속 진행 여부 통신
                if (!false)
                {
                    throw;
                }

                goto RETRY;
            }
        }

        private static async Task<IEnumerable<IEnumerable<Chapter>>> GetEachChaptersAsync(IEnumerable<Book> books, CancellationToken cancellationToken)
        {
        RETRY:
            try
            {
                // 해당 책이 없는 성경도 있으므로 주의해서 장 정보 가져오기
                return (await TaskEx.WhenAll(books
                    .Select(book =>
                        book?.Source.GetChaptersAsync(book)
                        ?? TaskEx.FromResult(new List<Chapter>()))
                    .ToList()));
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // TODO: UI와 계속 진행 여부 통신
                if (!false)
                {
                    throw;
                }

                goto RETRY;
            }
        }

        private static IEnumerable<IEnumerable<Chapter>> Inverse(IEnumerable<IEnumerable<Chapter>> eachTargetChapters)
        {
            // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
            var targetEachChapters = new List<IEnumerable<Chapter>>();
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
                    targetEachChapters.Add(eachChapter);
                }
            }

            return targetEachChapters;
        }

        private static async Task<IEnumerable<IEnumerable<Verse>>> GetEachVersesAsync(IEnumerable<Chapter> chapters, CancellationToken cancellationToken)
        {
        RETRY:
            try
            {
                return (await TaskEx.WhenAll(chapters
                    .Select(chapter =>
                        chapter?.Source.GetVersesAsync(chapter)
                        ?? TaskEx.FromResult(new List<Verse>()))
                    .ToList()));
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // TODO: UI와 계속 진행 여부 통신
                if (!false)
                {
                    throw;
                }

                goto RETRY;
            }
        }

        private static IEnumerable<IEnumerable<Verse>> Inverse(IEnumerable<IEnumerable<Verse>> eachTargetVerses)
        {
            var targetEachVerses = new List<IEnumerable<Verse>>();
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
                    targetEachVerses.Add(eachVerse);
                }
            }

            return targetEachVerses;
        }

        private static void ExtractTemplate()
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

        public void OpenTemplate()
        {
            ExtractTemplate();
            Process.Start(AppConfig.TemplatePath);
        }

        private BuildResult Prepare(Work work) => Prepare(work, Path.GetTempFileName() + ".pptx");

        private BuildResult Prepare(Work work, string output)
        {
            ExtractTemplate();
            File.Copy(AppConfig.TemplatePath, output, true);

            var workingPPT = POWERPNT.Presentations.Open(output, WithWindow: MsoTriState.msoFalse);
            return new BuildResult
            {
                Work = work,
                Output = output,
                WorkingPPT = workingPPT,
                TemplateSlide = workingPPT.Slides[1],
            };
        }

        private async Task<BuildResult> DoWorkAsync(Work work, CancellationToken cancellationToken, IProgress<BuildProgress> progress)
        {
            BuildResult result = null;
            try
            {
                if (!work.SplitChaptersIntoFiles)
                {
                    result = Prepare(work);
                }

                var eachBooks = await GetEachBooksAsync(work.Bibles, cancellationToken);

                foreach (var query in work.QueryString.Split().Select(BibleQuery.ParseQuery).ToList())
                {
                    var targetEachBook = eachBooks.Select(books => books.FirstOrDefault(book => book.ShortTitle == query.BibleId)).ToList();

                    // 해당 책이 있는 성경에서 해당 책을 대표로 사용
                    var mainBook = targetEachBook.FirstOrDefault(i => i != null);
                    if (mainBook == null)
                    {
                        continue;
                    }

                    var eachTargetChapters = (await GetEachChaptersAsync(targetEachBook, cancellationToken))
                        .Select(chapters => chapters
                            .Where(chapter =>
                                (query.EndChapterNumber != null)
                                ? (chapter.Number >= query.StartChapterNumber) && (chapter.Number <= query.EndChapterNumber)
                                : (chapter.Number >= query.StartChapterNumber))
                            .ToList())
                        .ToList();

                    // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
                    var targetEachChapters = Inverse(eachTargetChapters);
                    foreach (var targetEachChapter in targetEachChapters)
                    {
                        // 해당 장이 있는 성경의 책에서 해당 장을 대표로 사용
                        var mainChapter = targetEachChapter.FirstOrDefault(i => i != null);
                        if (mainChapter == null)
                        {
                            continue;
                        }

                        // TODO: NO INTERACT 
                        progress.Report(new BuildProgress
                        {
                            Work = work,
                            CurrentChapter = mainChapter,
                        });

                        if (work.SplitChaptersIntoFiles)
                        {
                            result?.Save();
                            var output = Path.Combine(work.OutputDestination, mainBook.Title, mainChapter.Number.ToString("000\\.pptx"));
                            CreateDirectoryIfNotExists(Path.GetDirectoryName(output));
                            result = Prepare(work, output);
                        }

                        var startVerseNumber = (mainChapter.Number == query.StartChapterNumber) ? query.StartVerseNumber : 1;
                        var endVerseNumber = (mainChapter.Number == query.EndChapterNumber) ? query.EndVerseNumber : null;

                        var eachTargetVerses = (await GetEachVersesAsync(targetEachChapter, cancellationToken))
                            .Select(verses => verses
                                .Where(verse =>
                                    (endVerseNumber != null)
                                    ? (verse.Number >= startVerseNumber) && (verse.Number <= endVerseNumber)
                                    : (verse.Number >= startVerseNumber))
                                .ToList())
                            .ToList();

                        var targetEachVerses = Inverse(eachTargetVerses);
                        result.AppendChapter(targetEachVerses, mainBook, mainChapter, cancellationToken);
                    }
                }
            }
            // 올바른 작업 취소 요청 시 오류 무시
            //catch (OperationCanceledException) { }
            // 작업 실패 시 작업 중지
            catch (Exception ex)
            {
                // 작업을 시작하기 전에 오류
                if (result == null)
                {
                    return new BuildResult
                    {
                        Work = work,
                        Exception = ex,
                    };
                }
                // 작업 중에 오류
                else
                {
                    result.Exception = ex;
                    return result;
                }
            }

            // 작업을 시작하지 않음 :: 지금은 도달 불가능
            if (result == null)
            {
                return new BuildResult
                {
                    Work = work,
                };
            }
            // 작업을 성공적으로 끝냄
            else
            {
                result.IsCompleted = true;
                return result;
            }
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

        protected virtual void Dispose(bool disposing)
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
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PPTBuilder() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
