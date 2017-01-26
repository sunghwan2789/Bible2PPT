namespace Bible2PPT
{
    class Bible
    {
        public string longTitle;
        public string shortTitle;
        public int chapterLength;

        public Bible(string lt, string st, int cl)
        {
            longTitle = lt;
            shortTitle = st;
            chapterLength = cl;
        }
    }
}
