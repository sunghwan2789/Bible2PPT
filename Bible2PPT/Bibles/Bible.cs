namespace Bible2PPT.Bibles
{
    class Bible : BibleBase
    {
        public string OnlineId { get; set; }
        public string Name { get; set; }

        //public List<Book> Books => Source.GetBooks(this);

        public override string ToString() => Name ?? base.ToString();
    }
}
