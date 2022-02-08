namespace Bible2PPT.Services.BibleIndexService;

public record BookInfo
{
    public BookKey Key { get; set; }
    public BookInfoKind Kind { get; set; }
    public string LanguageCode { get; set; } = null!;
    public string Version { get; set; } = null!;

    public string Value { get; set; } = null!;

    public bool IsPrimary { get; set; }
}
