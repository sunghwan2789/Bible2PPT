using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT
{
    class BibleChapter
    {
        public int ChapterNumber { get; set; }
        public BibleInfo Bible { get; set; }
        public List<string> Verses { get; set; }
    }
}
