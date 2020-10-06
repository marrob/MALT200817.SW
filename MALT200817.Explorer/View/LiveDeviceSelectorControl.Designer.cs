namespace MALT200817.Explorer.View
{
    partial class LiveDeviceSelectorControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.knvDataGridView1 = new Konvolucio.MCEL181123.Controls.KnvDataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // knvDataGridView1
            // 
            this.knvDataGridView1.AllowUserToAddRows = false;
            this.knvDataGridView1.AllowUserToDeleteRows = false;
            this.knvDataGridView1.AllowUserToResizeRows = false;
            this.knvDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.knvDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.knvDataGridView1.BackgroundText = "Cell Emulators";
            this.knvDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.knvDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.knvDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knvDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.Address,
            this.Version,
            this.SerialNumber});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.knvDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.knvDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvDataGridView1.EnableHeadersVisualStyles = false;
            this.knvDataGridView1.FirstZebraColor = System.Drawing.Color.LightBlue;
            this.knvDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.knvDataGridView1.MultiSelect = false;
            this.knvDataGridView1.Name = "knvDataGridView1";
            this.knvDataGridView1.ReadOnly = true;
            this.knvDataGridView1.RowHeadersVisible = false;
            this.knvDataGridView1.SecondZebraColor = System.Drawing.Color.White;
            this.knvDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.knvDataGridView1.ShowCellErrors = false;
            this.knvDataGridView1.ShowCellToolTips = false;
            this.knvDataGridView1.ShowEditingIcon = false;
            this.knvDataGridView1.ShowRowErrors = false;
            this.knvDataGridView1.Size = new System.Drawing.Size(507, 340);
            this.knvDataGridView1.TabIndex = 1;
            this.knvDataGridView1.ZebraRow = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "SN";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // LiveDeviceSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.knvDataGridView1);
            this.Name = "LiveDeviceSelectorControl";
            this.Size = new System.Drawing.Size(507, 340);
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Konvolucio.MCEL181123.Controls.KnvDataGridView knvDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
    }
}
