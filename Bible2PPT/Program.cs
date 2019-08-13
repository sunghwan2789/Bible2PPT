using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Startup().Run(args);
        }
    }
}
