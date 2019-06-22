using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bible2PPT
{
    partial class MainForm
    {
        private Control[] CriticalControls => new Control[]
        {
            sourceComboBox,
            bibleComboBox,
            booksListView,
            booksSearchTextBox,
            templateChaperNumberComboBox,
            templateBookNameComboBox,
            templateBookAbbrComboBox,
            versesTextBox,
            buildButton,
            buildFragmentCheckBox,
            chkUseCache,
        };

        private List<Bible> biblesToBuild = new List<Bible>();
        private BindingSource biblesBindingSource;

        private void InitializeBuildComponent()
        {
            // TableLayoutPanel에 포함되면 SplitterWidth가 초기화되는
            // SplitContainer의 특성에 따라 값 다시 설정
            buildSplitContainer.SplitterWidth = 13;

            // DataSource 사용을 위한 기초 설정
            sourceComboBox.SelectedValueChanged -= SourceComboBox_SelectedValueChanged;
            sourceComboBox.ValueMember = nameof(Source.Id);
            sourceComboBox.DisplayMember = nameof(Source.Name);
            sourceComboBox.SelectedValueChanged += SourceComboBox_SelectedValueChanged;

            bibleComboBox.SelectedValueChanged -= BibleComboBox_SelectedValueChanged;
            bibleComboBox.ValueMember = nameof(Bible.Id);
            bibleComboBox.DisplayMember = nameof(Bible.Version);
            bibleComboBox.SelectedValueChanged += BibleComboBox_SelectedValueChanged;

            biblesDataGridView.AutoGenerateColumns = false;
            biblesDataGridView.Columns.AddRange(new[]
            {
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "소스",
                    DataPropertyName = nameof(Bible.Source),
                },
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "성경",
                    DataPropertyName = nameof(Bible.Version),
                },
            });
            biblesBindingSource = new BindingSource
            {
                DataSource = biblesToBuild,
            };
            biblesDataGridView.DataSource = biblesBindingSource;

            // 불러오기
            templateBookNameComboBox.SelectedIndex = (int)AppConfig.Context.ShowLongTitle;
            templateBookAbbrComboBox.SelectedIndex = (int)AppConfig.Context.ShowShortTitle;
            templateChaperNumberComboBox.SelectedIndex = (int)AppConfig.Context.ShowChapterNumber;
            buildFragmentCheckBox.Checked = AppConfig.Context.SeperateByChapter;

            // 소스 목록 초기화
            sourceComboBox.SelectedValueChanged -= SourceComboBox_SelectedValueChanged;
            sourceComboBox.DataSource = Source.AvailableSources;
            sourceComboBox.SelectedItem = null;
            sourceComboBox.SelectedValueChanged += SourceComboBox_SelectedValueChanged;
            // 마지막으로 선택한 소스 불러오기
            sourceComboBox.SelectedValue = AppConfig.Context.BibleSourceId;
        }

        /// <summary>
        /// 선택한 소스의 성경 목록을 가져온다.
        /// </summary>
        private async void SourceComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // 성경 목록을 가져오기 전까지 성경 목록 컨트롤 비활성화
            bibleComboBox.Enabled = false;

            // 현재 소스를 선택하기 전에 선택한 소스의 성경 목록 가져오기 작업을 취소
            if (sourceComboBox.Tag is CancellationTokenSource previousCts)
            {
                previousCts.Cancel();
                sourceComboBox.Tag = null;
            }

            // 소스를 선택하지 않았으면 아무 작업도 안함
            if (!(sourceComboBox.SelectedItem is Source source))
            {
                return;
            }
            
            // 작업을 취소하기 위한 토큰 생성 및 연결
            var cts = new CancellationTokenSource();
            sourceComboBox.Tag = cts;

            // 성경 목록 가져오기
            List<Bible> bibles;
            try
            {
                bibles = await source.GetBiblesAsync();

                // 작업 취소 요청 수리
                cts.Token.ThrowIfCancellationRequested();
            }
            // 올바른 작업 취소 요청 시 아무 작업도 안함
            catch (OperationCanceledException) when (cts.IsCancellationRequested)
            {
                return;
            }
            // TODO: 작업 실패 시 에러 처리 및 컨트롤 활성화
            //catch { }

            // 성경 목록 가져오기를 성공하였으므로 선택한 소스를 기억
            AppConfig.Context.BibleSourceId = source.Id;

            // 성경 목록 초기화
            bibleComboBox.SelectedValueChanged -= BibleComboBox_SelectedValueChanged;
            bibleComboBox.DataSource = bibles;
            bibleComboBox.SelectedItem = null;
            bibleComboBox.SelectedValueChanged += BibleComboBox_SelectedValueChanged;
            // 성경 목록 컨트롤 활성화
            bibleComboBox.Enabled = true;
            // 마지막으로 선택한 성경 불러오기
            bibleComboBox.SelectedValue = AppConfig.Context.BibleVersionId;
        }

        /// <summary>
        /// 선택한 성경을 자동으로 빌드 대상으로 추가한다.
        /// </summary>
        private void BibleComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // 선택한 성경을 기억하고 빌드 대상으로 추가
            if (bibleComboBox.SelectedItem is Bible bible)
            {
                AppConfig.Context.BibleVersionId = bible.Id;
                // 아래 코드는 FormShown 이벤트 발생 후에 작동하므로 사용하지 않음
                // TODO: 빌드 대상 성경 기억 지원 시 주석 해제
                //biblesAddIconButton.PerformClick();
                BiblesAddIconButton_Click(biblesAddIconButton, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 선택한 성경을 빌드 대상으로 추가한다.
        /// </summary>
        private void BiblesAddIconButton_Click(object sender, EventArgs e)
        {
            // 성경을 선택하지 않았으면 오류
            if (!(bibleComboBox.SelectedItem is Bible bible) || !bibleComboBox.Enabled)
            {
                MessageBox.Show("PPT에 사용할 성경을 선택한 다음 다시 누르세요.", "성경2PPT");
                return;
            }

            // 선택한 성경의 빌드 번호를 기억하고
            var buildNumber = biblesToBuild.Count;
            // 빌드 대상에 추가 및 컨트롤에 반영
            biblesToBuild.Add(bible);
            biblesBindingSource.ResetBindings(false);
            // 추가한 성경을 활성화
            biblesDataGridView.CurrentCell = biblesDataGridView.Rows[buildNumber].Cells[0];

            // TODO: 빌드 대상 성경 기억
        }

        /// <summary>
        /// 활성화한 성경을 빌드 대상에서 제거한다.
        /// </summary>
        private void BiblesRemoveIconButton_Click(object sender, EventArgs e)
        {
            // 활성화한 성경이 없으면 아무 작업도 안함
            if (biblesDataGridView.CurrentRow == null)
            {
                return;
            }

            // 활성화한 성경의 빌드 번호를 기억하고
            var buildNumber = biblesDataGridView.CurrentRow.Index;
            // 빌드 대상에서 제거 및 컨트롤에 반영
            biblesToBuild.RemoveAt(buildNumber);
            biblesBindingSource.ResetBindings(false);

            // TODO: 빌드 대상 성경 기억
        }

        private void BiblesDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var brush = new SolidBrush(biblesDataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(
                    $"{e.RowIndex + 1}",
                    e.InheritedRowStyle.Font,
                    brush,
                    e.RowBounds.Location.X + biblesDataGridView.RowHeadersWidth - 3,
                    e.RowBounds.Location.Y + 4,
                    new StringFormat(StringFormatFlags.DirectionRightToLeft));
            }
        }

        private void BooksListView_MouseClick(object sender, MouseEventArgs e)
        {
            AppendShortTitle();
        }

        private void BooksSearchTextBox_Enter(object sender, EventArgs e)
        {
            booksSearchTextBox.Clear();
        }

        private void BooksSearchTextBox_TextChanged(object sender, EventArgs e)
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

        private void BooksSearchTextBox_KeyDown(object sender, KeyEventArgs e)
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

        private void BooksSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AppendShortTitle();
            }
        }

        private void BooksSearchTextBox_Leave(object sender, EventArgs e)
        {
            booksSearchTextBox.Text = @"책 검색...";
        }

        private void VersesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buildButton.PerformClick();
            }
        }

        private void VersesTextBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(@"예) 창    = 창세기 전체
창1       = 창세기 1장 전체
롬1-3     = 로마서 1장 1절 - 3장 전체
레1-3:9   = 레위기 1장 1절 - 3장 9절
전1:3     = 전도서 1장 3절
스1:3-9   = 에스라 1장 3절 - 1장 9절
사1:3-3:9 = 이사야 1장 3절 - 3장 9절", versesTextBox, Int16.MaxValue);
        }

        private void TemplateBookNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowLongTitle = (TemplateTextOptions)templateBookNameComboBox.SelectedIndex;
        }

        private void TemplateBookAbbrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowShortTitle = (TemplateTextOptions)templateBookAbbrComboBox.SelectedIndex;
        }

        private void TemplateChapterNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppConfig.Context.ShowChapterNumber = (TemplateTextOptions)templateChaperNumberComboBox.SelectedIndex;
        }

        private void BuildFragmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Context.SeperateByChapter = buildFragmentCheckBox.Checked;
        }


        private CancellationTokenSource CTS;
        private async void BuildButton_Click(object sender, EventArgs e)
        {
            if (buildButton.Text == @"PPT 만드는 중...")
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

            buildButton.Text = @"PPT 만드는 중...";
            ToggleCriticalControls(false, buildButton);

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
                    Regex.Replace(versesTextBox.Text.Trim(), @"\s+", " ").Split()
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
            buildButton.Text = "PPT 만들기";
            Text = "성경2PPT";
        }

        private void TemplateEditButton_Click(object sender, EventArgs e)
        {
            builder.OpenTemplate();
        }


        private void TemplateEditButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(@"[TITLE]: 긴 제목*
[STITLE]: 짧은 제목*
[CHAP]: 장 번호*
[PARA]: 절 번호
[BODY]: 내용

* 표시: 접미사 사용 가능
예) [CHAP:장] -> n장", templateEditButton, Int16.MaxValue);
        }
    }
}
