using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Bible2PPT.Bibles
{
    class BibleVerse
    {
        [IgnoreDataMember]
        public Sources.BibleSource Source { get; set; }

        [IgnoreDataMember]
        public BibleChapter Chapter { get; set; }

        public int VerseNumber { get; set; }
        public string Text { get; set; }
    }
}
