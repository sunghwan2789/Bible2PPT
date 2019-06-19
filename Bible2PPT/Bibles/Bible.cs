using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class Bible : BibleBase
    {
        public string OnlineId { get; set; }
        public string Version { get; set; }

        public List<Book> Books => Source.GetBooks(this);

        public override string ToString() => Version ?? base.ToString();
    }
}
