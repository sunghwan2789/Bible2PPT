using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bible2PPT
{
    partial class MainForm
    {
        private void InitializeSettingsComponent()
        {
            chkUseCache.Checked = AppConfig.Context.UseCache;
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
            //sourceComboBox.SelectedItem = null;
        }
    }
}
