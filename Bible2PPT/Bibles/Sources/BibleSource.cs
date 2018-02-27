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

        public abstract List<Bible> GetBibles();
        public abstract List<BibleBook> GetBooks(Bible bible);
        public abstract List<BibleChapter> GetChapters(BibleBook book);
        public abstract List<BibleVerse> GetVerses(BibleChapter chapter);

        public List<Bible> GetBiblesC()
        {
            List<Bible> bibles;
            using (var db = new BibleDb())
            {
                using (var cursor = db.Bibles)
                {
                    bibles = cursor.Cast<FieldCollection>().Select(BibleDb.MapEntity<Bible>).ToList();
                    if (bibles.Any())
                    {
                        // ANNOYING LOOPS
                        foreach (var bible in bibles)
                        {
                            bible.Source = this;
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
                        cursor.BeginEditForInsert();
                        BibleDb.MapEntity(cursor, bible);
                        cursor.AcceptChanges();
                    }
                    tx.Commit();
                }
                return bibles;
            }
        }

        public List<BibleBook> GetBooksC(Bible bible)
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
                            book.Source = this;
                            book.Bible = bible;
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
                        cursor.BeginEditForInsert();
                        BibleDb.MapEntity(cursor, book);
                        cursor.AcceptChanges();
                    }
                    tx.Commit();
                }
                return books;
            }
        }

        public List<BibleChapter> GetChaptersC(BibleBook book) => GetChapters(book);
        public List<BibleVerse> GetVersesC(BibleChapter chapter) => GetVerses(chapter);

        public Task<List<Bible>> GetBiblesAsync() => Task.Factory.StartNew(GetBiblesC);
        public Task<List<BibleBook>> GetBooksAsync(Bible bible) => Task.Factory.StartNew(() => GetBooksC(bible));
        public Task<List<BibleChapter>> GetChaptersAsync(BibleBook book) => Task.Factory.StartNew(() => GetChapters(book));
        public Task<List<BibleVerse>> GetVersesAsync(BibleChapter chapter) => Task.Factory.StartNew(() => GetVerses(chapter));

        public override string ToString() => Name ?? base.ToString();
    }
}
