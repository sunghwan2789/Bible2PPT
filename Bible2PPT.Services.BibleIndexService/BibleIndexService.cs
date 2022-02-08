using Microsoft.EntityFrameworkCore;

namespace Bible2PPT.Services.BibleIndexService;

public class BibleIndexService
{
    private readonly IDbContextFactory<BibleIndexContext> _dbFactory;

    public BibleIndexService(IDbContextFactory<BibleIndexContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public BookInfo GetBookInfo(BookKey key, string languageCode)
    {
        using var db = _dbFactory.CreateDbContext();
        return db.BookInfos
            .Where(x => (x.Key == key) && (x.LanguageCode == languageCode))
            .OrderByDescending(x => x.IsPrimary)
            .First();
    }

    public string GetBookName(BookKey key, string languageCode)
    {
        using var db = _dbFactory.CreateDbContext();

        return GetBookInfoCandidates(db, key, languageCode)
            .Where(x => x.Kind == BookInfoKind.Name)
            .OrderByDescending(x => x.IsPrimary)
            .First()
            .Value;
    }

    public string GetBookAbbreviation(BookKey key, string languageCode)
    {
        using var db = _dbFactory.CreateDbContext();

        return GetBookInfoCandidates(db, key, languageCode)
            .Where(x => x.Kind == BookInfoKind.Abbreviation)
            .OrderByDescending(x => x.IsPrimary)
            .First()
            .Value;
    }

    public void AddBookInfos(IEnumerable<BookInfo> bookInfos)
    {
        using var db = _dbFactory.CreateDbContext();
        db.BookInfos.AddRange(bookInfos);
    }

    public BookInfo? FindBookInfoExactAbbreviation(string abbr)
    {
        using var db = _dbFactory.CreateDbContext();

        var infos = db.BookInfos.Where(x => x.Kind == BookInfoKind.Abbreviation && x.Value == abbr);
        if (infos.Select(x => x.Key).Distinct().Count() != 1)
        {
            return null;
        }

        return infos.First();
    }

    private static IQueryable<BookInfo> GetBookInfoCandidates(BibleIndexContext db, BookKey key, string languageCode)
    {
        var bookInfo = db.BookInfos.Where(x => x.Key == key);

        var languageMatches = bookInfo.Where(x => x.LanguageCode == languageCode);
        if (!languageMatches.Any())
        {
            return bookInfo;
        }

        return languageMatches;
    }
}
