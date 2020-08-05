using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Bible2PPT.Sources;

namespace Bible2PPT.Bibles
{
    class BibleBase
    {
        public int SourceId { get; set; }

        private BibleSource source = null;
        [NotMapped]
        public BibleSource Source
        {
            get => source ?? BibleSource.AvailableSources.FirstOrDefault(source => source.Id == SourceId);
            set => source = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
