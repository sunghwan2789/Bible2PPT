using Bible2PPT.Bibles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bible2PPT
{
    partial class MainForm
    {
        private void ToggleCriticalControls(bool enable, params Control[] except)
        {
            Cursor = enable ? Cursors.Default : Cursors.AppStarting;
            foreach (var i in CriticalControls.Except(except))
            {
                i.Enabled = enable;
            }
        }

        private void AppendShortTitle()
        {
            if (lstBible.SelectedItems.Count > 0)
            {
                var book = lstBible.SelectedItems[0].Tag as BibleBook;
                txtKeyword.AppendText((txtKeyword.Text.Length > 0 ? " " : "") + book.ShortTitle);
                txtKeyword.Focus();
            }
        }

        private void HighlightBookItem(ListViewItem bookItem)
        {
            lstBible.SelectedItems.Clear();
            bookItem.Selected = true;
            lstBible.TopItem = bookItem;
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
