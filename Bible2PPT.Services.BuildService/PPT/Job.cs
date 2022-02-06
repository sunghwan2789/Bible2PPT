using System.ComponentModel.DataAnnotations.Schema;
using Bible2PPT.Bibles;
using Bible2PPT.Services.TemplateService;

namespace Bible2PPT.PPT;

public class Job
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public ICollection<Bible> Bibles { get; set; } = null!;

    public Template Template { get; set; } = null!;

    public string QueryString { get; set; } = null!;
    public bool SplitChaptersIntoFiles { get; set; }
    public string OutputDestination { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
