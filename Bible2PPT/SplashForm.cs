using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
