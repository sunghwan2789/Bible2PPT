using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bible2PPT.Bibles;

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
            if (booksListView.SelectedItems.Count > 0)
            {
                var book = booksListView.SelectedItems[0].Tag as Book;
                versesTextBox.AppendText((versesTextBox.Text.Length > 0 ? " " : "") + book.ShortTitle);
                versesTextBox.Focus();
            }
        }

        private void HighlightBookItem(ListViewItem bookItem)
        {
            booksListView.SelectedItems.Clear();
            bookItem.Selected = true;
            booksListView.TopItem = bookItem;
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
