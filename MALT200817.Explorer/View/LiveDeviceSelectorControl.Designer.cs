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
            this.knvDataGridView1 = new Konvolucio.MCEL181123.Controls.KnvDataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamilyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.knvDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knvDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.FamilyCode,
            this.Address,
            this.Version,
            this.SerialNumber});
            this.knvDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvDataGridView1.FirstZebraColor = System.Drawing.Color.LightBlue;
            this.knvDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.knvDataGridView1.MultiSelect = false;
            this.knvDataGridView1.Name = "knvDataGridView1";
            this.knvDataGridView1.ReadOnly = true;
            this.knvDataGridView1.SecondZebraColor = System.Drawing.Color.White;
            this.knvDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            // FamilyCode
            // 
            this.FamilyCode.DataPropertyName = "FamilyCode";
            this.FamilyCode.HeaderText = "Family Code";
            this.FamilyCode.Name = "FamilyCode";
            this.FamilyCode.ReadOnly = true;
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
            this.SerialNumber.HeaderText = "Serial Number";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // DeviceSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.knvDataGridView1);
            this.Name = "DeviceSelectorControl";
            this.Size = new System.Drawing.Size(507, 340);
            ((System.ComponentModel.ISupportInitialize)(this.knvDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Konvolucio.MCEL181123.Controls.KnvDataGridView knvDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamilyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
    }
}
