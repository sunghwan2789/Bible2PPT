using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bible2PPT.Bibles
{
    class BibleChapter : Bible
    {
        [IgnoreDataMember]
        public virtual BibleBook Book { get; set; }
        public Guid BookId { get; set; }

        public int Number { get; set; }

        public List<BibleVerse> Verses => Source.GetVerses(this);
    }
}
