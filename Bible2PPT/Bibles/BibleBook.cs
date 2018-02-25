using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class BibleBook
    {
        public Sources.BibleSource Source { get; set; }
        public Bible Bible { get; set; }

        public string BookId { get; set; }
        public string Title { get; set; }
        // TODO: 자동 페치하기
        public string ShortTitle { get; set; }
        public int ChapterCount { get; set; }
        public List<BibleChapter> Chapters { get; set; }
    }
}
