using System.Windows.Forms;

namespace Bible2PPT
{
    class AppConfig : ByteConfig
    {
        public static string ConfigPath { get; } = Application.ExecutablePath + ".cfg";
        public static string TemplatePath { get; } = Application.ExecutablePath + ".pptx";
        public static string ContactUrl { get; } = "https://github.com/sunghwan2789/Bible2PPT";

        public static AppConfig Context { get; } = new AppConfig();

        public TemplateTextOptions ShowLongTitle { get; set; } = TemplateTextOptions.Always;
        public TemplateTextOptions ShowShortTitle { get; set; } = TemplateTextOptions.Always;
        public TemplateTextOptions ShowChapterNumber { get; set; } = TemplateTextOptions.Always;
        public bool UseEasyBible { get; set; } = false;
        public bool SeperateByChapter { get; set; } = false;

        public AppConfig() : base(ConfigPath) {}

        protected override byte Serialize()
        {
            int ret = 0;
            ret |= (int) ShowLongTitle;
            ret |= ((int) ShowShortTitle) << 1;
            ret |= ((int) ShowChapterNumber) << 2;
            ret |= UseEasyBible ? 8 : 0;
            ret |= SeperateByChapter ? 16 : 0;
            return (byte) ret;
        }

        protected override void Deserialize(byte s)
        {
            ShowLongTitle = (TemplateTextOptions) (s & 1);
            ShowShortTitle = (TemplateTextOptions) ((s & 2) >> 1);
            ShowChapterNumber = (TemplateTextOptions) ((s & 4) >> 2);
            UseEasyBible = (s & 8) == 8;
            SeperateByChapter = (s & 16) == 16;
        }
    }
}
