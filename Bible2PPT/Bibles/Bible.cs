using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Bible2PPT.Bibles
{
    class Bible
    {
        [IgnoreDataMember]
        public Sources.BibleSource Source { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string OnlineId { get; set; }
        public string Version { get; set; }

        public List<BibleBook> Books => Source.GetBooks(this);

        public override string ToString() => Version ?? base.ToString();
    }
}
