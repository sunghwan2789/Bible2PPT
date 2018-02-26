using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bible2PPT.Bibles
{
    class BibleChapter
    {
        [IgnoreDataMember]
        public Sources.BibleSource Source { get; set; }

        [IgnoreDataMember]
        public BibleBook Book { get; set; }

        public int ChapterNumber { get; set; }

        public List<BibleVerse> Verses => Source.GetVerses(this);
    }
}
