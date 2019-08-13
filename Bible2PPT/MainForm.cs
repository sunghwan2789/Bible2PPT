using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using Bible2PPT.Controls;
using Bible2PPT.PPT;

namespace Bible2PPT
{
    internal partial class MainForm : AssemblyIconForm
    {
        private readonly Builder builder;

        private readonly Dictionary<int, CancellationTokenSource> workCts = new Dictionary<int, CancellationTokenSource>();

        public MainForm()
        {
            try
            {
                builder = new Builder();
            }
            catch
            {
                MessageBox.Show(@"마이크로소프트 파워포인트가 설치되어 있나요?", @"프로그램 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

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
            // 현재 페이지와 연결된 Nav를 찾고
            Button target;
            switch (mainMultiPanel.SelectedPage.Name)
            {
                case nameof(buildMultiPanelPage):
                    target = buildNavButton;
                    break;
                case nameof(historyMultiPanelPage):
                    target = historyNavButton;
                    break;
                case nameof(templatesMultiPanelPage):
                    target = templatesNavButton;
                    break;
                case nameof(settingsMultiPanelPage):
                    target = settingsNavButton;
                    break;
                default:
                    throw new NotImplementedException(mainMultiPanel.SelectedPage.Name);
            }
            // 연결된 Nav만 비활성화
            foreach (var nav in Navs)
            {
                nav.Enabled = true;
            }
            target.Enabled = false;
        }

        private void Nav_Click(object sender, EventArgs e)
        {
            // 해당 Nav와 연결된 페이지를 찾고
            MultiPanelPage target;
            switch ((sender as Control).Name)
            {
                case nameof(buildNavButton):
                    target = buildMultiPanelPage;
                    break;
                case nameof(historyNavButton):
                    target = historyMultiPanelPage;
                    break;
                case nameof(templatesNavButton):
                    target = templatesMultiPanelPage;
                    break;
                case nameof(settingsNavButton):
                    target = settingsMultiPanelPage;
                    break;
                default:
                    throw new NotImplementedException((sender as Control).Name);
            }
            // 연결된 페이지 활성화
            mainMultiPanel.SelectedPage = target;
        }
    }
}
