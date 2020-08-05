using System.Windows.Forms;
using Bible2PPT.Bibles;

namespace Bible2PPT
{
    partial class MainForm
    {
        private void AppendShortTitle()
        {
            if (booksListView.SelectedItems.Count > 0)
            {
                var book = booksListView.SelectedItems[0].Tag as Book;
                versesTextBox.AppendText($"{(versesTextBox.Text.Length > 0 ? " " : "")}{book.Abbreviation}");
                versesTextBox.Focus();
            }
        }

        private void HighlightBookItem(ListViewItem bookItem)
        {
            booksListView.SelectedItems.Clear();
            bookItem.Selected = true;
            booksListView.TopItem = bookItem;
        }
    }
}
