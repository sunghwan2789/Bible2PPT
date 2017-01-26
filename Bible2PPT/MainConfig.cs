namespace Bible2PPT
{
    class MainConfig : Config
    {
        public int cmbLongTitleIdx = 0;
        public int cmbShortTitleIdx = 0;
        public int cmbChapNumIdx = 0;
        public bool radEasyChecked = false;
        public bool chkFragmentChecked = false;

        public MainConfig(string path) : base(path) {}

        public override byte Serialize()
        {
            int ret = 0;
            ret |= this.cmbLongTitleIdx;
            ret |= this.cmbShortTitleIdx << 1;
            ret |= this.cmbChapNumIdx << 2;
            ret |= this.radEasyChecked ? 8 : 0;
            ret |= this.chkFragmentChecked ? 16 : 0;
            return (byte) ret;
        }

        public override void Deserialize(byte s)
        {
            this.cmbLongTitleIdx = s & 1;
            this.cmbShortTitleIdx = (s & 2) >> 1;
            this.cmbChapNumIdx = (s & 4) >> 2;
            this.radEasyChecked = (s & 8) == 8;
            this.chkFragmentChecked = (s & 16) == 16;
        }
    }
}
