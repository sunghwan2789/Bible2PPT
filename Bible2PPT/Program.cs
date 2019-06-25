using System;
using System.Text;
using System.Windows.Forms;

namespace Bible2PPT
{
    internal static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
