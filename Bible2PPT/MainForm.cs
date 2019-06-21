using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // TODO: 마지막 페이지 기억하기
            mainMultiPanel.SelectedPage = buildMultiPanelPage;

            chkUseCache.Checked = AppConfig.Context.UseCache;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Context.Save();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            builder.OpenTemplate();
        }


        private void btnTemplate_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(@"[TITLE]: 긴 제목*
[STITLE]: 짧은 제목*
[CHAP]: 장 번호*
[PARA]: 절 번호
[BODY]: 내용

* 표시: 접미사 사용 가능
예) [CHAP:장] -> n장", btnTemplate, Int16.MaxValue);
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            Process.Start(AppConfig.ContactUrl);
        }

        private void chkUseCache_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.UseCache = chkUseCache.Checked;
            if (!chkUseCache.Checked)
            {
                BibleDb.Reset();
            }
            sourceComboBox.SelectedItem = null;
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
            Button target;
            // 현재 페이지와 연결된 Nav 찾기
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
            MultiPanelPage target;
            // 현재 Nav와 연결된 페이지 찾기
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