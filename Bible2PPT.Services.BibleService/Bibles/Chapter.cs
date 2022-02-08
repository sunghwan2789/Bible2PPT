namespace Bible2PPT.Bibles;

public record Chapter : BibleBase
{
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public string OnlineId { get; set; } = null!;
    public int Number { get; set; }

    //public List<Verse> Verses => Source.GetVerses(this);
}
