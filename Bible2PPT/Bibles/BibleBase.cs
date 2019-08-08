using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Bible2PPT.Bibles
{
    class BibleBase
    {
        public int SourceId { get; set; }

        private Sources.Source source = null;
        [NotMapped]
        public Sources.Source Source
        {
            get => source ?? Sources.Source.AvailableSources.FirstOrDefault(source => source.Id == SourceId);
            set => source = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
