using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Un4seen.BassWasapi;
using Un4seen.Bass;
using DrawingEx.ColorManagement.Gradients;

namespace AmbiBlarg
{
    public partial class AudioSpectrum : UserControl
    {
        private ComboBox deviceBox;
        public Gradient grd { get; set; }
        public float smoothing { get; set; }

        private Color[] lastColors;
        private List<byte> lastdata;

        private Timer t;
        private float[] fft;
        private WASAPIPROC process;
        private int lastlevel;
        private int hanctr;
        private List<Tuple<byte, Color>> spectrumdata;
        private int devindex;

        private int lines { get; set; }

        public AudioSpectrum()
        {
            InitializeComponent();

            chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            chart.ChartAreas[0].AxisY.Maximum = 255;
            chart.ChartAreas[0].AxisY.Minimum = 0;

            BassNet.Registration("bent@mail.de", "2X1123181222323");
        }

        private void setValues(List<Tuple<byte, Color>> data)
        {
            chart.Series["Spectrum"].Points.Clear();

            for (int i = 0; i < data.Count; i++)
            {
                DataPoint p = new DataPoint(i, data[i].Item1);
                p.Color = data[i].Item2;
                chart.Series["Spectrum"].Points.Add(p);
            }
        }

        public void Init(int lines, ComboBox deviceBox, Gradient grd)
        {
            this.lines = lines;
            this.deviceBox = deviceBox;
            this.grd = grd;

            fft = new float[1024];
            lastlevel = 0;
            hanctr = 0;
            t = new Timer();
            t.Tick += new EventHandler(tick);
            t.Interval = 1000 / 40;   // 40hz refresh rate
            t.Enabled = false;
            process = new WASAPIPROC(Process);
            spectrumdata = new List<Tuple<byte, Color>>();
            lastdata = new List<byte>();

            bool result = false;
            for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
            {
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    deviceBox.Items.Add(string.Format("{0} - {1}", i, device.name));
                }
            }
            deviceBox.SelectedIndex = 0;
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
            result = Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            if (!result) throw new Exception("Init Error");

            deviceBox.SelectedIndexChanged += deviceChanged;
        }

        public void start()
        {
            var array = (deviceBox.Items[deviceBox.SelectedIndex] as string).Split(' ');
            devindex = Convert.ToInt32(array[0]);
            bool result = BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, process, IntPtr.Zero);
            if (!result)
            {
                var error = Bass.BASS_ErrorGetCode();
                MessageBox.Show(error.ToString());
            }
            BassWasapi.BASS_WASAPI_Start();
            lastColors = new Color[lines];
            Array.Clear(lastColors, 0, lastColors.Length);
            t.Start();
        }

        public void stop()
        {
            t.Stop();
            Free();
            Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            chart.Series["Spectrum"].Points.Clear();
        }

        private void tick(Object myObject, EventArgs myEventArgs)
        {
            int ret = BassWasapi.BASS_WASAPI_GetData(fft, (int)BASSData.BASS_DATA_FFT2048); //get channel fft data
            if (ret < -1) return;
            int x, y;
            int b0 = 0;

            //computes the spectrum data, the code is taken from a bass_wasapi sample.
            for (x = 0; x < lines; x++)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (lines - 1));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++)
                {
                    if (peak < fft[1 + b0]) peak = fft[1 + b0];
                }
                y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                if (y > 255) y = 255;
                if (y < 0) y = 0;

                Color lastColor = lastColors[x];
                Color nowColor = grd.GetColorAt(y / 255f);

                float a_smoothing = 1f - smoothing;

                byte r = (byte)(lastColor.R * smoothing + nowColor.R * a_smoothing);
                byte g = (byte)(lastColor.G * smoothing + nowColor.G * a_smoothing);
                byte b = (byte)(lastColor.B * smoothing + nowColor.B * a_smoothing);
                Color calcColor = Color.FromArgb(r, g, b);

                spectrumdata.Add(new Tuple<byte, Color>((byte)y, nowColor));
                lastColors[x] = calcColor;

                LedManager.setLed(x+21, calcColor);
            }

            setValues(spectrumdata);
            spectrumdata.Clear();


            int level = BassWasapi.BASS_WASAPI_GetLevel();
            if (level == lastlevel && level != 0) hanctr++;
            lastlevel = level;

            //Required, because some programs hang the output. If the output hangs for a 75ms
            //this piece of code re initializes the output so it doesn't make a gliched sound for long.
            if (hanctr > 3)
            {
                Free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, process, IntPtr.Zero);
                BassWasapi.BASS_WASAPI_Start();
            }
        }

        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        public void Free()
        {
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }

        private void deviceChanged(object sender, EventArgs e)
        {
            stop();
            start();
        }
    }
}
