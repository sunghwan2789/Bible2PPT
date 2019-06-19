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

        public List<Bible> GetBibles()
        {
            List<Bible> bibles;

            if (!AppConfig.Context.UseCache)
            {
                bibles = GetBiblesOnline();
                bibles.ForEach(bible => LinkForeigns(bible));
                return bibles;
            }

            using (var db = new BibleDb())
            using (var cursor = db.Bibles)
            {
                cursor.SetCurrentIndex("SourceId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(Id));
                bibles = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Bible>).ToList();
                if (bibles.Any())
                {
                    // ANNOYING LOOPS
                    foreach (var bible in bibles)
                    {
                        LinkForeigns(bible);
                    }
                    return bibles;
                }
            }

            bibles = GetBiblesOnline();

            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Bibles)
            {
                foreach (var bible in bibles)
                {
                    LinkForeigns(bible);

                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, bible);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
            return bibles;
        }

        public List<Book> GetBooks(Bible bible)
        {
            List<Book> books;

            if (!AppConfig.Context.UseCache)
            {
                books = GetBooksOnline(bible);
                books.ForEach(book => LinkForeigns(book, bible));
                return books;
            }

            using (var db = new BibleDb())
            using (var cursor = db.Books)
            {
                cursor.SetCurrentIndex("BibleId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(bible.Id));
                books = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Book>).ToList();
                if (books.Any())
                {
                    // ANNOYING LOOPS
                    foreach (var book in books)
                    {
                        LinkForeigns(book, bible);
                    }
                    return books;
                }
            }

            books = GetBooksOnline(bible);

            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Books)
            {
                foreach (var book in books)
                {
                    LinkForeigns(book, bible);

                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, book);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
            return books;
        }

        public List<Chapter> GetChapters(Book book)
        {
            List<Chapter> chapters;

            if (!AppConfig.Context.UseCache)
            {
                chapters = GetChaptersOnline(book);
                chapters.ForEach(chapter => LinkForeigns(chapter, book));
                return chapters;
            }

            using (var db = new BibleDb())
            using (var cursor = db.Chapters)
            {
                cursor.SetCurrentIndex("BookId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(book.Id));
                chapters = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Chapter>).ToList();
                if (chapters.Any())
                {
                    // ANNOYING LOOPS
                    foreach (var chapter in chapters)
                    {
                        LinkForeigns(chapter, book);
                    }
                    return chapters;
                }
            }

            chapters = GetChaptersOnline(book);

            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Chapters)
            {
                foreach (var chapter in chapters)
                {
                    LinkForeigns(chapter, book);

                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, chapter);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
            return chapters;
        }

        public List<Verse> GetVerses(Chapter chapter)
        {
            List<Verse> verses;

            if (!AppConfig.Context.UseCache)
            {
                verses = GetVersesOnline(chapter);
                verses.ForEach(verse => LinkForeigns(verse, chapter));
                return verses;
            }

            using (var db = new BibleDb())
            using (var cursor = db.Verses)
            {
                cursor.SetCurrentIndex("ChapterId");
                cursor.FindRecords(MatchCriteria.EqualTo, Key.Compose(chapter.Id));
                verses = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Verse>).ToList();
                if (verses.Any())
                {
                    // ANNOYING LOOPS
                    foreach (var verse in verses)
                    {
                        LinkForeigns(verse, chapter);
                    }
                    return verses;
                }
            }

            verses = GetVersesOnline(chapter);

            using (var db = new BibleDb())
            using (var tx = db.Transaction)
            using (var cursor = db.Verses)
            {
                foreach (var verse in verses)
                {
                    LinkForeigns(verse, chapter);

                    cursor.BeginEditForInsert();
                    BibleDb.MapEntity(cursor, verse);
                    cursor.AcceptChanges();
                }
                tx.Commit();
            }
            return verses;
        }

        public Task<List<Bible>> GetBiblesAsync() => Task.Factory.StartNew(GetBibles);
        public Task<List<Book>> GetBooksAsync(Bible bible) => Task.Factory.StartNew(() => GetBooks(bible));
        public Task<List<Chapter>> GetChaptersAsync(Book book) => Task.Factory.StartNew(() => GetChapters(book));
        public Task<List<Verse>> GetVersesAsync(Chapter chapter) => Task.Factory.StartNew(() => GetVerses(chapter));

        public override string ToString() => Name ?? base.ToString();
    }
}
