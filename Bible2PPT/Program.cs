using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;

namespace Bible2PPT
{
    static class Program
    {
        static IServiceProvider ServiceProvider { get; set; }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            new Startup().Run(args);
        }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<SplashForm>();
            services.AddTransient<MainForm>();

            ServiceProvider = services.BuildServiceProvider();
        }

        class Startup : WindowsFormsApplicationBase
        {
            protected override void OnCreateSplashScreen()
            {
                SplashScreen = ServiceProvider.GetService<SplashForm>();
            }

            protected override void OnCreateMainForm()
            {
                MainForm = ServiceProvider.GetRequiredService<MainForm>();
            }
        }
    }
}
