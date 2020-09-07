namespace MALT200817.Explorer.View
{
    partial class Malt132CardForm
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
            this.relayPanelControl1 = new MALT200817.Explorer.View.DevicePanelControl();
            this.SuspendLayout();
            // 
            // relayPanelControl1
            // 
            this.relayPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relayPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.relayPanelControl1.Name = "relayPanelControl1";
            this.relayPanelControl1.Size = new System.Drawing.Size(496, 275);
            this.relayPanelControl1.TabIndex = 0;
            // 
            // Malt132CardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 275);
            this.Controls.Add(this.relayPanelControl1);
            this.Name = "Malt132CardForm";
            this.Text = "CardMalt132Form";
            this.ResumeLayout(false);

        }

        #endregion

        private DevicePanelControl relayPanelControl1;
    }
}