using System;
using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class BibleChapter : Bible
    {
        [IndexKey(Name = nameof(BookId))]
        public Guid BookId { get; set; }
        public virtual BibleBook Book { get; set; }

        public int Number { get; set; }

        public List<BibleVerse> Verses => Source.GetVerses(this);
    }
}
