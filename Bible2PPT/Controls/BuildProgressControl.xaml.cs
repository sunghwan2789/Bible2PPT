using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bible2PPT.PPT;

namespace Bible2PPT.Controls
{
    /// <summary>
    /// Interaction logic for BuildProgressControl.xaml
    /// </summary>
    partial class BuildProgressControl : UserControl
    {
        public delegate void BuildEndEventHandler(object sender, EventArgs e);
        public event BuildEndEventHandler OnBuildEnd;

        public BuildProgress Job { get; set; }


        public BuildProgressControl()
        {
            InitializeComponent();
        }
    }
}
