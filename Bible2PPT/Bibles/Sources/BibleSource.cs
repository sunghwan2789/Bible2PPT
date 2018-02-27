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
        };

        public int Id { get; set; }
        public string Name { get; set; }

        public static BibleSource Find(int sourceId) => AvailableSources.FirstOrDefault(i => i.Id == sourceId);

        public abstract List<BibleVersion> GetBibles();
        public abstract List<BibleBook> GetBooks(BibleVersion bible);
        public abstract List<BibleChapter> GetChapters(BibleBook book);
        public abstract List<BibleVerse> GetVerses(BibleChapter chapter);

        protected void LinkForeigns(Bible bible)
        {
            bible.Source = this;
            bible.SourceId = Id;
        }

        protected void LinkForeigns(BibleBook book, BibleVersion bible)
        {
            LinkForeigns(book);
            book.Bible = bible;
            book.BibleId = bible.Id;
        }

        protected void LinkForeigns(BibleChapter chapter, BibleBook book)
        {
            LinkForeigns(chapter);
            chapter.Book = book;
            chapter.BookId = book.Id;
        }

        protected void LinkForeigns(BibleVerse verse, BibleChapter chapter)
        {
            LinkForeigns(verse);
            verse.Chapter = chapter;
            verse.ChapterId = chapter.Id;
        }

        public List<BibleVersion> GetBiblesC()
        {
            List<BibleVersion> bibles;
            using (var db = new BibleDb())
            {
                using (var cursor = db.Bibles)
                {
                    bibles = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<BibleVersion>)
                        .Where(i => i.SourceId == Id).ToList();
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

                bibles = GetBibles();

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
        }

        public List<BibleBook> GetBooksC(BibleVersion bible)
        {
            List<BibleBook> books;
            using (var db = new BibleDb())
            {
                using (var cursor = db.Books)
                {
                    books = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<BibleBook>)
                        .Where(i => i.BibleId == bible.Id).ToList();
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

                books = GetBooks(bible);

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
        }

        public List<BibleChapter> GetChaptersC(BibleBook book)
        {
            List<BibleChapter> chapters;
            using (var db = new BibleDb())
            {
                using (var cursor = db.Chapters)
                {
                    chapters = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<BibleChapter>)
                        .Where(i => i.BookId == book.Id).ToList();
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

                chapters = GetChapters(book);

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
        }

        public List<BibleVerse> GetVersesC(BibleChapter chapter)
        {
            List<BibleVerse> verses;
            using (var db = new BibleDb())
            {
                using (var cursor = db.Verses)
                {
                    verses = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<BibleVerse>)
                        .Where(i => i.ChapterId == chapter.Id).ToList();
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

                verses = GetVerses(chapter);

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
        }

        public Task<List<BibleVersion>> GetBiblesAsync() => Task.Factory.StartNew(GetBiblesC);
        public Task<List<BibleBook>> GetBooksAsync(BibleVersion bible) => Task.Factory.StartNew(() => GetBooksC(bible));
        public Task<List<BibleChapter>> GetChaptersAsync(BibleBook book) => Task.Factory.StartNew(() => GetChaptersC(book));
        public Task<List<BibleVerse>> GetVersesAsync(BibleChapter chapter) => Task.Factory.StartNew(() => GetVersesC(chapter));

        public override string ToString() => Name ?? base.ToString();
    }
}
