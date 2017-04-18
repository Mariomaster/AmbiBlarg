using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbiBlarg.DisplayModes
{
    public partial class StaticColorMode : DisplayMode
    {
        public StaticColorMode()
        {
            InitializeComponent();
            name = "Static Color";

            colorEditor.ShowAlphaChannel = false;

            colorEditorManager.Color = Properties.Settings.Default.lastStaticColor;
            colorPanel.BackColor = colorEditorManager.Color;
        }

        public override void cleanUp()
        {
            Properties.Settings.Default.lastStaticColor = colorEditorManager.Color;
        }

        public override void _activate()
        {
            LedManager.setColor(colorEditorManager.Color);
        }

        private void colorEditorManager_ColorChanged(object sender, EventArgs e)
        {
            if (!active)
                return;

            colorPanel.BackColor = colorEditorManager.Color;
            colorPanel.Update();
            LedManager.setColor(colorEditorManager.Color);
        }
    }
}
