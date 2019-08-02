// https://github.com/ennerperez/multipanelcontrol/blob/master/MultiPanelControl/MultiPanelPage.cs
using System;
using System.Windows.Forms;

namespace Bible2PPT.Controls
{
    public class MultiPanelPage : ContainerControl
    {
        public MultiPanelPage()
        {
            base.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Overridden from <see cref="Panel"/>.
        /// </summary>
        /// <remarks>
        /// Since the <see cref="MultiPanelPage"/> exists only
        /// in the context of a <see cref="MultiPanelControl"/>,
        /// it makes sense to always have it fill the
        /// <see cref="MultiPanelControl"/>. Hence, this property
        /// will always return <see cref="DockStyle.Fill"/>
        /// regardless of how it is set.
        /// </remarks>
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Only here so that it shows up in the property panel.
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Overriden from <see cref="Control"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="ControlCollection"/>.
        /// </returns>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ControlCollection(this);
        }

        #region Classes
        public new class ControlCollection : Control.ControlCollection
        {
            /// <summary>
            /// </summary>
            public ControlCollection(Control owner)
                : base(owner)
            {
                if (owner == null || owner.GetType() != typeof(MultiPanelPage))
                    throw new ArgumentNullException("owner", "Tried to create a MultiPanelPage.ControlCollection with a null owner.");
                var c = owner as MultiPanelPage;
                if (c == null)
                    throw new ArgumentException("Tried to create a MultiPanelPage.ControlCollection with a non-MultiPanelPage owner.", "owner");
            }

            /// <summary>
            /// </summary>
            public override void Add(Control value)
            {
                if (value == null)
                    throw new ArgumentNullException("value", "Tried to add a null value to the MultiPanelPage.ControlCollection.");
                var p = value as MultiPanelPage;
                if (p != null)
                    throw new ArgumentException("Tried to add a MultiPanelPage control to the MultiPanelPage.ControlCollection.", "value");
                base.Add(value);
            }
        }
        #endregion

    }
}
