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

        private Control[] CriticalControls => new Control[]
        {
            cmbBibleSource,
            cmbBibleVersion,
            lstBooks,
            txtSearch,
            cmbChapNum,
            cmbLongTitle,
            cmbShortTitle,
            txtKeyword,
            btnMake,
            chkFragment,
            chkUseCache,
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

            cmbLongTitle.SelectedIndex = (int) AppConfig.Context.ShowLongTitle;
            cmbShortTitle.SelectedIndex = (int) AppConfig.Context.ShowShortTitle;
            cmbChapNum.SelectedIndex = (int) AppConfig.Context.ShowChapterNumber;
            chkFragment.Checked = AppConfig.Context.SeperateByChapter;
            chkUseCache.Checked = AppConfig.Context.UseCache;

            cmbBibleSource.Items.AddRange(BibleSource.AvailableSources);
            cmbBibleSource.SelectedItem = BibleSource.Find(AppConfig.Context.BibleSourceId);
        }

        private void cmbBibleSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var source = cmbBibleSource.SelectedItem as BibleSource;
            if (source == null)
            {
                cmbBibleVersion.Tag = null;
                cmbBibleVersion.Items.Clear();
                lstBooks.Tag = null;
                lstBooks.Items.Clear();
                return;
            }

            AppConfig.Context.BibleSourceId = source.Id;

            ToggleCriticalControls(false);
            cmbBibleVersion.Tag = null;
            cmbBibleVersion.Items.Clear();
            lstBooks.Tag = null;
            lstBooks.Items.Clear();
            source.GetBiblesAsync().ContinueWith(t => BeginInvoke(new MethodInvoker(() =>
            {
                ToggleCriticalControls(true);

                if (t.IsFaulted)
                {
                    throw t.Exception;
                }

                var bibles = t.Result;
                cmbBibleVersion.Tag = bibles;
                cmbBibleVersion.Items.AddRange(bibles.ToArray());
                cmbBibleVersion.SelectedItem = bibles.FirstOrDefault(i => i.Id == AppConfig.Context.BibleVersionId);
            })));
        }

        private void cmbBibleVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bible = cmbBibleVersion.SelectedItem as BibleVersion;
            if (bible == null)
            {
                ToggleCriticalControls(true);
                throw new EntryPointNotFoundException("사용할 수 없는 성경입니다.");
            }

            AppConfig.Context.BibleVersionId = bible.Id;

            ToggleCriticalControls(false);
            lstBooks.Tag = null;
            lstBooks.Items.Clear();
            bible.Source.GetBooksAsync(bible).ContinueWith(t => BeginInvoke(new MethodInvoker(() =>
            {
                ToggleCriticalControls(true);

                if (t.IsFaulted)
                {
                    throw t.Exception;
                }

                lstBooks.Tag = t.Result;
                foreach (var book in t.Result)
                {
                    var item = lstBooks.Items.Add(book.Title);
                    item.SubItems.Add(book.ChapterCount.ToString());
                    item.Tag = book;
                }
            })));
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Context.Save();
        }




        private void lstBooks_MouseClick(object sender, MouseEventArgs e)
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

            foreach (ListViewItem bookItem in lstBooks.Items)
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
                        HighlightBookItem(lstBooks.Items[lstBooks.SelectedIndices[0] - 1]);
                    }
                    catch
                    {
                        if (lstBooks.Items.Count > 0)
                        {
                            HighlightBookItem(lstBooks.Items[lstBooks.Items.Count - 1]);
                        }
                    }
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    try
                    {
                        HighlightBookItem(lstBooks.Items[lstBooks.SelectedIndices[0] + 1]);
                    }
                    catch
                    {
                        if (lstBooks.Items.Count > 0)
                        {
                            HighlightBookItem(lstBooks.Items[0]);
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

                var books = lstBooks.Tag as List<BibleBook>;
                foreach (var t in
                    Regex.Replace(txtKeyword.Text.Trim(), @"\s+", "").Split()
                        .Select(BibleQuery.ParseQuery)
                        .Select(q => Tuple.Create(q, books.First(b => b.ShortTitle == q.BibleId))).ToList())
                {
                    var query = t.Item1;
                    var book = t.Item2;

                    // TODO: book.chaptercount maybe null
                    foreach (var chapter in
                        book.Chapters.Take(query.EndChapterNumber ?? book.ChapterCount)
                            .Skip(query.StartChapterNumber - 1))
                    {
                        Invoke(new MethodInvoker(() => Text = $"성경2PPT - {book.Title} {chapter.Number}장"));

                        if (AppConfig.Context.SeperateByChapter)
                        {
                            work?.Save();
                            var output = Path.Combine(destination, book.Title, chapter.Number.ToString("000\\.pptx"));
                            CreateDirectoryIfNotExists(Path.GetDirectoryName(output));
                            work = builder.BeginBuild(output);
                        }

                        var startVerseNo = chapter.Number == query.StartChapterNumber ? query.StartVerseNumber : 1;
                        var endVerseNo = chapter.Verses.Count;
                        if (chapter.Number == query.EndChapterNumber && query.EndVerseNumber != null)
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

        private void chkUseCache_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.UseCache = chkUseCache.Checked;
            if (!chkUseCache.Checked)
            {
                BibleDb.Reset();
            }
            cmbBibleSource.SelectedItem = null;
        }
    }
}