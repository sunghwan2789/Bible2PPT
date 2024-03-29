﻿using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using Bible2PPT.PPT;
using Bible2PPT.Services;
using Bible2PPT.Services.BibleIndexService;
using Bible2PPT.Services.BibleService;
using Bible2PPT.Services.BuildService;
using Bible2PPT.Services.TemplateService;
using Microsoft.EntityFrameworkCore;
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
            Application.SetDefaultFont(new System.Drawing.Font("Gulim", 9));
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
            services.AddBibleIndexService(options => options.UseSqlite("Data Source=bindex-v3.db"));
            services.AddBibleService(
                dbContextOptionsAction: options =>
                    options.UseSqlite(ConfigurationManager.ConnectionStrings["BibleContext"].ConnectionString));
            services.AddBuildService(
                dbContextOptionsAction: options => options.UseSqlite("Data Source=build-v3.db"),
                interopInitializeErrorAction: ex =>
                {
                    MessageBox.Show(
                        $"마이크로소프트 파워포인트가 설치되어 있나요?\n\n자세한 오류: {ex}",
                        @"프로그램 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // TODO: GitHub로 오류 포스팅하도록 안내하기 (전역 예외 처리기 사용)
                    Environment.Exit(0);
                });
            services.AddTemplateService();

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider.UseBibleIndexService();
            ServiceProvider.UseBibleService();
            ServiceProvider.UseBuildService();
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
