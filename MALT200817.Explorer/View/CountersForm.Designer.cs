namespace MALT200817.Explorer.View
{
    partial class CountersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountersForm));
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOptionCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFamilyCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUpdateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.knvDataGridView1 = new Konvolucio.MCEL181123.Controls.KnvDataGridView();
            this.ColumnLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabelAddress,
            this.toolStripStatusLabelOptionCode,
            this.toolStripStatusLabelFamilyCode,
            this.toolStripStatusLabelUpdateTime,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 570);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.ShowItemToolTips = true;
            this.statusStrip2.Size = new System.Drawing.Size(418, 24);
            this.statusStrip2.TabIndex = 10;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabelAddress
            // 
            this.toolStripStatusLabelAddress.AutoToolTip = true;
            this.toolStripStatusLabelAddress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelAddress.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelAddress.Name = "toolStripStatusLabelAddress";
            this.toolStripStatusLabelAddress.Size = new System.Drawing.Size(60, 19);
            this.toolStripStatusLabelAddress.Text = "ADDRESS";
            this.toolStripStatusLabelAddress.ToolTipText = "Address";
            // 
            // toolStripStatusLabelOptionCode
            // 
            this.toolStripStatusLabelOptionCode.AutoToolTip = true;
            this.toolStripStatusLabelOptionCode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelOptionCode.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelOptionCode.Name = "toolStripStatusLabelOptionCode";
            this.toolStripStatusLabelOptionCode.Size = new System.Drawing.Size(88, 19);
            this.toolStripStatusLabelOptionCode.Text = "OPTION CODE";
            this.toolStripStatusLabelOptionCode.ToolTipText = "Option Code";
            // 
            // toolStripStatusLabelFamilyCode
            // 
            this.toolStripStatusLabelFamilyCode.AutoToolTip = true;
            this.toolStripStatusLabelFamilyCode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelFamilyCode.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelFamilyCode.Name = "toolStripStatusLabelFamilyCode";
            this.toolStripStatusLabelFamilyCode.Size = new System.Drawing.Size(84, 19);
            this.toolStripStatusLabelFamilyCode.Text = "FAMILY CODE";
            this.toolStripStatusLabelFamilyCode.ToolTipText = "Family Code";
            // 
            // toolStripStatusLabelUpdateTime
            // 
            this.toolStripStatusLabelUpdateTime.AutoToolTip = true;
            this.toolStripStatusLabelUpdateTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelUpdateTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabelUpdateTime.Name = "toolStripStatusLabelUpdateTime";
            this.toolStripStatusLabelUpdateTime.Size = new System.Drawing.Size(82, 19);
            this.toolStripStatusLabelUpdateTime.Text = "UPDATE TIME";
            this.toolStripStatusLabelUpdateTime.ToolTipText = "Family Code";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 19);
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(220)))));
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel2.Text = "AltonTech";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.ToolStripStatusLabelLogo_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.ToolStripMenuItemReset,
            this.ToolStripMenuItemSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(418, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // knvDataGridView1
            // 
            this.knvDataGridView1.AllowUserToAddRows = false;
            this.knvDataGridView1.AllowUserToDeleteRows = false;
            this.knvDataGridView1.AllowUserToResizeColumns = false;
            this.knvDataGridView1.AllowUserToResizeRows = false;
            this.knvDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.knvDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.knvDataGridView1.BackgroundText = "fgsdg";
            this.knvDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLabel,
            this.ColumnPort,
            this.ColumnValue});
            this.knvDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvDataGridView1.FirstZebraColor = System.Drawing.Color.LightBlue;
            this.knvDataGridView1.Location = new System.Drawing.Point(0, 24);
            this.knvDataGridView1.MultiSelect = false;
            this.knvDataGridView1.Name = "knvDataGridView1";
            this.knvDataGridView1.RowHeadersVisible = false;
            this.knvDataGridView1.RowTemplate.Height = 15;
            this.knvDataGridView1.SecondZebraColor = System.Drawing.Color.White;
            this.knvDataGridView1.ShowCellToolTips = false;
            this.knvDataGridView1.ShowEditingIcon = false;
            this.knvDataGridView1.ShowRowErrors = false;
            this.knvDataGridView1.Size = new System.Drawing.Size(418, 546);
            this.knvDataGridView1.TabIndex = 0;
            this.knvDataGridView1.ZebraRow = true;
            // 
            // ColumnLabel
            // 
            this.ColumnLabel.DataPropertyName = "Label";
            this.ColumnLabel.HeaderText = "Label";
            this.ColumnLabel.Name = "ColumnLabel";
            this.ColumnLabel.ReadOnly = true;
            // 
            // ColumnPort
            // 
            this.ColumnPort.DataPropertyName = "Port";
            this.ColumnPort.HeaderText = "Port";
            this.ColumnPort.Name = "ColumnPort";
            this.ColumnPort.ReadOnly = true;
            // 
            // ColumnValue
            // 
            this.ColumnValue.DataPropertyName = "Value";
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Image = global::MALT200817.Explorer.Properties.Resources.refresh32;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.testToolStripMenuItem.Text = "Update";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemReset
            // 
            this.ToolStripMenuItemReset.Image = global::MALT200817.Explorer.Properties.Resources.number0_32;
            this.ToolStripMenuItemReset.Name = "ToolStripMenuItemReset";
            this.ToolStripMenuItemReset.Size = new System.Drawing.Size(63, 20);
            this.ToolStripMenuItemReset.Text = "Reset";
            this.ToolStripMenuItemReset.Click += new System.EventHandler(this.ResetToolStripMenuItemReset_Click);
            // 
            // ToolStripMenuItemSave
            // 
            this.ToolStripMenuItemSave.Image = global::MALT200817.Explorer.Properties.Resources.SaveAs32;
            this.ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            this.ToolStripMenuItemSave.Size = new System.Drawing.Size(59, 20);
            this.ToolStripMenuItemSave.Text = "Save";
            this.ToolStripMenuItemSave.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
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
            // CountersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 594);
            this.Controls.Add(this.knvDataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CountersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CountersForm";
            this.Load += new System.EventHandler(this.CountersForm_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Konvolucio.MCEL181123.Controls.KnvDataGridView knvDataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdateTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAddress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFamilyCode;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReset;
    }
}