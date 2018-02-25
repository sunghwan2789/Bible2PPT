using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class BibleChapter
    {
        public Sources.BibleSource Source { get; set; }
        public BibleBook Book { get; set; }

        public int ChapterNumber { get; set; }

        public List<string> Verses => Source.GetVerses(this);
    }
}
