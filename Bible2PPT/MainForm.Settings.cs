using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bible2PPT.Data;

namespace Bible2PPT
{
    partial class MainForm
    {
        private void InitializeSettingsComponent()
        {
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Process.Start(AppConfig.ContactUrl);
        }

        private void CleanCacheButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("진행 중인 작업을 취소하고 프로그램을 다시 시작할까요?", Text, MessageBoxButtons.YesNo))
            {
                using (var db = new BibleContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                        PRAGMA writable_schema = 1;
                        DELETE FROM sqlite_master WHERE type IN ('table', 'index', 'trigger');
                        PRAGMA writable_schema = 0;
                    ");
                    Application.Restart();
                }
            }
        }
    }
}
