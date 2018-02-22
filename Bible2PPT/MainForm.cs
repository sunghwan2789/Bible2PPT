using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bible2PPT
{
    internal partial class MainForm : Form
    {
        private PPTBuilder builder;
        private DAO dao = new DAO();

        public MainForm()
        {
            try
            {
                builder = new PPTBuilder("Bible2PPT.Template.pptx", AppConfig.TemplatePath);
            }
            catch
            {
                MessageBox.Show(@"마이크로소프트 파워포인트가 설치되어 있나요?", @"프로그램 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            InitializeComponent();

            cmbLongTitle.SelectedIndex = (int) AppConfig.Context.ShowLongTitle;
            cmbShortTitle.SelectedIndex = (int) AppConfig.Context.ShowShortTitle;
            cmbChapNum.SelectedIndex = (int) AppConfig.Context.ShowChapterNumber;
            radEasy.Checked = AppConfig.Context.UseEasyBible;
            chkFragment.Checked = AppConfig.Context.SeperateByChapter;
        }

        private Control[] GetCriticalControls => new Control[]
        {
            lstBible,
            txtSearch,
            radRevision,
            radEasy,
            cmbChapNum,
            cmbLongTitle,
            cmbShortTitle,
            txtKeyword,
            btnMake,
            chkFragment,
        };

        private void ToggleCriticalControls(bool enable, params Control[] except)
        {
            Cursor = enable ? Cursors.Default : Cursors.AppStarting;
            foreach (var i in GetCriticalControls.Except(except))
            {
                i.Enabled = enable;
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            dao.GetBiblesAsync()
                .ContinueWith(t => Invoke(new MethodInvoker(() =>
                {
                    foreach (var bible in t.Result)
                    {
                        var item = lstBible.Items.Add(bible.BibleId);
                        item.SubItems.Add(bible.Title);
                        item.SubItems.Add(bible.ChapterCount.ToString());
                        item.Tag = bible;
                    }

                    txtKeyword.Clear();
                    ToggleCriticalControls(true);
                })), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(t =>
                {
                    MessageBox.Show(@"인터넷에 연결되어 있나요?", @"목록 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }, TaskContinuationOptions.OnlyOnFaulted);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Context.Save();
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
                case Keys.Down:
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

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
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
                if (AppConfig.Context.SeperateByChapter && fd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                destination = fd.SelectedPath;
            }

            btnMake.Text = @"PPT 만드는 중...";
            ToggleCriticalControls(false, btnMake);

            CTS = new CancellationTokenSource();
            PPTBuilderWork work = null;
            Task.Factory.StartNew(() =>
            {
                if (!AppConfig.Context.SeperateByChapter)
                {
                    work = builder.BeginBuild();
                }

                var bibles = dao.GetBiblesAsync().Result;

                foreach (var query in txtKeyword.Text.Split().Select(BibleQuery.ParseQuery))
                {
                    var bible = bibles.FirstOrDefault(i => i.BibleId == query.BibleId);
                    if (bible == null)
                    {
                        throw new EntryPointNotFoundException($@"""{query.BibleId}""에 해당하는 성경이 없습니다.");
                    }

                    var chapters = (query.EndChapterNumber ?? bible.ChapterCount) - query.StartChapterNumber + 1;
                    foreach (var chapNo in Enumerable.Range(query.StartChapterNumber, chapters))
                    {
                        Invoke(new MethodInvoker(() => Text = $"성경2PPT - {bible.Title} {chapNo}장"));

                        if (AppConfig.Context.SeperateByChapter)
                        {
                            work?.Save();
                            var output = Path.Combine(destination, bible.Title, chapNo.ToString("000\\.pptx"));
                            CreateDirectoryIfNotExists(Path.GetDirectoryName(output));
                            work = builder.BeginBuild(output);
                        }

                        var chapter = dao.GetBibleChapterAsync(bible, chapNo).Result;
                        var startVerseNo = chapNo == query.StartChapterNumber ? query.StartVerseNumber : 1;
                        var endVerseNo = chapter.Verses.Count;
                        if (chapNo == query.EndChapterNumber && query.EndVerseNumber != null)
                        {
                            endVerseNo = query.EndVerseNumber.Value;
                        }
                        work.AppendChapter(chapter, startVerseNo, endVerseNo, CTS.Token);
                    }
                }
            }, CTS.Token)
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        work?.QuitAndCleanup();
                        MessageBox.Show(t.Exception.GetBaseException().ToString(), "PPT 만들기 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    work?.Save();
                    if (AppConfig.Context.SeperateByChapter)
                    {
                        Process.Start(destination);
                    }
                    else if (work != null)
                    {
                        Process.Start(work.Output);
                    }
                })
                .ContinueWith(t => Invoke(new MethodInvoker(() =>
                {
                    ToggleCriticalControls(true);
                    btnMake.Text = "PPT 만들기";
                    Text = "성경2PPT";
                })));
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
전1:3     = 전도서 1장 3절
스1:3-9   = 에스라 1장 3절 - 1장 9절
사1:3-3:9 = 이사야 1장 3절 - 3장 9절", txtKeyword, Int16.MaxValue);
        }

        private void cmbLongTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowLongTitle = (TemplateTextOptions) cmbLongTitle.SelectedIndex;
        }

        private void cmbShortTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowShortTitle = (TemplateTextOptions) cmbShortTitle.SelectedIndex;
        }

        private void cmbChapNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowChapterNumber = (TemplateTextOptions) cmbChapNum.SelectedIndex;
        }

        private void radEasy_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.UseEasyBible = radEasy.Checked;
        }

        private void chkFragment_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.SeperateByChapter = chkFragment.Checked;
        }
    }
}