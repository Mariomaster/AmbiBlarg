using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbiBlarg
{
    public partial class SplashScreen : Form
    {
        private int dots = 0;

        public SplashScreen()
        {
            InitializeComponent();
            CenterToScreen();
            nameLabel.Text = Strings.NAME;
            versionLabel.Text = "Version " + Strings.VERSION;
            copyrightLabel.Text = Strings.COPYRIGHT;
        }

        public void updateDots()
        {
            dots++;

            if (dots > 3)
                dots = 0;

            string loadingText = "Loading";

            for (int i = 0; i < dots; i++)
                loadingText += ".";

            loadingLabel.Text = loadingText;
        }
    }
}
