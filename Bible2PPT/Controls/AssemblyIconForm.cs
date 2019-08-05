using System.Drawing;
using System.Windows.Forms;

namespace Bible2PPT.Controls
{
    public class AssemblyIconForm : Form
    {
        public AssemblyIconForm()
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
