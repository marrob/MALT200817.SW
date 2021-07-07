namespace MALT200817.Explorer.Controls
{
    partial class KnvCoilControl
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPin = new System.Windows.Forms.Label();
            this.labelCoilNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MALT200817.Explorer.Properties.Resources.coil_off;
            this.pictureBox1.Location = new System.Drawing.Point(140, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelPin
            // 
            this.labelPin.BackColor = System.Drawing.Color.LightBlue;
            this.labelPin.Location = new System.Drawing.Point(176, 13);
            this.labelPin.Name = "labelPin";
            this.labelPin.Size = new System.Drawing.Size(31, 13);
            this.labelPin.TabIndex = 3;
            this.labelPin.Text = "NO";
            this.labelPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCoilNum
            // 
            this.labelCoilNum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCoilNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCoilNum.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoilNum.Location = new System.Drawing.Point(3, 0);
            this.labelCoilNum.Name = "labelCoilNum";
            this.labelCoilNum.Size = new System.Drawing.Size(99, 38);
            this.labelCoilNum.TabIndex = 4;
            this.labelCoilNum.Text = "K128";
            this.labelCoilNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCoilNum.Click += new System.EventHandler(this.labelRelayNum_Click);
            // 
            // KnvCoilControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCoilNum);
            this.Controls.Add(this.labelPin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "KnvCoilControl";
            this.Size = new System.Drawing.Size(217, 38);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPin;
        private System.Windows.Forms.Label labelCoilNum;
    }
}
