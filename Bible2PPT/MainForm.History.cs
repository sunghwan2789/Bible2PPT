using Bible2PPT.Data;
using Bible2PPT.PPT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using System.Threading;
using System.Diagnostics;

namespace Bible2PPT
{
    partial class MainForm
    {
        private void InitializeHistoryComponent()
        {
            historyDataGridView.AutoGenerateColumns = false;
            historyCreatedAtColumn.DataPropertyName = nameof(Job.CreatedAt);
            historyBiblesColumn.DataPropertyName = nameof(Job.Bibles);
            historyQueryStringColumn.DataPropertyName = nameof(Job.QueryString);
            historyTemplateBookNameColumn.DataPropertyName = nameof(Job.TemplateBookNameOption);
            historyTemplateBookAbbrColumn.DataPropertyName = nameof(Job.TemplateBookAbbrOption);
            historyTemplateChapterNumberColumn.DataPropertyName = nameof(Job.TemplateChapterNumberOption);
            historySplitChaptersIntoFileColumn.DataPropertyName = nameof(Job.SplitChaptersIntoFiles);

            List<Job> works;
            using (var db = new BibleContext())
            {
                works = db.Jobs
                    .Include(w => w.JobBibles.Select(wb => wb.Bible))
                    .Include(w => w.Result)
                    .OrderByDescending(w => w.Id)
                    .ToList();
                works.ForEach(i => i.Bibles.ForEach(j => j.Source = Source.AvailableSources.First(k => k.Id == j.SourceId)));
            }
            historyDataGridView.DataSource = works;
        }

        private void HistoryDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value)
            {
                case List<Bible> bibles:
                {
                    e.Value = string.Join("\n", bibles.Select(i => $"{i.Source?.Name} - {i.Version}"));
                    e.FormattingApplied = true;
                    break;
                }
                case TemplateTextOptions textOptions:
                {
                    string value;
                    switch (textOptions)
                    {
                        case TemplateTextOptions.Always:
                            value = "항상 보이기";
                            break;
                        case TemplateTextOptions.FirstVerseOfChapter:
                            value = "각 장의 첫 절에만 보이기";
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    e.Value = value;
                    e.FormattingApplied = true;
                    break;
                }
            }
        }

        private void HistoryOpenResultButton_Click(object sender, EventArgs e)
        {
            // 선택한 기록이 없으면 아무 작업도 안함
            if (!(historyDataGridView.CurrentRow?.DataBoundItem is Job history))
            {
                return;
            }

            // 이미 열기 요청을 했으면 경고
            if (workCts.TryGetValue(history.Id, out CancellationTokenSource cts))
            {
                return;
            }

            // 실패한 기록은 다시 만들기 또는
            // 파일을 삭제했을 때도 다시 만들기 => 중점으로
            if (history.Result?.IsCompleted != true)
            {
                return;
            }

            // 성공한 기록은 바로 파일 열기
            if (history.SplitChaptersIntoFiles)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = history.OutputDestination,
                    UseShellExecute = true,
                });
            }
            else
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = history.Result.Output,
                    UseShellExecute = true,
                });
            }
        }

        private void HistoryLoadButton_Click(object sender, EventArgs e)
        {

        }

        private void HistoryDeleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
