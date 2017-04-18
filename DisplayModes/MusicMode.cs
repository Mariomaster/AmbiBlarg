using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.BassWasapi;
using System.Threading;
using DrawingEx.ColorManagement.Gradients;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.IO;

namespace AmbiBlarg.DisplayModes
{
    public partial class MusicMode : DisplayMode
    {
        private GradientCollection coll;
        private Gradient grd;

        public MusicMode()
        {
            InitializeComponent();
            name = "Music";

            string gradientsPath = Application.StartupPath + "\\gradients.grdx";
            if (!File.Exists(gradientsPath))
            {
                Console.WriteLine("Overwriting gradients.grdx (Not existing)");
                File.WriteAllBytes(gradientsPath, Properties.Resources.defaultGradients);
            }

            coll = new GradientCollection();
            coll.Load(gradientsPath);

            if (coll.Count == 0)
            {
                Console.WriteLine("Overwriting gradients.grdx (Count == 0)");
                File.WriteAllBytes(gradientsPath, Properties.Resources.defaultGradients);
                coll.Load(gradientsPath);
            }

            if (Properties.Settings.Default.lastGradient < coll.Count)
                grd = coll[Properties.Settings.Default.lastGradient];
            else
                grd = coll[0];
            gradientNameLabel.Text = grd.Title;

            audioSpectrum.Init(38, devicesBox, grd);

            smoothingBar.Value = Properties.Settings.Default.lastSmoothing;
            smoothingBar_Scroll(null, null);
        }

        public override void _activate()
        {
            audioSpectrum.start();
        }

        public override void _deactivate()
        {
            audioSpectrum.stop();
        }

        public override void cleanUp()
        {
            Properties.Settings.Default.lastGradient = coll.IndexOf(grd);
        }

        private void gradientBox_Click(object sender, EventArgs e)
        {
            using (GradientCollectionEditor edit = new GradientCollectionEditor())
            {
                foreach (Gradient g in coll)
                    edit.Gradients.Add(g);
                edit.SelectedGradient = grd;

                if (edit.ShowDialog() == DialogResult.OK)
                {
                    coll.Clear();
                    
                    foreach (Gradient g in edit.Gradients)
                        coll.Add(g);

                    string gradientsPath = Application.StartupPath + "\\gradients.grdx";
                    try
                    {
                        coll.Save(gradientsPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (coll.Count == 0)
                    {
                        Console.WriteLine("Overwriting gradients.grdx (Count == 0)");
                        File.WriteAllBytes(gradientsPath, Properties.Resources.defaultGradients);
                        coll.Load(gradientsPath);
                        grd = coll[0];
                    }
                    else
                        grd = edit.SelectedGradient;

                    audioSpectrum.grd = grd;
                    gradientNameLabel.Text = grd.Title;

                    gradientBox.Refresh();
                }
            }
        }

        private void gradientBox_Paint(object sender, PaintEventArgs e)
        {
            using (HatchBrush hbrs = new HatchBrush(HatchStyle.LargeCheckerBoard,
                Color.Silver, Color.White))
            {
                e.Graphics.FillRectangle(hbrs, gradientBox.ClientRectangle);
            }
            if (grd != null)
            {
                using (LinearGradientBrush lnbrs = new LinearGradientBrush(
                    new Point(1, 0), new Point(Math.Max(1, gradientBox.Height+1), 0),
                    Color.Transparent, Color.Black))
                {
                    lnbrs.InterpolationColors = grd;
                    lnbrs.RotateTransform(-90);
                    e.Graphics.FillRectangle(lnbrs, gradientBox.ClientRectangle);
                }
            }
        }

        private void smoothingBar_Scroll(object sender, EventArgs e)
        {
            float smoothing = smoothingBar.Value / 100f;
            smoothing = (float)Math.Min(0.99, smoothing);

            audioSpectrum.smoothing = smoothing;
            Properties.Settings.Default.lastSmoothing = smoothingBar.Value;
        }
    }
}
