using System.Globalization;

namespace Bible2PPT.Services.BibleIndexService;

public class VerseQueryParser
{
    private readonly BibleIndexService _bibleIndexService;

    public VerseQueryParser(BibleIndexService bibleIndexService)
    {
        _bibleIndexService = bibleIndexService;
    }

    public IEnumerable<VerseQuery> ParseVerseQueries(string queryString)
    {
        var queries = new Queue<VerseQuery>();

        var span = queryString.AsSpan().TrimStart();
        while (!span.IsEmpty)
        {
            // 성경 책 약자 추출
            var abbrSpan = GetToken(span);
            var abbrInfo = MatchBookAbbreviation(abbrSpan);
            if (abbrInfo is null)
            {
                throw new InvalidOperationException($@"No matching abbreviation ""{span}"" found in the bible index.");
            }

            var query = new VerseQuery { BookKey = abbrInfo.Key };
            span = span[abbrInfo.Value.Length..].TrimStart();

            // 구절 범위 추출
            var ranges = new Queue<VerseQueryRange>();
            while (GetToken(span) is var rangeSpan
                && VerseQueryRange.TryParse(rangeSpan.ToString(), CultureInfo.InvariantCulture, out var range))
            {
                ranges.Enqueue(range);
                span = span[rangeSpan.Length..].TrimStart();
            }

            // PPT 범위를 전체로 설정할 때
            // 예) 창        = 창세기 전체
            if (!ranges.Any())
            {
                ranges.Enqueue(new());
            }

            while (ranges.TryDequeue(out var range))
            {
                queries.Enqueue(query with
                {
                    StartChapterNumber = range.StartChapterNumber,
                    StartVerseNumber = range.StartVerseNumber,
                    EndChapterNumber = range.EndChapterNumber,
                    EndVerseNumber = range.EndVerseNumber,
                });
            }
        }

        return queries.ToArray();
    }

    private static ReadOnlySpan<char> GetToken(ReadOnlySpan<char> span)
    {
        var endOfToken = span.IndexOf(' ');
        if (endOfToken == -1)
        {
            return span;
        }

        return span[..endOfToken];
    }

    private BookInfo? MatchBookAbbreviation(ReadOnlySpan<char> span)
    {
        BookInfo? longest = null;
        var abbrLength = 1;
        for (;
            (abbrLength < span.Length && !char.IsWhiteSpace(span[abbrLength]))
            || abbrLength == span.Length;
            abbrLength++)
        {
            var abbr = span[..abbrLength].ToString();

            var info = _bibleIndexService.FindBookInfoExactAbbreviation(abbr);
            if (info is not null)
            {
                longest = info;
            }
        }

        return longest;
    }
}
