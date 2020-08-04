// https://github.com/ennerperez/multipanelcontrol/blob/master/MultiPanelControl/MultiPanel.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bible2PPT.Controls
{
    public class MultiPanel : Panel
    {
        public MultiPanelPage SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                _selectedPage = value;
                if (_selectedPage != null)
                {
                    foreach (Control child in Controls)
                    {
                        if (ReferenceEquals(child, _selectedPage))
                            child.Visible = true;
                        else
                            child.Visible = false;
                    }
                    OnSelectedPanelChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnSelectedPanelChanged(EventArgs e)
        {
            SelectedPanelChanged?.Invoke(this, e);
        }

        public event EventHandler SelectedPanelChanged;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            using var br = new SolidBrush(BackColor);
            g.FillRectangle(br, ClientRectangle);
        }

        protected override ControlCollection CreateControlsInstance()
        {
            return new MultiPanelPagesCollection(this);
        }

        private MultiPanelPage _selectedPage;
    }
}
