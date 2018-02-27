using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Bible2PPT
{
    class AppConfig : BinaryConfig
    {
        public const int ConfigSize = 1 + 4 + 16;
        public static string ConfigPath { get; } = Application.ExecutablePath + ".cfg";
        public static string TemplatePath { get; } = Application.ExecutablePath + ".pptx";
        public static string DatabaseWorkingDirectory { get; } = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
        public static string DatabasePath { get; } = Application.ExecutablePath + ".edb";
        public static string ContactUrl { get; } = "https://github.com/sunghwan2789/Bible2PPT";

        public static AppConfig Context { get; } = new AppConfig();
        
        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0000_0001,
        /// </summary>
        public TemplateTextOptions ShowLongTitle { get; set; } = TemplateTextOptions.Always;
        
        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0000_0010,
        /// </summary>
        public TemplateTextOptions ShowShortTitle { get; set; } = TemplateTextOptions.Always;

        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0000_0100,
        /// </summary>
        public TemplateTextOptions ShowChapterNumber { get; set; } = TemplateTextOptions.Always;

        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0001_0000,
        /// </summary>
        public bool SeperateByChapter { get; set; } = false;

        /// <summary>
        /// Offset: 1,
        /// Length: 4,
        /// </summary>
        public int BibleSourceId { get; set; } = 0;

        /// <summary>
        /// Offset: 5,
        /// Length: 16,
        /// </summary>
        public Guid BibleVersionId { get; set; }

        public AppConfig() : base(ConfigPath, ConfigSize) {}

        protected override byte[] Serialize()
        {
            var b = new byte[ConfigSize];
            b[0] = (byte) (int) ShowLongTitle;
            b[0] |= (byte) ((int) ShowShortTitle << 1);
            b[0] |= (byte) ((int) ShowChapterNumber << 2);
            b[0] |= (byte) (SeperateByChapter ? 16 : 0);
            BitConverter.GetBytes(BibleSourceId).CopyTo(b, 1);
            BibleVersionId.ToByteArray().CopyTo(b, 5);
            return b;
        }

        protected override void Deserialize(byte[] s)
        {
            ShowLongTitle = (TemplateTextOptions) (s[0] & 1);
            ShowShortTitle = (TemplateTextOptions) ((s[0] & 2) >> 1);
            ShowChapterNumber = (TemplateTextOptions) ((s[0] & 4) >> 2);
            SeperateByChapter = (s[0] & 16) == 16;
            BibleSourceId = BitConverter.ToInt32(s, 1);
            BibleVersionId = new Guid(s.Skip(5).Take(16).ToArray());
        }
    }
}
