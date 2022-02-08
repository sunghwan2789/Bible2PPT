using System.ComponentModel.DataAnnotations.Schema;
using Bible2PPT.Sources;

namespace Bible2PPT.Bibles;

public record BibleBase
{
    public int SourceId { get; set; }

    [NotMapped]
    public BibleSource? Source
    {
        get => source ?? BibleSource.AvailableSources.FirstOrDefault(source => source.Id == SourceId);
        set => source = value;
    }
    private BibleSource? source = null;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
