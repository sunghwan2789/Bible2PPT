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

namespace Bible2PPT
{
    partial class MainForm
    {
        private void InitializeHistoryComponent()
        {
            dataGridView1.AutoGenerateColumns = false;
            Column1.DataPropertyName = nameof(Work.CreatedAt);
            Column2.DataPropertyName = nameof(Work.Bibles);
            Column3.DataPropertyName = nameof(Work.QueryString);
            Column4.DataPropertyName = nameof(Work.TemplateBookNameOption);
            Column5.DataPropertyName = nameof(Work.TemplateBookAbbrOption);
            Column6.DataPropertyName = nameof(Work.TemplateChapterNumberOption);
            Column7.DataPropertyName = nameof(Work.SplitChaptersIntoFiles);

            List<Work> works;
            using (var db = new BibleContext())
            {
                works = db.Works
                    .Include(w => w.WorkBibles.Select(wb => wb.Bible))
                    .OrderByDescending(w => w.Id)
                    .ToList();
                works.ForEach(i => i.Bibles.ForEach(j => j.Source = Source.AvailableSources.First(k => k.Id == j.SourceId)));
            }
            dataGridView1.DataSource = works;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    }
}
