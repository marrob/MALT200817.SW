namespace MALT200817.Explorer.Controls
{
    partial class KnvRealySpdtControl
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
            this.labelComPin = new System.Windows.Forms.Label();
            this.labelNcPin = new System.Windows.Forms.Label();
            this.labelNoPin = new System.Windows.Forms.Label();
            this.labelRelayNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MALT200817.Explorer.Properties.Resources.relay_spdt_off;
            this.pictureBox1.Location = new System.Drawing.Point(140, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelComPin
            // 
            this.labelComPin.BackColor = System.Drawing.Color.LightBlue;
            this.labelComPin.Location = new System.Drawing.Point(105, 13);
            this.labelComPin.Name = "labelComPin";
            this.labelComPin.Size = new System.Drawing.Size(31, 13);
            this.labelComPin.TabIndex = 1;
            this.labelComPin.Text = "COM";
            this.labelComPin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNcPin
            // 
            this.labelNcPin.BackColor = System.Drawing.Color.LightBlue;
            this.labelNcPin.Location = new System.Drawing.Point(178, 3);
            this.labelNcPin.Name = "labelNcPin";
            this.labelNcPin.Size = new System.Drawing.Size(31, 13);
            this.labelNcPin.TabIndex = 2;
            this.labelNcPin.Text = "NC";
            this.labelNcPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNoPin
            // 
            this.labelNoPin.BackColor = System.Drawing.Color.LightBlue;
            this.labelNoPin.Location = new System.Drawing.Point(177, 22);
            this.labelNoPin.Name = "labelNoPin";
            this.labelNoPin.Size = new System.Drawing.Size(31, 13);
            this.labelNoPin.TabIndex = 3;
            this.labelNoPin.Text = "NO";
            this.labelNoPin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRelayNum
            // 
            this.labelRelayNum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelRelayNum.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRelayNum.Location = new System.Drawing.Point(3, 0);
            this.labelRelayNum.Name = "labelRelayNum";
            this.labelRelayNum.Size = new System.Drawing.Size(99, 38);
            this.labelRelayNum.TabIndex = 4;
            this.labelRelayNum.Text = "K128";
            this.labelRelayNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KnvRealySpdtControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelRelayNum);
            this.Controls.Add(this.labelNoPin);
            this.Controls.Add(this.labelNcPin);
            this.Controls.Add(this.labelComPin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "KnvRealySpdtControl";
            this.Size = new System.Drawing.Size(217, 38);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelComPin;
        private System.Windows.Forms.Label labelNcPin;
        private System.Windows.Forms.Label labelNoPin;
        private System.Windows.Forms.Label labelRelayNum;
    }
}
