using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bible2PPT.Bibles;
using Bible2PPT.Bibles.Sources;
using Bible2PPT.Data;
using Bible2PPT.PPT;

namespace Bible2PPT
{
    partial class MainForm
    {
        private readonly BindingList<Job> jobHistory = new BindingList<Job>();

        private void InitializeHistoryComponent()
        {
            historyDataGridView.AutoGenerateColumns = false;
            historyCreatedAtColumn.DataPropertyName = nameof(Job.CreatedAt);
            historyBiblesColumn.DataPropertyName = nameof(Job.Bibles);
            historyQueryStringColumn.DataPropertyName = nameof(Job.QueryString);
            historySplitChaptersIntoFileColumn.DataPropertyName = nameof(Job.SplitChaptersIntoFiles);

            using (var db = new BibleContext())
            {
                foreach (var job in db.Jobs
                    .Include(w => w.JobBibles.Select(wb => wb.Bible))
                    .ToList())
                {
                    job.Bibles.ForEach(bible => bible.Source = Source.AvailableSources.FirstOrDefault(source => source.Id == bible.SourceId));
                    jobHistory.Insert(0, job);
                }
            }
            historyDataGridView.DataSource = jobHistory;

            builder.JobQueued += Builder_JobQueued;
            builder.JobProgress += Builder_JobProgress;
            builder.JobCompleted += Builder_JobCompleted;
        }

        private DataGridViewRow FindHistoryDataGridViewRow(Job job)
        {
            foreach (DataGridViewRow row in historyDataGridView.Rows)
            {
                if (row.DataBoundItem == job)
                {
                    return row;
                }
            }
            return null;
        }

        private void Builder_JobQueued(object sender, JobQueuedEventArgs e)
        {
            if (FindHistoryDataGridViewRow(e.Job) == null)
            {
                jobHistory.Insert(0, e.Job);
            }

            FindHistoryDataGridViewRow(e.Job).Cells[historyJobProgress.Name].Value = "대기 중";
            // 취소 가능한지 나타냄
            FindHistoryDataGridViewRow(e.Job).Tag = true;
        }

        private void Builder_JobProgress(object sender, JobProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => Builder_JobProgress(sender, e)));
                return;
            }

            FindHistoryDataGridViewRow(e.Job).Cells[historyJobProgress.Name].Value =
                $"{e.Progress.ToString("p")} {e.Chapters}장 중 {e.ChaptersDone}장";
        }

        private void Builder_JobCompleted(object sender, JobCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => Builder_JobCompleted(sender, e)));
                return;
            }

            // 취소 불가능함을 표시
            FindHistoryDataGridViewRow(e.Job).Tag = null;

            if (e.IsCancelled)
            {
                jobHistory.RemoveAt(FindHistoryDataGridViewRow(e.Job).Index);
            }
            else if (e.IsFaulted)
            {
                FindHistoryDataGridViewRow(e.Job).Cells[historyJobProgress.Name].Value = e.Exception.ToString();
            }
            else
            {
                FindHistoryDataGridViewRow(e.Job).Cells[historyJobProgress.Name].Value = "완료";
                if (autoOpenCheckBox.Checked)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = e.Job.OutputDestination,
                        UseShellExecute = true,
                    });
                }
            }
        }

        private void HistoryDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.Value)
            {
                case List<Bible> bibles:
                {
                    e.Value = string.Join(", ", bibles.Select(i => $"{i.Version}({i.Source?.Name})"));
                    e.FormattingApplied = true;
                    break;
                }
            }
        }

        private void AutoOpenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: 저장
        }

        private void HistoryOpenResultButton_Click(object sender, EventArgs e)
        {
            // 선택한 기록이 없으면 아무 작업도 안함
            if (!(historyDataGridView.CurrentRow?.DataBoundItem is Job job))
            {
                return;
            }

            // 작업 중이면 무시
            if (FindHistoryDataGridViewRow(job).Tag != null)
            {
                MessageBox.Show("PPT 제작 중입니다. 기다려주세요.", "성경2PPT");
                return;
            }

            // 실패한 기록은 다시 만들기 또는
            // 파일을 삭제했을 때도 다시 만들기 => 중점으로
            if (!(File.Exists(job.OutputDestination) || Directory.Exists(job.OutputDestination)))
            {
                if (DialogResult.Yes == MessageBox.Show("PPT 파일이 없습니다. 다시 만들까요?", "성경2PPT", MessageBoxButtons.YesNo))
                {
                    historyLoadButton.PerformClick();
                }
                return;
            }

            // 성공한 기록은 바로 파일 열기
            Process.Start(new ProcessStartInfo
            {
                FileName = job.OutputDestination,
                UseShellExecute = true,
            });
        }

        private void HistoryLoadButton_Click(object sender, EventArgs e)
        {
            if (!(historyDataGridView.CurrentRow?.DataBoundItem is Job job))
            {
                return;
            }

            biblesToBuild.Clear();
            foreach (var bible in job.Bibles)
            {
                biblesToBuild.Add(bible);
            }

            versesTextBox.Text = job.QueryString;
            buildFragmentCheckBox.Checked = job.SplitChaptersIntoFiles;
            templateBookNameComboBox.SelectedItem = (int)job.TemplateBookNameOption;
            templateBookAbbrComboBox.SelectedItem = (int)job.TemplateBookAbbrOption;
            templateChaperNumberComboBox.SelectedItem = (int)job.TemplateChapterNumberOption;

            buildNav.PerformClick();
            versesTextBox.Focus();

        }

        private void HistoryDeleteButton_Click(object sender, EventArgs e)
        {
            if (!(historyDataGridView.CurrentRow?.DataBoundItem is Job job))
            {
                return;
            }

            using (var db = new BibleContext())
            {
                if (db.Jobs.Any(i => i.Id == job.Id))
                {
                    db.Jobs.Attach(job);
                    db.Jobs.Remove(job);
                    db.SaveChanges();
                }
            }

            // 취소 불가능하면 바로 제거
            if (FindHistoryDataGridViewRow(job).Tag == null)
            {
                jobHistory.RemoveAt(FindHistoryDataGridViewRow(job).Index);
            }
            // 취소 가능하면 취소로 제거
            else
            {
                builder.Cancel(job);
            }
        }
    }
}
