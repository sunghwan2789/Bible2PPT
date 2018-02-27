using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Bible2PPT.Bibles
{
    class BibleVerse : Bible
    {
        [IgnoreDataMember]
        public virtual BibleChapter Chapter { get; set; }
        public Guid ChapterId { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }
    }
}
