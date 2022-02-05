using System.ComponentModel.DataAnnotations.Schema;
using Bible2PPT.Bibles;

namespace Bible2PPT.PPT;

public class Job
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public ICollection<Bible> Bibles { get; set; } = null!;

    public TemplateTextOptions TemplateBookNameOption { get; set; }
    public TemplateTextOptions TemplateBookAbbrOption { get; set; }
    public TemplateTextOptions TemplateChapterNumberOption { get; set; }
    public int NumberOfVerseLinesPerSlide { get; set; }
    public string QueryString { get; set; } = null!;
    public bool SplitChaptersIntoFiles { get; set; }
    public string OutputDestination { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
