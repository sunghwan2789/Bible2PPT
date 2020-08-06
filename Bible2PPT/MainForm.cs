using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Bible2PPT.Controls;
using Bible2PPT.PPT;
using Bible2PPT.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT
{
    internal partial class MainForm : AssemblyIconForm
    {
        private Builder Builder { get; }
        private BibleService BibleService { get; }
        private IServiceScopeFactory ScopeFactory { get; }

        private readonly Dictionary<int, CancellationTokenSource> workCts = new Dictionary<int, CancellationTokenSource>();

        public MainForm(Builder builder, BibleService bibleService, IServiceScopeFactory scopeFactory)
        {
            Builder = builder;
            BibleService = bibleService;
            ScopeFactory = scopeFactory;

            InitializeComponent();
            InitializeBuildComponent();
            InitializeHistoryComponent();
            InitializeTemplatesComponent();
            InitializeSettingsComponent();

            // TODO: 마지막 페이지 기억하기
            mainMultiPanel.SelectedPage = buildMultiPanelPage;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Context.Save();
        }

        private Button[] Navs => new[]
        {
            buildNavButton,
            historyNavButton,
            templatesNavButton,
            settingsNavButton,
        };

        private void MainMultiPanel_SelectedPanelChanged(object sender, EventArgs e)
        {
            // 제목 표시줄에 페이지 제목 추가
            Text = $"{mainMultiPanel.SelectedPage.Text} - 성경2PPT";
            var targetButton = mainMultiPanel.SelectedPage.Name switch
            {
                nameof(buildMultiPanelPage) => buildNavButton,
                nameof(historyMultiPanelPage) => historyNavButton,
                nameof(templatesMultiPanelPage) => templatesNavButton,
                nameof(settingsMultiPanelPage) => settingsNavButton,
                _ => throw new NotImplementedException(mainMultiPanel.SelectedPage.Name),
            };
            // 연결된 Nav만 비활성화
            foreach (var nav in Navs)
            {
                nav.Enabled = true;
            }
            targetButton.Enabled = false;
        }

        private void Nav_Click(object sender, EventArgs e)
        {
            var targetPage = (sender as Control).Name switch
            {
                nameof(buildNavButton) => buildMultiPanelPage,
                nameof(historyNavButton) => historyMultiPanelPage,
                nameof(templatesNavButton) => templatesMultiPanelPage,
                nameof(settingsNavButton) => settingsMultiPanelPage,
                _ => throw new NotImplementedException((sender as Control).Name),
            };
            // 연결된 페이지 활성화
            mainMultiPanel.SelectedPage = targetPage;
        }
    }
}
