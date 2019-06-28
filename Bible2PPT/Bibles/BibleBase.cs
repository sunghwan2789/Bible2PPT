using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bible2PPT.Bibles
{
    class BibleBase
    {
        public int SourceId { get; set; }
        [NotMapped]
        public virtual Sources.Source Source { get; set; } //Sources.BibleSource.AvailableSources.FirstOrDefault(i => i.Id == SourceId)

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
