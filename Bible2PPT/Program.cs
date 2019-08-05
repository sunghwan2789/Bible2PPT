using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Text;
using System.Windows.Forms;

namespace Bible2PPT
{
    internal static class Program
    {
        class Startup : WindowsFormsApplicationBase
        {
            protected override void OnCreateSplashScreen()
            {
                SplashScreen = new SplashForm();
            }

            protected override void OnCreateMainForm()
            {
                MainForm = new MainForm();
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Startup().Run(args);
        }
    }
}
