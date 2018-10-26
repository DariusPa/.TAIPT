namespace VirtualLibrarian
{
    partial class Homepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.homepagePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.homepagePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // homepagePicture
            // 
            this.homepagePicture.BackColor = System.Drawing.Color.White;
            this.homepagePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepagePicture.Image = ((System.Drawing.Image)(resources.GetObject("homepagePicture.Image")));
            this.homepagePicture.ImageLocation = "";
            this.homepagePicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("homepagePicture.InitialImage")));
            this.homepagePicture.Location = new System.Drawing.Point(0, 0);
            this.homepagePicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.homepagePicture.Name = "homepagePicture";
            this.homepagePicture.Size = new System.Drawing.Size(508, 414);
            this.homepagePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.homepagePicture.TabIndex = 0;
            this.homepagePicture.TabStop = false;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.homepagePicture);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Homepage";
            this.Size = new System.Drawing.Size(508, 414);
            ((System.ComponentModel.ISupportInitialize)(this.homepagePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox homepagePicture;
    }
}
