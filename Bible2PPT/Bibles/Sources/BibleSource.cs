using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible2PPT.Bibles.Sources
{
    abstract class BibleSource
    {
        public static BibleSource[] AvailableSources = new BibleSource[]
        {
            new GodpeopleBible { SequenceId = 0 },
            //new GodpiaBible { SequenceId = 1 },
        };

        public int SequenceId { get; set; }
        public string Name { get; set; }

        public abstract List<Bible> GetBibles();
        public abstract List<BibleBook> GetBooks(Bible bible);
        public abstract List<BibleChapter> GetChapters(BibleBook book);
        public abstract List<string> GetVerses(BibleChapter chapter);

        public Task<List<Bible>> GetBiblesAsync() => Task.Factory.StartNew(GetBibles);
        public Task<List<BibleBook>> GetBooksAsync(Bible bible) => Task.Factory.StartNew(() => GetBooks(bible));
        public Task<List<BibleChapter>> GetChaptersAsync(BibleBook book) => Task.Factory.StartNew(() => GetChapters(book));
        public Task<List<string>> GetVersesAsync(BibleChapter chapter) => Task.Factory.StartNew(() => GetVerses(chapter));

        public override string ToString() => Name ?? base.ToString();
    }
}
