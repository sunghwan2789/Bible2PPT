using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bible2PPT.Controls
{
    public class AssemblyIconForm : Form
    {
        private static readonly IntPtr _iconHandle;

        static AssemblyIconForm()
        {
            unsafe
            {
                fixed (char* iconPath = Application.ExecutablePath)
                {
                    ushort iconId = 0;
                    var iconHandle = Windows.Win32.PInvoke.ExtractAssociatedIcon(null, iconPath, ref iconId);
                    var success = false;
                    iconHandle.DangerousAddRef(ref success);
                    _iconHandle = iconHandle.DangerousGetHandle();
                }
            }
        }

        public AssemblyIconForm()
        {
            Icon = Icon.FromHandle(_iconHandle);
        }
    }
}
