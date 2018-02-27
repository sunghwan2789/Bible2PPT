using System;
using System.Collections.Generic;
using System.Linq;

namespace Bible2PPT.Bibles
{
    class BibleBook : Bible
    {
        [IndexKey(Name = nameof(BibleId))]
        public Guid BibleId { get; set; }
        public virtual BibleVersion Bible { get; set; }

        public string OnlineId { get; set; }
        public string Title { get; set; }

        private string shortTitle;
        public string ShortTitle
        {
            get => shortTitle ?? BibleBookAliases.Map.FirstOrDefault(i => i.Any(a => a == OnlineId || a == Title))?.First() ?? "";
            set => shortTitle = value;
        }

        public int ChapterCount { get; set; }

        public List<BibleChapter> Chapters => Source.GetChapters(this);
    }
}
