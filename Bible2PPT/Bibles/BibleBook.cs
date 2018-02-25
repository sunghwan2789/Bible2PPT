using System.Collections.Generic;
using System.Linq;

namespace Bible2PPT.Bibles
{
    class BibleBook
    {
        public Sources.BibleSource Source { get; set; }
        public Bible Bible { get; set; }

        public string BookId { get; set; }
        public string Title { get; set; }

        private string shortTitle;
        public string ShortTitle
        {
            get => shortTitle ?? BibleBookAliases.Map.FirstOrDefault(i => i.Any(a => a == BookId || a == Title))?.First() ?? "";
            set => shortTitle = value;
        }

        // TODO: Maybe null on GodpiaBible
        public int? ChapterCount { get; set; }

        public List<BibleChapter> Chapters => Source.GetChapters(this);
    }
}
