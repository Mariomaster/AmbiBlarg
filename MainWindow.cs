using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using AmbiBlarg.DisplayModes;
using System.Diagnostics;
using System.Globalization;

namespace AmbiBlarg
{
    public delegate void SetTextDelegate(string text);
    public delegate void SetIntDelegate(int value);

    public partial class MainWindow : Form
    {
        private List<DisplayMode> modes;

        public MainWindow()
        {
            InitializeComponent();
            CenterToScreen();
            Text = Strings.NAME;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            bool quitSplash = false;

            Thread myThread = new Thread(delegate ()
            {
                SplashScreen splash = new SplashScreen();
                splash.Show();
                Application.DoEvents();

                Stopwatch s = new Stopwatch();
                s.Start();

                while (!quitSplash)
                {
                    if (s.ElapsedMilliseconds >= 500)
                    {
                        splash.updateDots();
                        s.Restart();
                    }
                    Application.DoEvents();
                }
            });
            myThread.Start();

            init();

            quitSplash = true;
            while (myThread.IsAlive) { Thread.Sleep(10); }

            loadLastMode();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            cleanUp();
        }

        private void init()
        {
            LedManager.init();
            LedManager.direction = true;
            lightEnabled.Checked = Properties.Settings.Default.lightEnabled;
            LedManager.enabled = lightEnabled.Checked;
            ArduinoCommunication.init(setDeviceStatus);

            modes = new List<DisplayMode>();
            tabControl.SelectedIndexChanged -= tabControl_SelectedIndexChanged;

            addModeTab(new StaticColorMode());
            addModeTab(new MusicMode());
            addModeTab(new ScreenCaptureMode());
        }

        private void cleanUp()
        {
            Properties.Settings.Default.lastMode = getActiveModeIndex();

            foreach (DisplayMode mode in modes)
            {
                mode.deactivate();
                mode.cleanUp();
            }

            LedManager.setColor(Color.Black);

            Thread.Sleep(30);
            ArduinoCommunication.cleanUp();

            Properties.Settings.Default.ledCount = LedManager.ledCount;
            Properties.Settings.Default.lightEnabled = LedManager.enabled;
            Properties.Settings.Default.Save();
        }

        private void addModeTab(DisplayMode mode)
        {
            mode.Dock = DockStyle.Fill;
            modes.Add(mode);

            TabPage tab = new TabPage(mode.getName());
            tab.Controls.Add(mode);

            IntPtr h = tabControl.Handle;
            tabControl.TabPages.Insert(modes.IndexOf(mode), tab);
        }

        private int getActiveModeIndex()
        {
            foreach (DisplayMode mode in modes)
            {
                if (mode.isActive())
                    return modes.IndexOf(mode);
            }
            return -1;
        }

        private bool modeIndexExists(int index)
        {
            if (modes.Count == 0)
                return false;

            if (index >= 0 && index < modes.Count)
                return true;

            return false;
        }

        private void loadLastMode()
        {
            if (modeIndexExists(Properties.Settings.Default.lastMode))
                tabControl.SelectedIndex = Properties.Settings.Default.lastMode;
            else
                tabControl.SelectedIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            tabControl_SelectedIndexChanged(tabControl, new EventArgs());
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex > modes.Count-1)
                return;

            int activeMode = getActiveModeIndex();

            if (modes[tabControl.SelectedIndex].isActive())
                return;

            if (activeMode >= 0)
                modes[activeMode].deactivate();

            LedManager.setColor(Color.Black);

            modes[tabControl.SelectedIndex].activate();
        }

        private void setDeviceStatus(string text)
        {
            string status = "Device status: " + text;

            this.Invoke((MethodInvoker)delegate
            {
                deviceStatusLabel.Text = status;
            });
        }

        private void lightEnabled_CheckedChanged(object sender, EventArgs e)
        {
            LedManager.enabled = lightEnabled.Checked;
        }
    }
}
