namespace Bible2PPT.Bibles;

public class Book : BibleBase
{
    public int BibleId { get; set; }
    public Bible Bible { get; set; } = null!;

    public string OnlineId { get; set; } = null!;
    public string Name { get; set; } = null!;

    private string shortTitle = null!;
    public string Abbreviation
    {
        get => shortTitle ?? BookAliases.Map.FirstOrDefault(i => i.Any(a => a == OnlineId || a == Name))?.First() ?? "";
        set => shortTitle = value;
    }

    public int ChapterCount { get; set; }

    //public List<Chapter> Chapters => Source.GetChapters(this);
}
