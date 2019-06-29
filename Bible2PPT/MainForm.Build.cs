using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using Bible2PPT.Data;
using Bible2PPT.PPT;
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
            biblesUpIconButton,
            biblesDownIconButton,
            biblesAddIconButton,
            biblesRemoveIconButton,
            biblesDataGridView,
            templateBookNameComboBox,
            templateBookAbbrComboBox,
            templateChaperNumberComboBox,
            booksSearchTextBox,
            booksListView,
            versesTextBox,
            buildFragmentCheckBox,
        };

        private readonly List<Bible> biblesToBuild = new List<Bible>(9);

        private void InitializeBuildComponent()
        {
            // TableLayoutPanel에 포함되면 SplitterWidth가 초기화되는
            // SplitContainer의 특성에 따라 값 다시 설정
            buildSplitContainer.SplitterWidth = 13;

            using (var db = new BibleContext())
            {
                foreach (var bibleId in AppConfig.Context.BibleToBuild)
                {
                    var bible = db.Bibles.Find(bibleId);
                    if (bible != null)
                    {
                        var source = Source.AvailableSources.FirstOrDefault(i => i.Id == bible.SourceId);
                        if (source != null)
                        {
                            bible.Source = source;
                            biblesToBuild.Add(bible);
                        }
                    }
                }
            }

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
            biblesSourceDataGridViewColumn.DataPropertyName = nameof(Bible.Source);
            biblesBibleDataGridViewColumn.DataPropertyName = nameof(Bible.Version);
            biblesBindingSource.DataSource = biblesToBuild;
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

        #region 빌드 대상 성경 관리

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
        GET_BIBLES:
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
            // 성경 소스가 응답이 없으면 다시 시도
            catch (OperationCanceledException)
            {
                if (DialogResult.No == MessageBox.Show("성경 소스가 응답이 없습니다.\n다시 시도할까요?", "성경2PPT", MessageBoxButtons.YesNo))
                {
                    return;
                }

                goto GET_BIBLES;
            }
            // TODO: 작업 실패 시 오류 처리 및 컨트롤 활성화
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
                // 아래 코드는 FormShown 이벤트 발생 후에 작동하므로 불러오기 시에는 작동 안함
                biblesAddIconButton.PerformClick();
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

            // 선택한 성경의 빌드 순번을 계산하고
            var rank = biblesToBuild.Count;
            // 빌드 대상에 추가 및 컨트롤에 반영
            biblesToBuild.Add(bible);
            biblesBindingSource.ResetBindings(false);
            // 추가한 성경을 활성화
            biblesDataGridView.CurrentCell = biblesDataGridView.Rows[rank].Cells[0];

            BiblesToBuild_Changed();
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

            // 활성화한 성경의 빌드 순번을 기억하고
            var rank = biblesDataGridView.CurrentRow.Index;
            // 빌드 대상에서 제거 및 컨트롤에 반영
            biblesToBuild.RemoveAt(rank);
            biblesBindingSource.ResetBindings(false);

            BiblesToBuild_Changed();
        }

        /// <summary>
        /// 활성화한 성경의 빌드 순번을 높인다.
        /// </summary>
        private void BiblesUpIconButton_Click(object sender, EventArgs e)
        {
            // 활성화한 성경이 없으면 아무 작업도 안함
            if (biblesDataGridView.CurrentRow == null)
            {
                return;
            }

            // 활성화한 성경의 빌드 순번을 기억
            var rank = biblesDataGridView.CurrentRow.Index;
            // 이미 최상위이면 아무 작업도 안함
            if (rank == 0)
            {
                return;
            }

            // 바로 위 성경과 순서를 바꾸고 및 컨트롤에 반영
            biblesToBuild.Insert(rank - 1, biblesToBuild[rank]);
            biblesToBuild.RemoveAt(rank + 1);
            biblesBindingSource.ResetBindings(false);
            biblesDataGridView.CurrentCell = biblesDataGridView.Rows[--rank].Cells[0];

            BiblesToBuild_Changed();
        }

        /// <summary>
        /// 활성화한 성경의 빌드 순번을 낮춘다.
        /// </summary>
        private void BiblesDownIconButton_Click(object sender, EventArgs e)
        {
            // 활성화한 성경이 없으면 아무 작업도 안함
            if (biblesDataGridView.CurrentRow == null)
            {
                return;
            }

            // 활성화한 성경의 빌드 순번을 기억
            var rank = biblesDataGridView.CurrentRow.Index;
            // 이미 최하위이면 아무 작업도 안함
            if (rank == biblesToBuild.Count - 1)
            {
                return;
            }

            // 바로 아래 성경과 순서를 바꾸고 및 컨트롤에 반영
            biblesToBuild.Insert(rank + 2, biblesToBuild[rank]);
            biblesToBuild.RemoveAt(rank);
            biblesBindingSource.ResetBindings(false);
            biblesDataGridView.CurrentCell = biblesDataGridView.Rows[++rank].Cells[0];

            BiblesToBuild_Changed();
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

        private void BiblesToBuild_Changed()
        {
            for (var i = 0; i < 9; i++)
            {
                AppConfig.Context.BibleToBuild[i] =
                    (i < biblesToBuild.Count)
                    ? biblesToBuild[i].Id
                    : -1;
            }
        }

        #endregion

        #region 책 목록 관리

        /// <summary>
        /// 활성화한 성경의 책 목록을 가져온다.
        /// </summary>
        private async void BiblesDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            // 책 목록을 가져오기 전까지 책 목록 컨트롤 비활성화
            booksListView.Enabled = false;

            // 현재 성경을 활성화하기 전에 활성화한 성경의 책 목록 가져오기 작업을 취소
            if (biblesDataGridView.Tag is CancellationTokenSource previousCts)
            {
                previousCts.Cancel();
                biblesDataGridView.Tag = null;
            }

            // 성경을 활성화하지 않았으면 아무 작업도 안함
            if (biblesDataGridView.CurrentRow == null)
            {
                return;
            }

            // 활성화한 성경을 기억
            var bible = biblesToBuild[biblesDataGridView.CurrentRow.Index];

            // 작업을 취소하기 위한 토큰 생성 및 연결
            var cts = new CancellationTokenSource();
            biblesDataGridView.Tag = cts;

            // 책 목록 가져오기
            List<Book> books;
        GET_BOOKS:
            try
            {
                books = await bible.Source.GetBooksAsync(bible);

                // 작업 취소 요청 수리
                cts.Token.ThrowIfCancellationRequested();
            }
            // 올바른 작업 취소 요청 시 아무 작업도 안함
            catch (OperationCanceledException) when (cts.IsCancellationRequested)
            {
                return;
            }
            // 성경 소스가 응답이 없으면 다시 시도
            catch (OperationCanceledException)
            {
                if (DialogResult.No == MessageBox.Show("성경 소스가 응답이 없습니다.\n다시 시도할까요?", "성경2PPT", MessageBoxButtons.YesNo))
                {
                    return;
                }

                goto GET_BOOKS;
            }
            // TODO: 작업 실패 시 오류 처리 및 컨트롤 활성화
            //catch { }

            // 책 목록 초기화
            booksListView.Tag = books;
            booksListView.Items.Clear();
            foreach (var book in books)
            {
                var item = booksListView.Items.Add(book.Title);
                item.SubItems.Add(book.ShortTitle);
                item.Tag = book;
            }
            // 책 목록 컨트롤 활성화
            booksListView.Enabled = true;
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

        #endregion

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

        /// <summary>
        /// 빌드 대상 성경과 구절로 PPT를 만든다.
        /// </summary>
        private async void BuildButton_Click(object sender, EventArgs e)
        {
            // 지금 만드는 중인 PPT 작업을 취소하고 대기
            if (buildButton.Tag is CancellationTokenSource previousCts)
            {
                previousCts.Cancel();
                return;
            }

            // TODO: 빌드 대상 성경이 없으면 아무 작업도 안함
            //if (!biblesToBuild.Any())
            //{
            //    return;
            //}

            // 장별로 PPT 나누기 경로 설정
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

            // PPT를 완성하기 전까지 주요 컨트롤 비활성화
            ToggleCriticalControls(false, buildButton);
            buildButton.Text = "PPT 만드는 중...";


            // 작업을 취소하기 위한 토큰 생성 및 연결
            var cts = new CancellationTokenSource();
            buildButton.Tag = cts;

            var history = new Work
            {
                Bibles = biblesToBuild,
                CreatedAt = DateTime.UtcNow,
                SplitChaptersIntoFiles = AppConfig.Context.SeperateByChapter,
                OutputDestination = destination,
                QueryString = Regex.Replace(versesTextBox.Text.Trim(), @"\s+", " "),
                TemplateBookNameOption = AppConfig.Context.ShowLongTitle,
                TemplateBookAbbrOption = AppConfig.Context.ShowShortTitle,
                TemplateChapterNumberOption = AppConfig.Context.ShowChapterNumber,
            };

            // PPT 만들기
            PPTBuilderWork work = null;
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    if (!history.SplitChaptersIntoFiles)
                    {
                        work = builder.BeginBuild(history);
                    }

                    List<List<Book>> eachBooks;
                GET_BOOKS:
                    try
                    {
                        eachBooks = biblesToBuild.Select(bible => bible.Source.GetBooksAsync(bible)).ToList().Select(i => i.Result).ToList();
                    }
                    catch (OperationCanceledException) when (!cts.IsCancellationRequested)
                    {
                        var answer = DialogResult.No;
                        Invoke(new MethodInvoker(() => answer = MessageBox.Show("성경 소스가 응답이 없습니다.\n다시 시도할까요?", "성경2PPT", MessageBoxButtons.YesNo)));
                        if (answer == DialogResult.No)
                        {
                            throw;
                        }

                        goto GET_BOOKS;
                    }

                    foreach (var query in history.QueryString.Split().Select(BibleQuery.ParseQuery).ToList())
                    {
                        var targetEachBook = eachBooks.Select(books => books.FirstOrDefault(book => book.ShortTitle == query.BibleId)).ToList();

                        // 해당 책이 있는 성경에서 해당 책을 대표로 사용
                        var mainBook = targetEachBook.First(i => i != null);

                        // 해당 책이 없는 성경도 있으므로 주의해서 장 정보 가져오기
                        List<List<Chapter>> eachTargetChapters;
                    GET_CHAPTERS:
                        try
                        {
                            eachTargetChapters = targetEachBook
                                .Select(book => book?.Source.GetChaptersAsync(book)).ToList().Select(i => i?.Result)
                                .Select(i => i ?? new List<Chapter>())
                                .Select(chapters => chapters.Where(chapter =>
                                    (query.EndChapterNumber != null)
                                    ? (chapter.Number >= query.StartChapterNumber) && (chapter.Number <= query.EndChapterNumber)
                                    : (chapter.Number >= query.StartChapterNumber)).ToList())
                                .ToList();
                        }
                        catch (OperationCanceledException) when (!cts.IsCancellationRequested)
                        {
                            var answer = DialogResult.No;
                            Invoke(new MethodInvoker(() => answer = MessageBox.Show("성경 소스가 응답이 없습니다.\n다시 시도할까요?", "성경2PPT", MessageBoxButtons.YesNo)));
                            if (answer == DialogResult.No)
                            {
                                throw;
                            }

                            goto GET_CHAPTERS;
                        }

                        // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
                        var targetEachChapters = new List<IEnumerable<Chapter>>();
                        // GetEnumerator() 반환형이 struct라 값 복사로 무한 반복되기를 예방하기 위해 캐스팅
                        var targetChapterEnumerators = eachTargetChapters.Select(i => (IEnumerator<Chapter>)i.GetEnumerator()).ToList();
                        for (var chapterNumber = query.StartChapterNumber; ;)
                        {
                            // 다음 장이 있는지 확인
                            var moved = new Dictionary<IEnumerator<Chapter>, bool>();
                            var nextChapterNumber = chapterNumber;
                            foreach (var i in targetChapterEnumerators)
                            {
                                if (i.MoveNext())
                                {
                                    moved[i] = true;
                                    nextChapterNumber = Math.Max(nextChapterNumber, i.Current.Number);
                                }
                            }

                            // 현재 장이 마지막이었으면 종료
                            if (!moved.Any())
                            {
                                break;
                            }

                            for (; chapterNumber <= nextChapterNumber; chapterNumber++)
                            {
                                var eachChapter = new List<Chapter>();
                                foreach (var i in targetChapterEnumerators)
                                {
                                    // 범위를 넘어가면 더 페이지가 없음
                                    if (i.Current == null)
                                    {
                                        eachChapter.Add(null);
                                        continue;
                                    }

                                    // 장 번호가 앞서가면 앞 장이 비었음
                                    if (i.Current.Number > chapterNumber)
                                    {
                                        eachChapter.Add(null);
                                        continue;
                                    }

                                    if (!moved[i])
                                    {
                                        i.MoveNext();
                                    }
                                    eachChapter.Add(i.Current);
                                    moved[i] = false;
                                }
                                targetEachChapters.Add(eachChapter);
                            }
                        }

                        foreach (var targetEachChapter in targetEachChapters)
                        {
                            // 해당 장이 있는 성경의 책에서 해당 장을 대표로 사용
                            var mainChapter = targetEachChapter.FirstOrDefault(i => i != null);
                            if (mainChapter == null)
                            {
                                continue;
                            }

                            Invoke(new MethodInvoker(() => builderToolStripStatusLabel.Text = $"{mainBook.Title} {mainChapter.Number}장"));

                            if (history.SplitChaptersIntoFiles)
                            {
                                work?.Save();
                                var output = Path.Combine(history.OutputDestination, mainBook.Title, mainChapter.Number.ToString("000\\.pptx"));
                                CreateDirectoryIfNotExists(Path.GetDirectoryName(output));
                                work = builder.BeginBuild(history, output);
                            }

                            var startVerseNo = (mainChapter.Number == query.StartChapterNumber) ? query.StartVerseNumber : 1;
                            var endVerseNo = (mainChapter.Number == query.EndChapterNumber) ? query.EndVerseNumber : null;
                        GET_VERSES:
                            try
                            {
                                work.AppendChapter(targetEachChapter, startVerseNo, endVerseNo, cts.Token);
                            }
                            catch (OperationCanceledException) when (!cts.IsCancellationRequested)
                            {
                                var answer = DialogResult.No;
                                Invoke(new MethodInvoker(() => answer = MessageBox.Show("성경 소스가 응답이 없습니다.\n다시 시도할까요?", "성경2PPT", MessageBoxButtons.YesNo)));
                                if (answer == DialogResult.No)
                                {
                                    throw;
                                }

                                goto GET_VERSES;
                            }
                        }
                    }
                });
            }
            // 올바른 작업 취소 요청 시 오류 무시
            catch (OperationCanceledException) { }
            // 작업 실패 시 작업 중지
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
                // 토큰 정리
                buildButton.Tag = null;
            }

            // 작업을 성공하였으면 PPT 열기
            if (work != null)
            {
                work.Save();
                if (history.SplitChaptersIntoFiles)
                {
                    Process.Start(history.OutputDestination);
                }
                else
                {
                    Process.Start(work.Output);
                }
            }

            // 주요 컨트롤 활성화
            ToggleCriticalControls(true);
            buildButton.Text = "PPT 만들기";
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
