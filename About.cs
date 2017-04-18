using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbiBlarg
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
            nameLabel.Text = Strings.NAME;
            versionLabel.Text = "Version " + Strings.VERSION;
            copyrightLabel.Text = Strings.COPYRIGHT;
        }
    }
}
