using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Bible2PPT.Bibles;
using Bible2PPT.Data;

namespace Bible2PPT.Sources
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

        public abstract Task<List<Bible>> GetBiblesOnlineAsync();
        public abstract Task<List<Book>> GetBooksOnlineAsync(Bible bible);
        public abstract Task<List<Chapter>> GetChaptersOnlineAsync(Book book);
        public abstract Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter);


        public override string ToString() => Name ?? base.ToString();
    }
}
