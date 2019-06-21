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
            sourceComboBox,
            bibleComboBox,
            booksListView,
            booksSearchTextBox,
            templateChaperNumberComboBox,
            templateLongTitleComboBox,
            templateShortTitleComboBox,
            makeKeywordTextBox,
            makeButton,
            makeFragmentCheckBox,
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
            // TableLayoutPanel에 포함되면 SplitterWidth가 초기화되는
            // SplitContainer의 특성에 따라 값 다시 설정
            makeSplitContainer.SplitterWidth = 13;
            // TODO: 마지막 페이지 기억하기
            mainMultiPanel.SelectedPage = makeMultiPanelPage;

            templateLongTitleComboBox.SelectedIndex = (int) AppConfig.Context.ShowLongTitle;
            templateShortTitleComboBox.SelectedIndex = (int) AppConfig.Context.ShowShortTitle;
            templateChaperNumberComboBox.SelectedIndex = (int) AppConfig.Context.ShowChapterNumber;
            makeFragmentCheckBox.Checked = AppConfig.Context.SeperateByChapter;
            chkUseCache.Checked = AppConfig.Context.UseCache;

            sourceComboBox.Items.AddRange(BibleSource.AvailableSources);
            sourceComboBox.SelectedItem = BibleSource.AvailableSources.FirstOrDefault(i => i.Id == AppConfig.Context.BibleSourceId);
        }

        private async void cmbBibleSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var source = sourceComboBox.SelectedItem as BibleSource;
            if (source == null)
            {
                bibleComboBox.Tag = null;
                bibleComboBox.Items.Clear();
                booksListView.Tag = null;
                booksListView.Items.Clear();
                return;
            }

            AppConfig.Context.BibleSourceId = source.Id;

            ToggleCriticalControls(false);
            bibleComboBox.Tag = null;
            bibleComboBox.Items.Clear();
            booksListView.Tag = null;
            booksListView.Items.Clear();

            try
            {
                var bibles = await source.GetBiblesAsync();
                bibleComboBox.Tag = bibles;
                bibleComboBox.Items.AddRange(bibles.ToArray());
                bibleComboBox.SelectedItem = bibles.FirstOrDefault(i => i.Id == AppConfig.Context.BibleVersionId);
            }
            finally
            {
                ToggleCriticalControls(true);
            }
        }

        private async void cmbBibleVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bible = bibleComboBox.SelectedItem as Bibles.Bible;
            if (bible == null)
            {
                ToggleCriticalControls(true);
                throw new EntryPointNotFoundException("사용할 수 없는 성경입니다.");
            }

            AppConfig.Context.BibleVersionId = bible.Id;

            ToggleCriticalControls(false);
            booksListView.Tag = null;
            booksListView.Items.Clear();

            try
            {
                var books = await bible.Source.GetBooksAsync(bible);
                booksListView.Tag = books;
                foreach (var book in books)
                {
                    var item = booksListView.Items.Add(book.Title);
                    item.SubItems.Add(book.ChapterCount.ToString());
                    item.Tag = book;
                }
            }
            finally
            {
                ToggleCriticalControls(true);
            }
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
            booksSearchTextBox.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (booksSearchTextBox.Text.Length == 0)
            {
                return;
            }

            foreach (ListViewItem bookItem in booksListView.Items)
            {
                if (bookItem.Text.StartsWith(booksSearchTextBox.Text))
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
                        HighlightBookItem(booksListView.Items[booksListView.SelectedIndices[0] - 1]);
                    }
                    catch
                    {
                        if (booksListView.Items.Count > 0)
                        {
                            HighlightBookItem(booksListView.Items[booksListView.Items.Count - 1]);
                        }
                    }
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    try
                    {
                        HighlightBookItem(booksListView.Items[booksListView.SelectedIndices[0] + 1]);
                    }
                    catch
                    {
                        if (booksListView.Items.Count > 0)
                        {
                            HighlightBookItem(booksListView.Items[0]);
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
            booksSearchTextBox.Text = @"검색...";
        }




        private void btnTemplate_Click(object sender, EventArgs e)
        {
            builder.OpenTemplate();
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                makeButton.PerformClick();
            }
        }

        private CancellationTokenSource CTS;

        private async void btnMake_Click(object sender, EventArgs e)
        {
            if (makeButton.Text == @"PPT 만드는 중...")
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

            makeButton.Text = @"PPT 만드는 중...";
            ToggleCriticalControls(false, makeButton);

            CTS = new CancellationTokenSource();
            PPTBuilderWork work = null;
            try
            {
                if (!AppConfig.Context.SeperateByChapter)
                {
                    work = builder.BeginBuild();
                }

                var books = booksListView.Tag as List<Book>;
                foreach (var t in
                    Regex.Replace(makeKeywordTextBox.Text.Trim(), @"\s+", " ").Split()
                        .Select(BibleQuery.ParseQuery)
                        .Select(q => Tuple.Create(q, books.First(b => b.ShortTitle == q.BibleId))).ToList())
                {
                    var query = t.Item1;
                    var book = t.Item2;

                    var chapters = await book.Source.GetChaptersAsync(book);
                    foreach (var chapter in
                        chapters.Where(i =>
                            (query.EndChapterNumber != null)
                            ? (i.Number >= query.StartChapterNumber) && (i.Number <= query.EndChapterNumber)
                            : (i.Number >= query.StartChapterNumber)))
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
                        var endVerseNo = (await chapter.Source.GetVersesAsync(chapter)).Max(i => i.Number);
                        if (chapter.Number == query.EndChapterNumber && query.EndVerseNumber != null)
                        {
                            endVerseNo = query.EndVerseNumber.Value;
                        }
                        work.AppendChapter(chapter, startVerseNo, endVerseNo, CTS.Token);
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (work != null)
                {
                    work.QuitAndCleanup();
                    work = null;
                }
                MessageBox.Show(ex.ToString(), "PPT 만들기 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (work != null)
                {
                    work.Save();
                    if (AppConfig.Context.SeperateByChapter)
                    {
                        Process.Start(destination);
                    }
                    else
                    {
                        Process.Start(work.Output);
                    }
                }
            }

            ToggleCriticalControls(true);
            makeButton.Text = "PPT 만들기";
            Text = "성경2PPT";
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
사1:3-3:9 = 이사야 1장 3절 - 3장 9절", makeKeywordTextBox, Int16.MaxValue);
        }

        private void cmbLongTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowLongTitle = (TemplateTextOptions) templateLongTitleComboBox.SelectedIndex;
        }

        private void cmbShortTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowShortTitle = (TemplateTextOptions) templateShortTitleComboBox.SelectedIndex;
        }

        private void cmbChapNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowChapterNumber = (TemplateTextOptions) templateChaperNumberComboBox.SelectedIndex;
        }

        private void chkFragment_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.SeperateByChapter = makeFragmentCheckBox.Checked;
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
            makeNav,
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
                case nameof(makeMultiPanelPage):
                    target = makeNav;
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
                case nameof(makeNav):
                    target = makeMultiPanelPage;
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