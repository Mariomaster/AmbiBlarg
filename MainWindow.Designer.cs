namespace AmbiBlarg
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.deviceStatusLabel = new System.Windows.Forms.Label();
            this.lightEnabled = new System.Windows.Forms.CheckBox();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.about = new AmbiBlarg.About();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.deviceStatusLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lightEnabled, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(584, 461);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(15, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(554, 387);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // deviceStatusLabel
            // 
            this.deviceStatusLabel.AutoSize = true;
            this.deviceStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceStatusLabel.Location = new System.Drawing.Point(15, 429);
            this.deviceStatusLabel.Name = "deviceStatusLabel";
            this.deviceStatusLabel.Size = new System.Drawing.Size(554, 20);
            this.deviceStatusLabel.TabIndex = 1;
            this.deviceStatusLabel.Text = "Device Status: Scanning...";
            this.deviceStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lightEnabled
            // 
            this.lightEnabled.AutoSize = true;
            this.lightEnabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightEnabled.Location = new System.Drawing.Point(15, 15);
            this.lightEnabled.Name = "lightEnabled";
            this.lightEnabled.Size = new System.Drawing.Size(554, 18);
            this.lightEnabled.TabIndex = 2;
            this.lightEnabled.Text = "Backlight Enabled";
            this.lightEnabled.UseVisualStyleBackColor = true;
            this.lightEnabled.CheckedChanged += new System.EventHandler(this.lightEnabled_CheckedChanged);
            // 
            // aboutTab
            // 
            this.aboutTab.BackColor = System.Drawing.Color.Transparent;
            this.aboutTab.Controls.Add(this.about);
            this.aboutTab.Location = new System.Drawing.Point(4, 22);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(546, 361);
            this.aboutTab.TabIndex = 0;
            this.aboutTab.Text = "About";
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.SystemColors.Window;
            this.about.Dock = System.Windows.Forms.DockStyle.Fill;
            this.about.Location = new System.Drawing.Point(0, 0);
            this.about.Margin = new System.Windows.Forms.Padding(8);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(546, 361);
            this.about.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MainWindow";
            this.Text = "<Product Name>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.aboutTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label deviceStatusLabel;
        private System.Windows.Forms.CheckBox lightEnabled;
        private System.Windows.Forms.TabPage aboutTab;
        private About about;
    }
}

