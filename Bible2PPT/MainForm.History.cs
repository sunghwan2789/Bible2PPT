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
            }
            dataGridView1.DataSource = works;
        }
    }
}
