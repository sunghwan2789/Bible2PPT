using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class BibleVersion : Bible
    {
        public string OnlineId { get; set; }
        public string Name { get; set; }

        public List<BibleBook> Books => Source.GetBooks(this);

        public override string ToString() => Name ?? base.ToString();
    }
}
