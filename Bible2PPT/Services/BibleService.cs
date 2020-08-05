using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using Bible2PPT.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT.Services
{
    class BibleService
    {
        private IServiceScopeFactory ScopeFactory { get; set; }

        public BibleService(IServiceScopeFactory scopeFactory)
        {
            ScopeFactory = scopeFactory;
        }

        private void LinkSource(BibleBase target, Source source)
        {
            if (target == null) new ArgumentNullException(nameof(target));
            if (source == null) new ArgumentNullException(nameof(source));

            target.Source = source;
            target.SourceId = source.Id;
        }

        private void LinkSource(BibleBase target, BibleBase source)
        {
            if (target == null) new ArgumentNullException(nameof(target));
            if (source == null) new ArgumentNullException(nameof(source));

            LinkSource(target, source.Source);
        }

        public async Task<List<Bible>> GetBiblesAsync(Source source)
        {
            if (source == null)
            {
                return new List<Bible>();
            }

            // 캐시가 있으면 사용
            var bibles = GetCached();
            if (bibles.Any())
            {
                return bibles;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            bibles = await source.GetBiblesOnlineAsync();
            bibles.ForEach(bible => LinkSource(bible, source));
            Cache();
            return bibles;

            List<Bible> GetCached()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                return db.Bibles.Where(i => i.SourceId == source.Id).ToList();
            }

            void Cache()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                db.Bibles.AddRange(bibles);
                db.SaveChanges();
            }
        }

        public async Task<List<Book>> GetBooksAsync(Bible bible)
        {
            if (bible == null)
            {
                return new List<Book>();
            }

            // 캐시가 있으면 사용
            var books = GetCached();
            if (books.Any())
            {
                return books;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            books = await bible.Source.GetBooksOnlineAsync(bible);
            books.ForEach(LinkForeigns);
            Cache();
            return books;

            List<Book> GetCached()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                return db.Books.Where(i => i.BibleId == bible.Id)
                    .Include(book => book.Bible)
                    .ToList();
            }

            void LinkForeigns(Book book)
            {
                LinkSource(book, bible);
                book.Bible = bible;
                book.BibleId = bible.Id;
            }

            void Cache()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                db.Bibles.Attach(books.First().Bible);
                db.Books.AddRange(books);
                db.SaveChanges();
            }
        }

        public async Task<List<Chapter>> GetChaptersAsync(Book book)
        {
            if (book == null)
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
            chapters = await book.Source.GetChaptersOnlineAsync(book);
            chapters.ForEach(LinkForeigns);
            chapters.Sort((a, b) => a.Number.CompareTo(b.Number));
            Cache();
            return chapters;

            List<Chapter> GetCached()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                return db.Chapters.Where(i => i.BookId == book.Id)
                    .Include(chapter => chapter.Book.Bible)
                    .ToList();
            }

            void LinkForeigns(Chapter chapter)
            {
                LinkSource(chapter, book);
                chapter.Book = book;
                chapter.BookId = book.Id;
            }

            void Cache()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                db.Books.Attach(chapters.First().Book);
                db.Chapters.AddRange(chapters);
                db.SaveChanges();
            }
        }

        public async Task<List<Verse>> GetVersesAsync(Chapter chapter)
        {
            if (chapter == null)
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
            verses = await chapter.Source.GetVersesOnlineAsync(chapter);
            verses.ForEach(LinkForeigns);
            verses.Sort((a, b) => a.Number.CompareTo(b.Number));
            Cache();
            return verses;

            List<Verse> GetCached()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                return db.Verses.Where(i => i.ChapterId == chapter.Id)
                    .Include(verse => verse.Chapter.Book.Bible)
                    .ToList();
            }

            void LinkForeigns(Verse verse)
            {
                LinkSource(verse, chapter);
                verse.Chapter = chapter;
                verse.ChapterId = chapter.Id;
            }

            void Cache()
            {
                using var scope = ScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BibleContext>();
                db.Chapters.Attach(verses.First().Chapter);
                db.Verses.AddRange(verses);
                db.SaveChanges();
            }
        }
    }
}
