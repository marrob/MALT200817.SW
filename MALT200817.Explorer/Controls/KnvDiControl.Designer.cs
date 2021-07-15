namespace MALT200817.Explorer.Controls
{
    partial class KnvDiControl
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
            this.labelNcPin = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNcPin
            // 
            this.labelNcPin.BackColor = System.Drawing.Color.LightBlue;
            this.labelNcPin.Location = new System.Drawing.Point(155, 14);
            this.labelNcPin.Name = "labelNcPin";
            this.labelNcPin.Size = new System.Drawing.Size(31, 13);
            this.labelNcPin.TabIndex = 2;
            this.labelNcPin.Text = "DI";
            this.labelNcPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNum
            // 
            this.labelNum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelNum.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNum.Location = new System.Drawing.Point(3, 0);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(111, 38);
            this.labelNum.TabIndex = 4;
            this.labelNum.Text = "DI128";
            this.labelNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::MALT200817.Explorer.Properties.Resources.buttongary321;
            this.pictureBox1.Location = new System.Drawing.Point(117, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // KnvDiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.labelNcPin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "KnvDiControl";
            this.Size = new System.Drawing.Size(195, 38);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNcPin;
        private System.Windows.Forms.Label labelNum;
    }
}
