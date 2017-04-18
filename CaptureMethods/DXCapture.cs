using System;
using System.Windows.Forms;
using System.Threading;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using System.Diagnostics;

namespace AmbiBlarg.CaptureMethods
{
    public class DXCapture : CaptureMethod
    {
        private Device d;
        int s_width, s_height;

        SetIntDelegate setUPSDelegate;

        public DXCapture(int c_monitor, SetIntDelegate setUPSDelegate)
        {
            int c_width = 38; int c_height = 22;

            this.setUPSDelegate = setUPSDelegate;

            setMonitor(c_monitor);
            setCaptureQuality(c_width, c_height);

            _isRunning = false;
        }

        private Thread looper;
        private bool quit = false;
        public override void start()
        {
            quit = false;
            looper = new Thread(new ThreadStart(loop));
            looper.Start();
        }

        public override void stop()
        {
            quit = true;
            while (looper.IsAlive) { Application.DoEvents(); }
        }

        public override void setMonitor(int c_monitor)
        {
            this.c_monitor = c_monitor;
            checkMonitor();

            s_width = Screen.AllScreens[c_monitor].Bounds.Width;
            s_height = Screen.AllScreens[c_monitor].Bounds.Height;

            setupDevice();
        }

        public void setCaptureQuality(int c_width, int c_height)
        {
            this.c_width = c_width;
            this.c_height = c_height;
            c_array = new byte[c_width * c_height * 3];
        }

        private void loop()
        {
            _isRunning = true;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int ticks = 0;

            while (!quit)
            {
                Surface s = Surface.CreateOffscreenPlain(d, s_width, s_height, Format.A8R8G8B8, Pool.Scratch);
                Surface b = Surface.CreateOffscreenPlain(d, c_width, c_height, Format.A8R8G8B8, Pool.Scratch);
                d.GetFrontBufferData(0, s);
                Surface.FromSurface(b, s, Filter.Triangle, 0);
                s.Dispose();

                DataRectangle dr = b.LockRectangle(LockFlags.None);
                DataStream ds = dr.Data;
                c_array = removeAlpha(ds);

                b.UnlockRectangle();
                b.Dispose();
                ds.Dispose();

                ticks++;

                if (sw.ElapsedMilliseconds >= 1000)
                {
                    setUPSDelegate(ticks);
                    ticks = 0;
                    sw.Restart();
                }
            }

            _isRunning = false;
        }

        private void setupDevice()
        {
            PresentParameters parameters = new PresentParameters
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                PresentationInterval = PresentInterval.Immediate
            };

            d = new Device(new Direct3D(), c_monitor, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, parameters);
        }

        private void checkMonitor()
        {
            DisplayMonitor[] monitors = DisplayMonitor.EnumerateMonitors();
            if (c_monitor < monitors.Length)
            {
                if (monitors[c_monitor] != null)
                    return;
            }
            c_monitor = 0;
        }

        private byte[] removeAlpha(DataStream ia)
        {
            var newImage = new byte[(ia.Length * 3 / 4)];
            int counter = 0;
            while (ia.Position < ia.Length)
            {
                var a = new byte[4];
                ia.Read(a, 0, 4);
                newImage[counter] = (a[2]);
                counter++;
                newImage[counter] = (a[1]);
                counter++;
                newImage[counter] = (a[0]);
                counter++;
            }
            return newImage;
        }
    }
}
