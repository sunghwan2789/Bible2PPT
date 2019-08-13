using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Bible2PPT.Data;

namespace Bible2PPT.Bibles.Sources
{
    abstract class Source
    {
        public static Source[] AvailableSources = new Source[]
        {
            new GodpeopleBible { Id = 0 },
            new GodpiaBible { Id = 1 },
            new GoodtvBible { Id = 2 },
        };

        public int Id { get; set; }
        public string Name { get; set; }

        protected abstract Task<List<Bible>> GetBiblesOnlineAsync();
        protected abstract Task<List<Book>> GetBooksOnlineAsync(Bible bible);
        protected abstract Task<List<Chapter>> GetChaptersOnlineAsync(Book book);
        protected abstract Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter);

        private void LinkSource(BibleBase bible)
        {
            bible.Source = this;
            bible.SourceId = Id;
        }

        public async Task<List<Bible>> GetBiblesAsync()
        {
            // 캐시가 있으면 사용
            var bibles = GetCached();
            if (bibles.Any())
            {
                return bibles;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            bibles = await GetBiblesOnlineAsync();
            bibles.ForEach(LinkSource);
            Cache();
            return bibles;

            List<Bible> GetCached()
            {
                using (var db = new BibleContext())
                {
                    return db.Bibles.Where(i => i.SourceId == Id).ToList();
                }
            }

            void Cache()
            {
                using (var db = new BibleContext())
                {
                    db.Bibles.AddRange(bibles);
                    db.SaveChanges();
                }
            }
        }

        public async Task<List<Book>> GetBooksAsync(Bible bible)
        {
            // 캐시가 있으면 사용
            var books = GetCached();
            if (books.Any())
            {
                return books;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            books = await GetBooksOnlineAsync(bible);
            books.ForEach(LinkForeigns);
            Cache();
            return books;

            List<Book> GetCached()
            {
                using (var db = new BibleContext())
                {
                    return db.Books.Where(i => i.BibleId == bible.Id)
                        .Include(book => book.Bible)
                        .ToList();
                }
            }

            void LinkForeigns(Book book)
            {
                LinkSource(book);
                book.Bible = bible;
                book.BibleId = bible.Id;
            }

            void Cache()
            {
                using (var db = new BibleContext())
                {
                    db.Bibles.Attach(books.First().Bible);
                    db.Books.AddRange(books);
                    db.SaveChanges();
                }
            }
        }

        public async Task<List<Chapter>> GetChaptersAsync(Book book)
        {
            // 캐시가 있으면 사용
            var chapters = GetCached();
            if (chapters.Any())
            {
                return chapters;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            chapters = await GetChaptersOnlineAsync(book);
            chapters.ForEach(LinkForeigns);
            chapters.Sort((a, b) => a.Number.CompareTo(b.Number));
            Cache();
            return chapters;

            List<Chapter> GetCached()
            {
                using (var db = new BibleContext())
                {
                    return db.Chapters.Where(i => i.BookId == book.Id)
                        .Include(chapter => chapter.Book.Bible)
                        .ToList();
                }
            }

            void LinkForeigns(Chapter chapter)
            {
                LinkSource(chapter);
                chapter.Book = book;
                chapter.BookId = book.Id;
            }

            void Cache()
            {
                using (var db = new BibleContext())
                {
                    db.Books.Attach(chapters.First().Book);
                    db.Chapters.AddRange(chapters);
                    db.SaveChanges();
                }
            }
        }

        public async Task<List<Verse>> GetVersesAsync(Chapter chapter)
        {
            // 캐시가 있으면 사용
            var verses = GetCached();
            if (verses.Any())
            {
                return verses;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            verses = await GetVersesOnlineAsync(chapter);
            verses.ForEach(LinkForeigns);
            verses.Sort((a, b) => a.Number.CompareTo(b.Number));
            Cache();
            return verses;

            List<Verse> GetCached()
            {
                using (var db = new BibleContext())
                {
                    return db.Verses.Where(i => i.ChapterId == chapter.Id)
                        .Include(verse => verse.Chapter.Book.Bible)
                        .ToList();
                }
            }

            void LinkForeigns(Verse verse)
            {
                LinkSource(verse);
                verse.Chapter = chapter;
                verse.ChapterId = chapter.Id;
            }

            void Cache()
            {
                using (var db = new BibleContext())
                {
                    db.Chapters.Attach(verses.First().Chapter);
                    db.Verses.AddRange(verses);
                    db.SaveChanges();
                }
            }
        }


        public override string ToString() => Name ?? base.ToString();
    }
}
