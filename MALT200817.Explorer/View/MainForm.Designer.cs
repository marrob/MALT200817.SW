namespace MALT200817.Explorer.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLoadTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLastModify = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRowColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.devicesViewControl1 = new MALT200817.Explorer.View.LiveDeviceSelectorControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(646, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.devicesViewControl1);
            this.splitContainer1.Size = new System.Drawing.Size(646, 426);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 8;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLoadTime,
            this.toolStripStatusLabelLastModify,
            this.toolStripStatusLabelRowColumn,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 426);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(646, 24);
            this.statusStrip2.TabIndex = 9;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(0, 19);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLoadTime
            // 
            this.toolStripStatusLoadTime.Name = "toolStripStatusLoadTime";
            this.toolStripStatusLoadTime.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLoadTime.Text = "Load Time";
            // 
            // toolStripStatusLabelLastModify
            // 
            this.toolStripStatusLabelLastModify.AutoToolTip = true;
            this.toolStripStatusLabelLastModify.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelLastModify.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelLastModify.Name = "toolStripStatusLabelLastModify";
            this.toolStripStatusLabelLastModify.Size = new System.Drawing.Size(121, 19);
            this.toolStripStatusLabelLastModify.Text = "Last write timestamp";
            // 
            // toolStripStatusLabelRowColumn
            // 
            this.toolStripStatusLabelRowColumn.AutoToolTip = true;
            this.toolStripStatusLabelRowColumn.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabelRowColumn.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelRowColumn.Name = "toolStripStatusLabelRowColumn";
            this.toolStripStatusLabelRowColumn.Size = new System.Drawing.Size(80, 19);
            this.toolStripStatusLabelRowColumn.Text = "Row Column";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(217, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(58, 19);
            this.toolStripStatusLabelVersion.Text = "VERSION";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLabel2.Text = "AltonTech";
            // 
            // devicesViewControl1
            // 
            this.devicesViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devicesViewControl1.Location = new System.Drawing.Point(0, 0);
            this.devicesViewControl1.Name = "devicesViewControl1";
            this.devicesViewControl1.Size = new System.Drawing.Size(366, 426);
            this.devicesViewControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 450);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LiveDeviceSelectorControl devicesViewControl1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLoadTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLastModify;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRowColumn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

