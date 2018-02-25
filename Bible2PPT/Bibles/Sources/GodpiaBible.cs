using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible2PPT.Bibles.Sources
{
    class GodpiaBible : BibleSource
    {
        public override List<Bible> GetBibles() => throw new NotImplementedException();
        public override List<BibleBook> GetBooks(Bible bible) => throw new NotImplementedException();
        public override List<BibleChapter> GetChapters(BibleBook book) => throw new NotImplementedException();
        public override List<string> GetVerses(BibleChapter chapter) => throw new NotImplementedException();
    }
}
