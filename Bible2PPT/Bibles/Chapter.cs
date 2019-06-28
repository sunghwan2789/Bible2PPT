using System;
using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class Chapter : BibleBase
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public string OnlineId { get; set; }
        public int Number { get; set; }

        //public List<Verse> Verses => Source.GetVerses(this);
    }
}
