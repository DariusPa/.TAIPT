namespace VirtualLibrarian
{
    partial class AI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AI));
            this.AIBox = new System.Windows.Forms.PictureBox();
            this.guideText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AIBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AIBox
            // 
            this.AIBox.Image = global::VirtualLibrarian.Properties.Resources.ai;
            this.AIBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("AIBox.InitialImage")));
            this.AIBox.Location = new System.Drawing.Point(18, 7);
            this.AIBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AIBox.Name = "AIBox";
            this.AIBox.Size = new System.Drawing.Size(462, 59);
            this.AIBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AIBox.TabIndex = 0;
            this.AIBox.TabStop = false;
            // 
            // guideText
            // 
            this.guideText.AutoSize = true;
            this.guideText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(202)))), ((int)(((byte)(236)))));
            this.guideText.ForeColor = System.Drawing.Color.Black;
            this.guideText.Location = new System.Drawing.Point(86, 21);
            this.guideText.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.guideText.MaximumSize = new System.Drawing.Size(375, 42);
            this.guideText.Name = "guideText";
            this.guideText.Size = new System.Drawing.Size(0, 13);
            this.guideText.TabIndex = 1;
            // 
            // AI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guideText);
            this.Controls.Add(this.AIBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AI";
            this.Size = new System.Drawing.Size(500, 78);
            ((System.ComponentModel.ISupportInitialize)(this.AIBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AIBox;
        private System.Windows.Forms.Label guideText;
    }
}
