namespace MALT200817.Explorer.Controls
{
    partial class KnvDoControl
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
            this.labelDoPin = new System.Windows.Forms.Label();
            this.labelRelayNum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNoPin
            // 
            this.labelDoPin.BackColor = System.Drawing.Color.LightBlue;
            this.labelDoPin.Location = new System.Drawing.Point(169, 13);
            this.labelDoPin.Name = "labelNoPin";
            this.labelDoPin.Size = new System.Drawing.Size(31, 13);
            this.labelDoPin.TabIndex = 3;
            this.labelDoPin.Text = "DO";
            this.labelDoPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRelayNum
            // 
            this.labelRelayNum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelRelayNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRelayNum.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRelayNum.Location = new System.Drawing.Point(3, 0);
            this.labelRelayNum.Name = "labelRelayNum";
            this.labelRelayNum.Size = new System.Drawing.Size(111, 38);
            this.labelRelayNum.TabIndex = 4;
            this.labelRelayNum.Text = "DO128";
            this.labelRelayNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelRelayNum.Click += new System.EventHandler(this.labelRelayNum_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MALT200817.Explorer.Properties.Resources.switchblue32;
            this.pictureBox1.Location = new System.Drawing.Point(125, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // KnvDoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelRelayNum);
            this.Controls.Add(this.labelDoPin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "KnvDoControl";
            this.Size = new System.Drawing.Size(217, 38);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelDoPin;
        private System.Windows.Forms.Label labelRelayNum;
    }
}
