namespace Bible2PPT.Bibles;

public record Verse : BibleBase
{
    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; } = null!;

    public int Number { get; set; }
    public string Text { get; set; } = null!;
}
