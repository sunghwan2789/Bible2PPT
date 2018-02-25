using System.Collections.Generic;

namespace Bible2PPT.Bibles
{
    class Bible
    {
        public Sources.BibleSource Source { get; set; }

        public int SequenceId { get; set; }
        public string BibleId { get; set; }
        public string Version { get; set; }

        public List<BibleBook> Books => Source.GetBooks(this);

        public override string ToString() => Version ?? base.ToString();
    }
}
