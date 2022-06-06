using Bible2PPT.Services.BibleIndexService;

namespace Bible2PPT;

public record VerseQuery
{
    public BookKey BookKey { get; set; }
    public int StartChapterNumber { get; set; } = 1;
    public int StartVerseNumber { get; set; } = 1;
    public int? EndChapterNumber { get; set; }
    public int? EndVerseNumber { get; set; }
}
