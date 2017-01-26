using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bible2PPT
{
    internal partial class Main : Form
    {
        private PPTBuilder builder;
        private MainConfig cfg = new MainConfig(Application.ExecutablePath + ".cfg");
        private DAO dao = new DAO();

        public Main()
        {
            try
            {
                builder = new PPTBuilder("Bible2PPT.Template.pptx", Application.ExecutablePath + ".pptx");
            }
            catch
            {
                MessageBox.Show(@"마이크로소프트 파워포인트가 설치되어 있나요?", @"프로그램 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            InitializeComponent();

            cfg.Load();
            cmbLongTitle.SelectedIndex = cfg.cmbLongTitleIdx;
            cmbShortTitle.SelectedIndex = cfg.cmbShortTitleIdx;
            cmbChapNum.SelectedIndex = cfg.cmbChapNumIdx;
            radEasy.Checked = cfg.radEasyChecked;
            chkFragment.Checked = cfg.chkFragmentChecked;
        }

        private void AlterControl(bool enable, Control except)
        {
            Cursor = enable ? Cursors.Default : Cursors.AppStarting;
            var toAlter = new Control[] {
                lstBible,
                txtSearch,
                radRevision,
                radEasy,
                cmbChapNum,
                cmbLongTitle,
                cmbShortTitle,
                txtKeyword,
                btnMake,
                chkFragment
            };
            foreach (var i in toAlter.Except(new Control[] { except }))
            {
                i.Enabled = enable;
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            dao.getBiblesAsync()
                .ContinueWith(t => Invoke(new MethodInvoker(() =>
                {
                    foreach (var bible in t.Result)
                    {
                        var item = lstBible.Items.Add(bible.shortTitle);
                        item.SubItems.Add(bible.longTitle);
                        item.SubItems.Add(bible.chapterLength.ToString());
                        item.Tag = bible;
                    }

                    txtKeyword.Clear();
                    AlterControl(true, null);
                })), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(t =>
                {
                    MessageBox.Show(@"인터넷에 연결되어 있나요?", @"목록 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }, TaskContinuationOptions.OnlyOnFaulted);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            cfg.cmbLongTitleIdx = cmbLongTitle.SelectedIndex;
            cfg.cmbShortTitleIdx = cmbShortTitle.SelectedIndex;
            cfg.cmbChapNumIdx = cmbChapNum.SelectedIndex;
            cfg.radEasyChecked = radEasy.Checked;
            cfg.chkFragmentChecked = chkFragment.Checked;
            cfg.Save();
        }



        private void AppendShortTitle()
        {
            if (lstBible.SelectedItems.Count > 0)
            {
                txtKeyword.AppendText((txtKeyword.Text.Length > 0 ? " " : "") + lstBible.SelectedItems[0].Text);
                txtKeyword.Focus();
            }
        }

        private void lstBible_MouseClick(object sender, MouseEventArgs e)
        {
            AppendShortTitle();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void SelectBible(ListViewItem bible)
        {
            lstBible.SelectedItems.Clear();
            bible.Selected = true;
            lstBible.TopItem = bible;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                return;
            }

            foreach (ListViewItem bible in lstBible.Items)
            {
                if (bible.SubItems[1].Text.StartsWith(txtSearch.Text))
                {
                    SelectBible(bible);
                    return;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                {
                    e.SuppressKeyPress = true;
                    try
                    {
                        SelectBible(lstBible.Items[lstBible.SelectedIndices[0] - 1]);
                    }
                    catch
                    {
                        if (lstBible.Items.Count > 0)
                        {
                            SelectBible(lstBible.Items[lstBible.Items.Count - 1]);
                        }
                    }
                    break;
                }
                case Keys.Down:
                {
                    e.SuppressKeyPress = true;
                    try
                    {
                        SelectBible(lstBible.Items[lstBible.SelectedIndices[0] + 1]);
                    }
                    catch
                    {
                        if (lstBible.Items.Count > 0)
                        {
                            SelectBible(lstBible.Items[0]);
                        }
                    }
                    break;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AppendShortTitle();
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = @"검색...";
        }




        private void btnTemplate_Click(object sender, EventArgs e)
        {
            builder.OpenTemplate();
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnMake.PerformClick();
            }
        }

        private CancellationTokenSource CTS;

        private void btnMake_Click(object sender, EventArgs e)
        {
            if (btnMake.Text == @"PPT 만드는 중...")
            {
                CTS.Cancel();
                return;
            }

            string destination;
            using (var fd = new FolderBrowserDialog())
            {
                fd.Description = "PPT를 저장할 폴더를 선택하세요.";
                if (chkFragment.Checked && fd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                destination = fd.SelectedPath;
            }

            btnMake.Text = @"PPT 만드는 중...";
            AlterControl(false, btnMake);

            CTS = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
            {
                builder.ApplyConfig(cmbChapNum.SelectedIndex == 0, cmbLongTitle.SelectedIndex == 0, cmbShortTitle.SelectedIndex == 0);
                builder.BeginBuild();

                foreach (var data in
                    txtKeyword.Text.Split()
                        .Select(keyword => Regex.Match(keyword, @"(?<bible>[가-힣]+)(?<range>(?<chapFrom>\d+)(?::(?<paraFrom>\d+))?(?:-(?:(?<chapTo>\d+):)?(?<paraTo>\d+))?)?"))
                        .Where(match => match.Success))
                {
                    Bible bible = null;
                    Invoke(new MethodInvoker(() => bible = (Bible) lstBible.FindItemWithText(data.Groups["bible"].Value).Tag));

                    var chapFrom = 1;
                    var paraFrom = 1;
                    var chapTo = bible.chapterLength;
                    var paraTo = -1;
                    if (!string.IsNullOrEmpty(data.Groups["range"].Value))
                    {
                        chapFrom = Convert.ToInt32(data.Groups["chapFrom"].Value);
                        if (string.IsNullOrEmpty(data.Groups["paraFrom"].Value))
                        {
                            paraFrom = 1;
                            if (string.IsNullOrEmpty(data.Groups["chapTo"].Value))
                            {
                                chapTo = string.IsNullOrEmpty(data.Groups["paraTo"].Value) ?
                                    chapFrom :
                                    Convert.ToInt32(data.Groups["paraTo"].Value);
                                paraTo = -1;
                            }
                            else
                            {
                                chapTo = Convert.ToInt32(data.Groups["chapTo"].Value);
                                paraTo = Convert.ToInt32(data.Groups["paraTo"].Value);
                            }
                        }
                        else
                        {
                            paraFrom = Math.Max(1, Convert.ToInt32(data.Groups["paraFrom"].Value));
                            chapTo = string.IsNullOrEmpty(data.Groups["chapTo"].Value) ?
                                chapFrom :
                                Convert.ToInt32(data.Groups["chapTo"].Value);
                            paraTo = string.IsNullOrEmpty(data.Groups["paraTo"].Value) ?
                                paraFrom :
                                Convert.ToInt32(data.Groups["paraTo"].Value);
                        }
                        chapTo = Math.Min(chapTo, bible.chapterLength);
                    }

                    for (var chapter = chapFrom; chapter <= chapTo; chapter++)
                    {
                        Invoke(new MethodInvoker(() => Text = "성경2PPT - " + bible.longTitle + " " + chapter + "장"));

                        if (!string.IsNullOrEmpty(destination))
                        {
                            builder.CommitBuild();
                            var parent = Path.Combine(destination, bible.longTitle);
                            if (!Directory.Exists(parent))
                            {
                                Directory.CreateDirectory(parent);
                            }
                            builder.BeginBuild(Path.Combine(parent, chapter.ToString("000\\.pptx")));
                        }

                        var content = dao.getBibleChapterAsync(bible.shortTitle, chapter, radRevision.Checked).Result;
                        if (chapter == chapTo && paraTo != -1)
                        {
                            content = content.Take(Math.Min(content.Count(), paraTo));
                        }
                        if (chapter == chapFrom)
                        {
                            content = content.Skip(paraFrom - 1);
                        }
                        builder.AppendChapter(bible, chapter, paraFrom, content, CTS.Token);
                        paraFrom = 1;
                    }
                }
            }, CTS.Token)
                .ContinueWith(t => Invoke(new MethodInvoker(() =>
                {
                    AlterControl(true, btnMake);
                    btnMake.Text = "PPT 만들기";
                    Text = "성경2PPT";

                    builder.CommitBuild();
                })))
                .ContinueWith(t =>
                {
                    builder.OpenLastBuild();
                }, TaskContinuationOptions.NotOnFaulted);
        }


        private void btnTemplate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(@"[TITLE]: 긴 제목*
[STITLE]: 짧은 제목*
[CHAP]: 장 번호*
[PARA]: 절 번호
[BODY]: 내용

* 표시: 접미사 사용 가능
예) [CHAP:장] -> n장", btnTemplate, Int16.MaxValue);
        }

        private void txtKeyword_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(@"예) 창    = 창세기 전체
창1       = 창세기 1장 전체
롬1-3     = 로마서 1장 1절 - 3장 전체
레1-3:9   = 레위기 1장 1절 - 3장 9절
스1:3-9   = 에스라 1장 3절 - 1장 9절
사1:3-3:9 = 이사야 1장 3절 - 3장 9절", txtKeyword, Int16.MaxValue);
        }
    }
}