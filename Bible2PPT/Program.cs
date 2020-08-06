using System;
using System.Configuration;
using System.Windows.Forms;
using Bible2PPT.Data;
using Bible2PPT.PPT;
using Bible2PPT.Services;
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
            services.AddSingleton<HiddenPowerPoint>(_ =>
            {
                try
                {
                    return new HiddenPowerPoint();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"마이크로소프트 파워포인트가 설치되어 있나요?\n\n자세한 오류: {ex}",
                        @"프로그램 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // TODO: GitHub로 오류 포스팅하도록 안내하기 (전역 예외 처리기 사용)
                    Environment.Exit(0);
                    throw;
                }
            });
            services.AddTransient<Builder>();
            // TODO: EF Core 사용하면 AddDbContextPool로 바꾸기
            services.AddScoped<BibleContext>(_ =>
                new BibleContext(ConfigurationManager.ConnectionStrings["BibleContext"].ConnectionString));
            services.AddTransient<BibleService>();
            services.AddTransient<ZippedBibleService>();

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
