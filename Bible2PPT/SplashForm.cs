using System.Drawing;
using Bible2PPT.Controls;

namespace Bible2PPT
{
    public partial class SplashForm : AssemblyIconForm
    {
        public SplashForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromStream(Resources.GetStream(@"Icon.png"));
        }
    }
}
