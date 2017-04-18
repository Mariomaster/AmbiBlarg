namespace AmbiBlarg.DisplayModes
{
    partial class ScreenCaptureMode
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
            this.cfpsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cfpsLabel
            // 
            this.cfpsLabel.AutoSize = true;
            this.cfpsLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cfpsLabel.Location = new System.Drawing.Point(0, 306);
            this.cfpsLabel.Name = "cfpsLabel";
            this.cfpsLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cfpsLabel.Size = new System.Drawing.Size(125, 16);
            this.cfpsLabel.TabIndex = 0;
            this.cfpsLabel.Text = "Captured Frames: 0 FPS";
            // 
            // ScreenCaptureMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.cfpsLabel);
            this.Name = "ScreenCaptureMode";
            this.Size = new System.Drawing.Size(498, 322);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cfpsLabel;
    }
}
