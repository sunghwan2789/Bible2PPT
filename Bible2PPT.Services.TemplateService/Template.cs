namespace Bible2PPT.Services.TemplateService;

public class Template
{
    public string FileName { get; set; } = null!;
    public TemplateTextOptions BookNameVisible { get; set; }
    public TemplateTextOptions BookAbbrVisible { get; set; }
    public TemplateTextOptions ChapterNumberVisible { get; set; }
    public int NumberOfVerseLinesPerSlide { get; set; }
}
