namespace AmbiBlarg.DisplayModes
{
    partial class MusicMode
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.devicesBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.audioSpectrum = new AmbiBlarg.AudioSpectrum();
            this.gradientBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.smoothingBar = new System.Windows.Forms.TrackBar();
            this.gradientNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradientBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smoothingBar)).BeginInit();
            this.SuspendLayout();
            // 
            // devicesBox
            // 
            this.devicesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesBox.FormattingEnabled = true;
            this.devicesBox.Location = new System.Drawing.Point(74, 8);
            this.devicesBox.Name = "devicesBox";
            this.devicesBox.Size = new System.Drawing.Size(326, 21);
            this.devicesBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device:";
            // 
            // audioSpectrum
            // 
            this.audioSpectrum.BackColor = System.Drawing.SystemColors.Window;
            this.audioSpectrum.grd = null;
            this.audioSpectrum.Location = new System.Drawing.Point(74, 35);
            this.audioSpectrum.Name = "audioSpectrum";
            this.audioSpectrum.Size = new System.Drawing.Size(326, 264);
            this.audioSpectrum.smoothing = 0F;
            this.audioSpectrum.TabIndex = 2;
            // 
            // gradientBox
            // 
            this.gradientBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientBox.Location = new System.Drawing.Point(406, 35);
            this.gradientBox.Name = "gradientBox";
            this.gradientBox.Size = new System.Drawing.Size(39, 264);
            this.gradientBox.TabIndex = 3;
            this.gradientBox.TabStop = false;
            this.gradientBox.Click += new System.EventHandler(this.gradientBox_Click);
            this.gradientBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientBox_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Led Gradient\r\n(click to edit)\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Smoothing:";
            // 
            // smoothingBar
            // 
            this.smoothingBar.LargeChange = 10;
            this.smoothingBar.Location = new System.Drawing.Point(74, 305);
            this.smoothingBar.Maximum = 100;
            this.smoothingBar.Name = "smoothingBar";
            this.smoothingBar.Size = new System.Drawing.Size(326, 45);
            this.smoothingBar.TabIndex = 6;
            this.smoothingBar.TickFrequency = 10;
            this.smoothingBar.Scroll += new System.EventHandler(this.smoothingBar_Scroll);
            // 
            // gradientNameLabel
            // 
            this.gradientNameLabel.AutoSize = true;
            this.gradientNameLabel.Location = new System.Drawing.Point(451, 73);
            this.gradientNameLabel.Name = "gradientNameLabel";
            this.gradientNameLabel.Size = new System.Drawing.Size(75, 13);
            this.gradientNameLabel.TabIndex = 7;
            this.gradientNameLabel.Text = "GradientName";
            // 
            // MusicMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gradientNameLabel);
            this.Controls.Add(this.smoothingBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gradientBox);
            this.Controls.Add(this.audioSpectrum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.devicesBox);
            this.Name = "MusicMode";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(530, 365);
            ((System.ComponentModel.ISupportInitialize)(this.gradientBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smoothingBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox devicesBox;
        private System.Windows.Forms.Label label1;
        private AudioSpectrum audioSpectrum;
        private System.Windows.Forms.PictureBox gradientBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar smoothingBar;
        private System.Windows.Forms.Label gradientNameLabel;
    }
}
