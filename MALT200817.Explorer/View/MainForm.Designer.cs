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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.devicesViewControl1 = new MALT200817.Explorer.View.LiveDeviceSelectorControl();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelServiceStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDevicesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelConnetcionTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLogo = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(321, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.devicesViewControl1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(321, 432);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 8;
            // 
            // devicesViewControl1
            // 
            this.devicesViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devicesViewControl1.Location = new System.Drawing.Point(0, 0);
            this.devicesViewControl1.Name = "devicesViewControl1";
            this.devicesViewControl1.Size = new System.Drawing.Size(321, 432);
            this.devicesViewControl1.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabelServiceStatus,
            this.toolStripStatusDevicesCount,
            this.toolStripStatusLabelConnetcionTime,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabelLogo});
            this.statusStrip2.Location = new System.Drawing.Point(0, 456);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.ShowItemToolTips = true;
            this.statusStrip2.Size = new System.Drawing.Size(321, 24);
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
            // toolStripStatusLabelServiceStatus
            // 
            this.toolStripStatusLabelServiceStatus.AutoToolTip = true;
            this.toolStripStatusLabelServiceStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelServiceStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelServiceStatus.Name = "toolStripStatusLabelServiceStatus";
            this.toolStripStatusLabelServiceStatus.Size = new System.Drawing.Size(16, 19);
            this.toolStripStatusLabelServiceStatus.Text = "-";
            this.toolStripStatusLabelServiceStatus.ToolTipText = "AltonTech MALT200817.Service(MaltService) Status";
            // 
            // toolStripStatusDevicesCount
            // 
            this.toolStripStatusDevicesCount.Name = "toolStripStatusDevicesCount";
            this.toolStripStatusDevicesCount.Size = new System.Drawing.Size(12, 19);
            this.toolStripStatusDevicesCount.Text = "-";
            this.toolStripStatusDevicesCount.ToolTipText = "Devices Count";
            // 
            // toolStripStatusLabelConnetcionTime
            // 
            this.toolStripStatusLabelConnetcionTime.AutoToolTip = true;
            this.toolStripStatusLabelConnetcionTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelConnetcionTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelConnetcionTime.Name = "toolStripStatusLabelConnetcionTime";
            this.toolStripStatusLabelConnetcionTime.Size = new System.Drawing.Size(16, 19);
            this.toolStripStatusLabelConnetcionTime.Text = "-";
            this.toolStripStatusLabelConnetcionTime.ToolTipText = "Connection Time";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(111, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(58, 19);
            this.toolStripStatusLabelVersion.Text = "VERSION";
            this.toolStripStatusLabelVersion.ToolTipText = "Softwer Version";
            // 
            // toolStripStatusLabelLogo
            // 
            this.toolStripStatusLabelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(220)))));
            this.toolStripStatusLabelLogo.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelLogo.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelLogo.Name = "toolStripStatusLabelLogo";
            this.toolStripStatusLabelLogo.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLabelLogo.Text = "AltonTech";
            this.toolStripStatusLabelLogo.Click += new System.EventHandler(this.toolStripStatusLabelLogo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 480);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LiveDeviceSelectorControl devicesViewControl1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDevicesCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnetcionTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLogo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelServiceStatus;
    }
}

