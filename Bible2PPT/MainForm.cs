using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bible2PPT
{
    internal partial class MainForm : AssemblyIconForm
    {
        private PPTBuilder builder;

        private Control[] CriticalControls => new Control[]
        {
            cmbBibleSource,
            cmbBibleVersion,
            lstBible,
            txtSearch,
            cmbChapNum,
            cmbLongTitle,
            cmbShortTitle,
            txtKeyword,
            btnMake,
            chkFragment,
        };

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

            ToggleCriticalControls(false);

            cmbLongTitle.SelectedIndex = (int) AppConfig.Context.ShowLongTitle;
            cmbShortTitle.SelectedIndex = (int) AppConfig.Context.ShowShortTitle;
            cmbChapNum.SelectedIndex = (int) AppConfig.Context.ShowChapterNumber;
            chkFragment.Checked = AppConfig.Context.SeperateByChapter;

            cmbBibleSource.Items.AddRange(BibleSource.AvailableSources);
            cmbBibleSource.SelectedItem = BibleSource.AvailableSources.FirstOrDefault(i => i.SequenceId == AppConfig.Context.BibleSourceSeq);
        }

        private void cmbBibleSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var source = cmbBibleSource.SelectedItem as BibleSource;
            if (source == null)
            {
                ToggleCriticalControls(true);
                throw new IndexOutOfRangeException("올바르지 않은 소스입니다.");
            }

            AppConfig.Context.BibleSourceSeq = cmbBibleSource.SelectedIndex;

            source.GetBiblesAsync().ContinueWith(t => BeginInvoke(new MethodInvoker(() =>
            {
                if (t.IsFaulted)
                {
                    ToggleCriticalControls(true);
                    throw t.Exception;
                }

                cmbBibleVersion.Tag = t.Result;
                cmbBibleVersion.Items.Clear();
                cmbBibleVersion.Items.AddRange(t.Result.ToArray());
                cmbBibleVersion.SelectedItem = t.Result.FirstOrDefault(i => i.SequenceId == AppConfig.Context.BibleVersionSeq);
            })));
        }

        private void cmbBibleVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bible = cmbBibleVersion.SelectedItem as Bible;
            if (bible == null)
            {
                ToggleCriticalControls(true);
                throw new IndexOutOfRangeException("올바르지 않은 성경입니다.");
            }

            AppConfig.Context.BibleVersionSeq = cmbBibleVersion.SelectedIndex;

            bible.Source.GetBooksAsync(bible).ContinueWith(t => BeginInvoke(new MethodInvoker(() =>
            {
                if (t.IsFaulted)
                {
                    ToggleCriticalControls(true);
                    throw t.Exception;
                }

                lstBible.Tag = t.Result;
                lstBible.Items.Clear();
                foreach (var book in t.Result)
                {
                    var item = lstBible.Items.Add(book.Title);
                    item.SubItems.Add(book.ChapterCount.ToString());
                    item.Tag = book;
                }

                ToggleCriticalControls(true);
            })));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Context.Save();
        }




        private void lstBible_MouseClick(object sender, MouseEventArgs e)
        {
            AppendShortTitle();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                return;
            }

            foreach (ListViewItem bookItem in lstBible.Items)
            {
                if (bookItem.Text.StartsWith(txtSearch.Text))
                {
                    HighlightBookItem(bookItem);
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
                        HighlightBookItem(lstBible.Items[lstBible.SelectedIndices[0] - 1]);
                    }
                    catch
                    {
                        if (lstBible.Items.Count > 0)
                        {
                            HighlightBookItem(lstBible.Items[lstBible.Items.Count - 1]);
                        }
                    }
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    try
                    {
                        HighlightBookItem(lstBible.Items[lstBible.SelectedIndices[0] + 1]);
                    }
                    catch
                    {
                        if (lstBible.Items.Count > 0)
                        {
                            HighlightBookItem(lstBible.Items[0]);
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
                    var bible = bibles.FirstOrDefault(i => i.BookId == query.BibleId);
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

        private void chkFragment_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.SeperateByChapter = chkFragment.Checked;
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            Process.Start(AppConfig.ContactUrl);
        }
    }
}