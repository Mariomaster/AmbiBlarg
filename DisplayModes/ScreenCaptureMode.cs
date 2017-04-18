using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using AmbiBlarg.CaptureMethods;

namespace AmbiBlarg.DisplayModes
{
    public partial class ScreenCaptureMode : DisplayMode
    {
        private static DXCapture capture_dx;

        private Thread looper;
        private static bool quit;

        public ScreenCaptureMode()
        {
            InitializeComponent();
            name = "Screen Capture";

            capture_dx = new DXCapture(0, new SetIntDelegate(updateCfpslabel));
        }

        public override void _activate()
        {
            capture_dx.start();

            quit = false;
            looper = new Thread(new ThreadStart(loop));
            looper.Start();
        }

        public override void _deactivate()
        {
            quit = true;
            while (looper.IsAlive) { Application.DoEvents(); }

            capture_dx.stop();
        }

        private static void loop()
        {
            while (true)
            {
                if (quit)
                    break;

                int w = 38;
                int h = 22;

                for (int i = 0; i < h; i++)
                {
                    Color pixelColorL = Color.FromArgb(capture_dx.c_array[i * w * 3], capture_dx.c_array[i * w * 3 + 1], capture_dx.c_array[i * w * 3 + 2]);
                    LedManager.setLed(h-i, pixelColorL);

                    Color pixelColorR = Color.FromArgb(capture_dx.c_array[(i*w+w-1) * 3], capture_dx.c_array[(i*w+w-1) * 3 + 1], capture_dx.c_array[(i*w+w-1) * 3 + 2]);
                    LedManager.setLed(i+h+w, pixelColorR);
                }

                for (int i = 1; i < w-1; i++)
                {
                    Color pixelColor = Color.FromArgb(capture_dx.c_array[i * 3], capture_dx.c_array[i * 3 + 1], capture_dx.c_array[i * 3 + 2]);
                    LedManager.setLed(i + h, pixelColor);
                }
            }
        }

        private void updateCfpslabel(int updates)
        {
            string upsText = "Captured Frames: " + updates + " FPS";

            this.Invoke((MethodInvoker)delegate
            {
                cfpsLabel.Text = upsText;
            });
        }
    }
}
