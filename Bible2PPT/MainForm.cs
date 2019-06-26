using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bible2PPT
{
    internal partial class MainForm : AssemblyIconForm
    {
        private PPTBuilder builder;

        public MainForm()
        {
            try
            {
                builder = new PPTBuilder();
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

        private void ScaleListViewColumns(ListView listview, SizeF factor)
        {
            foreach (ColumnHeader column in listview.Columns)
            {
                column.Width = (int)Math.Round(column.Width * factor.Width);
            }
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);

            ScaleListViewColumns(booksListView, factor);
        }

        private Button[] Navs => new[]
        {
            buildNav,
            historyNav,
            templatesNav,
            settingsNav,
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
                    target = buildNav;
                    break;
                case nameof(historyMultiPanelPage):
                    target = historyNav;
                    break;
                case nameof(templatesMultiPanelPage):
                    target = templatesNav;
                    break;
                case nameof(settingsMultiPanelPage):
                    target = settingsNav;
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
                case nameof(buildNav):
                    target = buildMultiPanelPage;
                    break;
                case nameof(historyNav):
                    target = historyMultiPanelPage;
                    break;
                case nameof(templatesNav):
                    target = templatesMultiPanelPage;
                    break;
                case nameof(settingsNav):
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
