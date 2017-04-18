namespace AmbiBlarg.DisplayModes
{
    partial class StaticColorMode
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
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.screenColorPicker = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColorEditor = this.colorEditor;
            this.colorEditorManager.ColorWheel = this.colorWheel;
            this.colorEditorManager.ScreenColorPicker = this.screenColorPicker;
            this.colorEditorManager.ColorChanged += new System.EventHandler(this.colorEditorManager_ColorChanged);
            // 
            // colorEditor
            // 
            this.colorEditor.Location = new System.Drawing.Point(320, 3);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.Size = new System.Drawing.Size(234, 250);
            this.colorEditor.TabIndex = 10;
            // 
            // colorWheel
            // 
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorWheel.Location = new System.Drawing.Point(3, 3);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(311, 257);
            this.colorWheel.TabIndex = 6;
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Color = System.Drawing.Color.Empty;
            this.screenColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenColorPicker.Location = new System.Drawing.Point(351, 276);
            this.screenColorPicker.Margin = new System.Windows.Forms.Padding(34, 13, 34, 13);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(172, 36);
            this.screenColorPicker.Text = "  Pick Color  From Screen";
            this.screenColorPicker.Zoom = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.Controls.Add(this.colorPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorWheel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorEditor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.screenColorPicker, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 325);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPanel.Location = new System.Drawing.Point(33, 276);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(33, 13, 33, 13);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(251, 36);
            this.colorPanel.TabIndex = 14;
            // 
            // StaticColorMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StaticColorMode";
            this.Size = new System.Drawing.Size(557, 325);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
        private Cyotek.Windows.Forms.ColorWheel colorWheel;
        private Cyotek.Windows.Forms.ColorEditor colorEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel colorPanel;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker;
    }
}
