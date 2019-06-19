using System;
using System.Collections.Generic;
using System.Linq;

namespace Bible2PPT.Bibles
{
    class Book : BibleBase
    {
        [IndexKey(Name = nameof(BibleId))]
        public Guid BibleId { get; set; }
        public virtual Bible Bible { get; set; }

        public string OnlineId { get; set; }
        public string Title { get; set; }

        private string shortTitle;
        public string ShortTitle
        {
            get => shortTitle ?? BookAliases.Map.FirstOrDefault(i => i.Any(a => a == OnlineId || a == Title))?.First() ?? "";
            set => shortTitle = value;
        }

        public int ChapterCount { get; set; }

        public List<Chapter> Chapters => Source.GetChapters(this);
    }
}
