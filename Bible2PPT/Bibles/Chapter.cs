using System;
using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class Chapter : BibleBase
    {
        [IndexKey(Name = nameof(BookId))]
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        public int Number { get; set; }

        public List<Verse> Verses => Source.GetVerses(this);
    }
}
