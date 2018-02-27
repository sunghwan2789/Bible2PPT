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
            if (lstBooks.SelectedItems.Count > 0)
            {
                var book = lstBooks.SelectedItems[0].Tag as BibleBook;
                txtKeyword.AppendText((txtKeyword.Text.Length > 0 ? " " : "") + book.ShortTitle);
                txtKeyword.Focus();
            }
        }

        private void HighlightBookItem(ListViewItem bookItem)
        {
            lstBooks.SelectedItems.Clear();
            bookItem.Selected = true;
            lstBooks.TopItem = bookItem;
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
