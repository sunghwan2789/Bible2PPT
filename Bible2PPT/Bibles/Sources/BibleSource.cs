using Microsoft.Database.Isam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible2PPT.Bibles.Sources
{
    abstract class BibleSource
    {
        public static BibleSource[] AvailableSources = new BibleSource[]
        {
            new GodpeopleBible { Id = 0 },
            new GodpiaBible { Id = 1 },
            new GoodtvBible { Id = 2 },
        };

        public int Id { get; set; }
        public string Name { get; set; }

        protected abstract List<Bible> GetBiblesOnline();
        protected abstract List<Book> GetBooksOnline(Bible bible);
        protected abstract List<Chapter> GetChaptersOnline(Book book);
        protected abstract List<Verse> GetVersesOnline(Chapter chapter);

        private void LinkForeigns(BibleBase bible)
        {
            bible.Source = this;
            bible.SourceId = Id;
        }

        private void LinkForeigns(Book book, Bible bible)
        {
            LinkForeigns(book);
            book.Bible = bible;
            book.BibleId = bible.Id;
        }

        private void LinkForeigns(Chapter chapter, Book book)
        {
            LinkForeigns(chapter);
            chapter.Book = book;
            chapter.BookId = book.Id;
        }

        private void LinkForeigns(Verse verse, Chapter chapter)
        {
            LinkForeigns(verse);
            verse.Chapter = chapter;
            verse.ChapterId = chapter.Id;
        }


        private void CacheBibles(List<Bible> bibles)
        {
            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Bibles)
            {
                foreach (var bible in bibles)
                {
                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, bible);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
        }

        private void CacheBooks(List<Book> books)
        {
            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Books)
            {
                foreach (var book in books)
                {
                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, book);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
        }

        private void CacheChapters(List<Chapter> chapters)
        {
            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Chapters)
            {
                foreach (var chapter in chapters)
                {
                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, chapter);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
        }

        private void CacheVerses(List<Verse> verses)
        {
            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Verses)
            {
                foreach (var verse in verses)
                {
                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, verse);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
        }

        private List<Bible> GetBiblesCached()
        {
            using (var db = new BibleDb())
            using (var cursor = db.Bibles)
            {
                cursor.SetCurrentIndex("SourceId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(Id));
                return cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Bible>).ToList();
            }
        }

        private List<Book> GetBooksCached(Bible bible)
        {
            using (var db = new BibleDb())
            using (var cursor = db.Books)
            {
                cursor.SetCurrentIndex("BibleId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(bible.Id));
                return cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Book>).ToList();
            }
        }

        private List<Chapter> GetChaptersCached(Book book)
        {
            using (var db = new BibleDb())
            using (var cursor = db.Chapters)
            {
                cursor.SetCurrentIndex("BookId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(book.Id));
                return cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Chapter>).ToList();
            }
        }

        private List<Verse> GetVersesCached(Chapter chapter)
        {
            using (var db = new BibleDb())
            using (var cursor = db.Verses)
            {
                cursor.SetCurrentIndex("ChapterId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(chapter.Id));
                return cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Verse>).ToList();
            }
        }


        public List<Bible> GetBibles()
        {
            List<Bible> bibles;
            // 오프라인 캐시 미사용 시 온라인 데이터 가져오기
            if (!AppConfig.Context.UseCache)
            {
                bibles = GetBiblesOnline();
                bibles.ForEach(LinkForeigns);
                return bibles;
            }
            // 캐시가 있으면 사용
            bibles = GetBiblesCached();
            bibles.ForEach(LinkForeigns);
            if (bibles.Any())
            {
                return bibles;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            bibles = GetBiblesOnline();
            bibles.ForEach(LinkForeigns);
            CacheBibles(bibles);
            return bibles;
        }

        public List<Book> GetBooks(Bible bible)
        {
            List<Book> books;
            // 오프라인 캐시 미사용 시 온라인 데이터 가져오기
            if (!AppConfig.Context.UseCache)
            {
                books = GetBooksOnline(bible);
                books.ForEach(book => LinkForeigns(book, bible));
                return books;
            }
            // 캐시가 있으면 사용
            books = GetBooksCached(bible);
            books.ForEach(book => LinkForeigns(book, bible));
            if (books.Any())
            {
                return books;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            books = GetBooksOnline(bible);
            books.ForEach(book => LinkForeigns(book, bible));
            CacheBooks(books);
            return books;
        }

        public List<Chapter> GetChapters(Book book)
        {
            List<Chapter> chapters;
            // 오프라인 캐시 미사용 시 온라인 데이터 가져오기
            if (!AppConfig.Context.UseCache)
            {
                chapters = GetChaptersOnline(book);
                chapters.ForEach(chapter => LinkForeigns(chapter, book));
                return chapters;
            }
            // 캐시가 있으면 사용
            chapters = GetChaptersCached(book);
            chapters.ForEach(chapter => LinkForeigns(chapter, book));
            if (chapters.Any())
            {
                return chapters;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            chapters = GetChaptersOnline(book);
            chapters.ForEach(chapter => LinkForeigns(chapter, book));
            CacheChapters(chapters);
            return chapters;
        }

        public List<Verse> GetVerses(Chapter chapter)
        {
            List<Verse> verses;
            // 오프라인 캐시 미사용 시 온라인 데이터 가져오기
            if (!AppConfig.Context.UseCache)
            {
                verses = GetVersesOnline(chapter);
                verses.ForEach(verse => LinkForeigns(verse, chapter));
                return verses;
            }
            // 캐시가 있으면 사용
            verses = GetVersesCached(chapter);
            verses.ForEach(verse => LinkForeigns(verse, chapter));
            if (verses.Any())
            {
                return verses;
            }
            // 캐시가 없으면 온라인에서 가져와서 저장
            verses = GetVersesOnline(chapter);
            verses.ForEach(verse => LinkForeigns(verse, chapter));
            CacheVerses(verses);
            return verses;
        }


        public Task<List<Bible>> GetBiblesAsync() => Task.Factory.StartNew(GetBibles);
        public Task<List<Book>> GetBooksAsync(Bible bible) => Task.Factory.StartNew(() => GetBooks(bible));
        public Task<List<Chapter>> GetChaptersAsync(Book book) => Task.Factory.StartNew(() => GetChapters(book));
        public Task<List<Verse>> GetVersesAsync(Chapter chapter) => Task.Factory.StartNew(() => GetVerses(chapter));

        public override string ToString() => Name ?? base.ToString();
    }
}
