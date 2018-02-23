using System.Drawing;
using System.Windows.Forms;

namespace Bible2PPT
{
    public class AssemblyIconForm : Form
    {
        public AssemblyIconForm()
        {
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
