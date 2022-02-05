using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Bible2PPT
{
    partial class MainForm
    {
        private void InitializeSettingsComponent()
        {
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = AppConfig.ContactUrl,
                UseShellExecute = true,
            });
        }

        private async void CleanCacheButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("진행 중인 작업을 취소하고 프로그램을 다시 시작할까요?", Text, MessageBoxButtons.YesNo))
            {
                await _bibleService.ClearCachesAsync();
                // TODO: clear job history / alter online id as key
                Application.Restart();
            }
        }
    }
}
