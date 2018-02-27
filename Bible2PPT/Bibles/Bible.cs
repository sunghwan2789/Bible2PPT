using System;

namespace Bible2PPT.Bibles
{
    class Bible
    {
        public virtual Sources.BibleSource Source { get; set; } //Sources.BibleSource.AvailableSources.FirstOrDefault(i => i.Id == SourceId)
        public int SourceId { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
