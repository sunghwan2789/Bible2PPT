using System;

namespace Bible2PPT.Bibles
{
    class BibleVerse : Bible
    {
        [IndexKey(Name = nameof(ChapterId))]
        public Guid ChapterId { get; set; }
        public virtual BibleChapter Chapter { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }
    }
}
