namespace Bible2PPT.Bibles;

public record Bible : BibleBase
{
    public string OnlineId { get; set; } = null!;
    public string Name { get; set; } = null!;

    public string LanguageCode { get; set; } = null!;

    //public List<Book> Books => Source.GetBooks(this);

    public override string ToString() => Name;
}
