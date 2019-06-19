using System;

namespace Bible2PPT.Bibles
{
    class BibleBase
    {
        [IndexKey(Name = nameof(SourceId))]
        public int SourceId { get; set; }
        public virtual Sources.BibleSource Source { get; set; } //Sources.BibleSource.AvailableSources.FirstOrDefault(i => i.Id == SourceId)

        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
