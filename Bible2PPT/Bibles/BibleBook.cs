using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Bible2PPT.Bibles
{
    class BibleBook
    {
        [IgnoreDataMember]
        public Sources.BibleSource Source { get; set; }

        [IgnoreDataMember]
        public Bible Bible { get; set; }

        public int BibleSeq { get; set; }

        public int SequenceId { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }

        private string shortTitle;
        public string ShortTitle
        {
            get => shortTitle ?? BibleBookAliases.Map.FirstOrDefault(i => i.Any(a => a == BookId || a == Title))?.First() ?? "";
            set => shortTitle = value;
        }

        // TODO: Maybe null on GodpiaBible
        private int? chapterCount;
        public int ChapterCount
        {
            get => chapterCount ?? Chapters.Count;
            set => chapterCount = value;
        }

        public List<BibleChapter> Chapters => Source.GetChapters(this);
    }
}
