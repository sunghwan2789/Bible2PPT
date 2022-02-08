using System.Runtime.CompilerServices;
using Bible2PPT.Bibles;
using Bible2PPT.Services.BibleIndexService;

namespace Bible2PPT.Services.BibleService;

public class ZippedBibleService
{
    private readonly BibleService _bibleService;

    public ZippedBibleService(BibleService bibleService)
    {
        _bibleService = bibleService;
    }

    public async Task<IEnumerable<Book?>> FindBookAsync(IEnumerable<Bible> bibles, BookKey key, CancellationToken cancellationToken)
    {
        var eachBooks = await GetEachBooksAsync(bibles, cancellationToken).ConfigureAwait(false);

        return eachBooks.Select(x => x.FirstOrDefault(book => book.Key == key)).ToList();
    }

    private async Task<IEnumerable<IEnumerable<Book>>> GetEachBooksAsync(IEnumerable<Bible> bibles, CancellationToken token)
    {
    RETRY:
        try
        {
            return await Task.WhenAll(bibles
                .Select(_bibleService.GetBooksAsync)
                .ToList()).ConfigureAwait(false);
        }
        // 취소할 때까지 계속 재시도
        catch (OperationCanceledException) when (!token.IsCancellationRequested)
        {
            await Task.Delay(3000, token).ConfigureAwait(false);
            goto RETRY;
        }
    }

    private async Task<IEnumerable<IEnumerable<Chapter>>> GetEachChaptersAsync(IEnumerable<Book?> books, CancellationToken token)
    {
    RETRY:
        try
        {
            // 해당 책이 없는 성경도 있으므로 주의해서 장 정보 가져오기
            return await Task.WhenAll(books
                .Select(_bibleService.GetChaptersAsync)
                .ToList()).ConfigureAwait(false);
        }
        // 취소할 때까지 계속 재시도
        catch (OperationCanceledException) when (!token.IsCancellationRequested)
        {
            await Task.Delay(3000, token).ConfigureAwait(false);
            goto RETRY;
        }
    }

    public async IAsyncEnumerable<IEnumerable<Chapter?>> GetChaptersAsync(IEnumerable<Book?> targetEachBook, [EnumeratorCancellation] CancellationToken token)
    {
        var eachTargetChapters = await GetEachChaptersAsync(targetEachBook, token).ConfigureAwait(false);

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
                var eachChapter = new List<Chapter?>();
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

    private async Task<IEnumerable<IEnumerable<Verse>>> GetEachVersesAsync(IEnumerable<Chapter?> chapters, CancellationToken token)
    {
    RETRY:
        try
        {
            return await Task.WhenAll(chapters
                .Select(_bibleService.GetVersesAsync)
                .ToList()).ConfigureAwait(false);
        }
        // 취소할 때까지 계속 재시도
        catch (OperationCanceledException) when (!token.IsCancellationRequested)
        {
            await Task.Delay(3000, token).ConfigureAwait(false);
            goto RETRY;
        }
    }

    public async IAsyncEnumerable<IEnumerable<Verse?>> GetVersesAsync(IEnumerable<Chapter?> targetEachChapter, [EnumeratorCancellation] CancellationToken token)
    {
        var eachTargetVerses = await GetEachVersesAsync(targetEachChapter, token).ConfigureAwait(false);

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
                var eachVerse = new List<Verse?>();
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
}
