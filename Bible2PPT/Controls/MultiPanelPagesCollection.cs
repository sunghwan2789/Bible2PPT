// https://github.com/ennerperez/multipanelcontrol/blob/master/MultiPanelControl/MultiPanelPagesCollection.cs
using System;
using System.Windows.Forms;

namespace Bible2PPT.Controls
{
    public class MultiPanelPagesCollection : Control.ControlCollection
    {
        public MultiPanelPagesCollection(Control owner)
            : base(owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner", "Tried to create a MultiPanelPagesCollection with a null owner.");
            _owner = owner as MultiPanel;
            if (_owner == null)
                throw new ArgumentException("Tried to create a MultiPanelPagesCollection with a non-MultiPanel owner.", "owner");
        }

        public override void Add(Control value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Tried to add a null value to the MultiPanelPagesCollection.");
            var p = value as MultiPanelPage;
            if (p == null)
                throw new ArgumentException("Tried to add a non-MultiPanelPage control to the MultiPanelPagesCollection", "value");
            p.SendToBack();
            base.Add(p);
        }

        public override void AddRange(Control[] controls)
        {
            foreach (MultiPanelPage p in controls)
                Add(p);
        }

        public override void Remove(Control value)
        {
            base.Remove(value);
        }

        public override int IndexOfKey(string key)
        {
            var ctrl = base[key];
            return GetChildIndex(ctrl);
        }

        private MultiPanel _owner;
    }
}
