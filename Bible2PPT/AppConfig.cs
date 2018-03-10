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
        /// Mask: 0b0000_1001,
        /// </summary>
        public TemplateTextOptions ShowLongTitle { get; set; } = TemplateTextOptions.Always;
        
        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0100_0010,
        /// </summary>
        public TemplateTextOptions ShowShortTitle { get; set; } = TemplateTextOptions.Always;

        /// <summary>
        /// Offset: 0,
        /// Mask: 0b1000_0100,
        /// </summary>
        public TemplateTextOptions ShowChapterNumber { get; set; } = TemplateTextOptions.Always;

        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0001_0000,
        /// </summary>
        public bool SeperateByChapter { get; set; } = false;

        /// <summary>
        /// Offset: 0,
        /// Mask: 0b0010_0000,
        /// </summary>
        public bool UseCache { get; set; } = true;

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
            b[0] = Pack((int)ShowLongTitle, 0, 3);
            b[0] |= Pack((int)ShowShortTitle, 1, 6);
            b[0] |= Pack((int)ShowChapterNumber, 2, 7);
            b[0] |= Pack(SeperateByChapter, 4);
            b[0] |= Pack(UseCache, 5);
            BitConverter.GetBytes(BibleSourceId).CopyTo(b, 1);
            BibleVersionId.ToByteArray().CopyTo(b, 5);
            return b;
        }

        protected override void Deserialize(byte[] s)
        {
            ShowLongTitle = (TemplateTextOptions) Unpack(s[0], 0, 3);
            ShowShortTitle = (TemplateTextOptions) Unpack(s[0], 1, 6);
            ShowChapterNumber = (TemplateTextOptions) Unpack(s[0], 2, 7);
            SeperateByChapter = Unpack(s[0], 4) != 0;
            UseCache = Unpack(s[0], 5) != 0;
            BibleSourceId = BitConverter.ToInt32(s, 1);
            BibleVersionId = new Guid(s.Skip(5).Take(16).ToArray());
        }

        private static byte Pack(int obj, params int[] t)
        {
            var ret = 0;
            for (var i = 0; i < t.Length; i++)
            {
                ret |= ((obj & (1 << i)) >> i) << t[i];
            }
            return (byte)ret;
        }

        private static byte Pack(bool obj, params int[] t) => Pack(obj ? 1 : 0, t);

        private static byte Unpack(byte obj, params int[] t)
        {
            var ret = 0;
            for (var i = 0; i < t.Length; i++)
            {
                ret |= ((obj & (1 << t[i])) >> t[i]) << i;
            }
            return (byte)ret;
        }
    }
}
