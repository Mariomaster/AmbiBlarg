namespace AmbiBlarg
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.copyrightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.copyrightLabel.Location = new System.Drawing.Point(10, 129);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(99, 21);
            this.copyrightLabel.TabIndex = 8;
            this.copyrightLabel.Text = "Year Name";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.versionLabel.Location = new System.Drawing.Point(8, 62);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(173, 33);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Version vX.X";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Century Gothic", 39F, System.Drawing.FontStyle.Bold);
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(451, 62);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "<Product Name>";
            // 
            // logoBox
            // 
            this.logoBox.BackgroundImage = global::AmbiBlarg.Properties.Resources.Logo;
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoBox.Location = new System.Drawing.Point(8, 8);
            this.logoBox.Margin = new System.Windows.Forms.Padding(8);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(175, 175);
            this.logoBox.TabIndex = 5;
            this.logoBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.versionLabel);
            this.panel1.Controls.Add(this.copyrightLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(191, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 150);
            this.panel1.TabIndex = 9;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.logoBox);
            this.panel.Controls.Add(this.panel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(700, 191);
            this.panel.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 150);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "About";
            this.Size = new System.Drawing.Size(700, 493);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
    }
}
