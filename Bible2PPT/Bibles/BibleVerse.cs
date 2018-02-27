using System;

namespace Bible2PPT.Bibles
{
    class BibleVerse : Bible
    {
        public virtual BibleChapter Chapter { get; set; }
        public Guid ChapterId { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }
    }
}
