using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Bible2PPT.Bibles
{
    class Bible
    {
        [IgnoreDataMember]
        public virtual Sources.BibleSource Source { get; set; } //Sources.BibleSource.AvailableSources.FirstOrDefault(i => i.Id == SourceId)
        public int SourceId { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
