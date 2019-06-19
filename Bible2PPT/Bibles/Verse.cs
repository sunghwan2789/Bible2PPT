using System;

namespace Bible2PPT.Bibles
{
    class Verse : BibleBase
    {
        [IndexKey(Name = nameof(ChapterId))]
        public Guid ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }
    }
}
