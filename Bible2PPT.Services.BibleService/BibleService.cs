using Bible2PPT.Bibles;
using Bible2PPT.Data;
using Bible2PPT.Sources;
using Microsoft.EntityFrameworkCore;

namespace Bible2PPT.Services.BibleService;

public class BibleService
{
    private readonly IDbContextFactory<BibleContext> _dbFactory;
    private readonly BibleIndexService.BibleIndexService _bibleIndexService;

    public BibleService(IDbContextFactory<BibleContext> dbFactory, BibleIndexService.BibleIndexService bibleIndexService)
    {
        _dbFactory = dbFactory;
        _bibleIndexService = bibleIndexService;
    }

    public Bible? FindBible(int id)
    {
        using var db = _dbFactory.CreateDbContext();
        return db.Bibles.Find(id);
    }

    public async ValueTask ClearCachesAsync()
    {
        using var db = _dbFactory.CreateDbContext();
        await db.Database.EnsureDeletedAsync().ConfigureAwait(false);
    }

    private void LinkSource(BibleBase target, BibleSource source)
    {
        target.Source = source;
        target.SourceId = source.Id;
    }

    private void LinkSource(BibleBase target, BibleBase source)
    {
        LinkSource(target, source.Source);
    }

    public async Task<List<Bible>> GetBiblesAsync(BibleSource source)
    {
        // 캐시가 있으면 사용
        var bibles = GetCached();
        if (bibles.Any())
        {
            return bibles;
        }
        // 캐시가 없으면 온라인에서 가져와서 저장
        bibles = await source.GetBiblesOnlineAsync().ConfigureAwait(false);
        bibles.ForEach(bible => LinkSource(bible, source));
        Cache();
        return bibles;

        List<Bible> GetCached()
        {
            using var db = _dbFactory.CreateDbContext();
            return db.Bibles.Where(i => i.SourceId == source.Id).ToList();
        }

        void Cache()
        {
            using var db = _dbFactory.CreateDbContext();
            db.Bibles.AddRange(bibles);
            db.SaveChanges();
        }
    }

    public async Task<List<Book>> GetBooksAsync(Bible bible)
    {
        // 캐시가 있으면 사용
        var books = GetCached();
        if (books.Any())
        {
            books.ForEach(LinkInfo);
            return books;
        }
        // 캐시가 없으면 온라인에서 가져와서 저장
        books = await bible.Source.GetBooksOnlineAsync(bible).ConfigureAwait(false);
        books.ForEach(LinkForeigns);
        Cache();
        books.ForEach(LinkInfo);
        return books;

        List<Book> GetCached()
        {
            using var db = _dbFactory.CreateDbContext();
            return db.Books.Where(i => i.BibleId == bible.Id).ToList();
        }

        void LinkForeigns(Book book)
        {
            LinkSource(book, bible);
            book.Bible = bible;
            book.BibleId = bible.Id;
        }

        void Cache()
        {
            using var db = _dbFactory.CreateDbContext();
            db.Bibles.Attach(bible);
            db.Books.AddRange(books);
            db.SaveChanges();
        }

        void LinkInfo(Book book)
        {
            book.NameInfo = _bibleIndexService.GetBookName(book.Key, bible.LanguageCode);
            book.AbbreviationInfo = _bibleIndexService.GetBookAbbreviation(book.Key, bible.LanguageCode);
        }
    }

    public async Task<List<Chapter>> GetChaptersAsync(Book? book)
    {
        if (book is null)
        {
            return new List<Chapter>();
        }

        // 캐시가 있으면 사용
        var chapters = GetCached();
        if (chapters.Any())
        {
            return chapters;
        }
        // 캐시가 없으면 온라인에서 가져와서 저장
        chapters = await book.Source.GetChaptersOnlineAsync(book).ConfigureAwait(false);
        chapters.ForEach(LinkForeigns);
        chapters.Sort((a, b) => a.Number.CompareTo(b.Number));
        Cache();
        return chapters;

        List<Chapter> GetCached()
        {
            using var db = _dbFactory.CreateDbContext();
            return db.Chapters.Where(i => i.BookId == book.Id).ToList();
        }

        void LinkForeigns(Chapter chapter)
        {
            LinkSource(chapter, book);
            chapter.Book = book;
            chapter.BookId = book.Id;
        }

        void Cache()
        {
            using var db = _dbFactory.CreateDbContext();
            db.Books.Attach(book);
            db.Chapters.AddRange(chapters);
            db.SaveChanges();
        }
    }

    public async Task<List<Verse>> GetVersesAsync(Chapter? chapter)
    {
        if (chapter is null)
        {
            return new List<Verse>();
        }

        // 캐시가 있으면 사용
        var verses = GetCached();
        if (verses.Any())
        {
            return verses;
        }
        // 캐시가 없으면 온라인에서 가져와서 저장
        verses = await chapter.Source.GetVersesOnlineAsync(chapter).ConfigureAwait(false);
        verses.ForEach(LinkForeigns);
        verses.Sort((a, b) => a.Number.CompareTo(b.Number));
        Cache();
        return verses;

        List<Verse> GetCached()
        {
            using var db = _dbFactory.CreateDbContext();
            return db.Verses.Where(i => i.ChapterId == chapter.Id).ToList();
        }

        void LinkForeigns(Verse verse)
        {
            LinkSource(verse, chapter);
            verse.Chapter = chapter;
            verse.ChapterId = chapter.Id;
        }

        void Cache()
        {
            using var db = _dbFactory.CreateDbContext();
            db.Chapters.Attach(chapter);
            db.Verses.AddRange(verses);
            db.SaveChanges();
        }
    }
}
