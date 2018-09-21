namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.homepageButton = new System.Windows.Forms.Button();
            this.personalInfoButton = new System.Windows.Forms.Button();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // homepageButton
            // 
            this.homepageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(105)))));
            this.homepageButton.Image = ((System.Drawing.Image)(resources.GetObject("homepageButton.Image")));
            this.homepageButton.Location = new System.Drawing.Point(83, 286);
            this.homepageButton.Name = "homepageButton";
            this.homepageButton.Size = new System.Drawing.Size(285, 199);
            this.homepageButton.TabIndex = 0;
            this.homepageButton.UseVisualStyleBackColor = false;
            this.homepageButton.Click += new System.EventHandler(this.homepageButton_Click);
            // 
            // personalInfoButton
            // 
            this.personalInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(92)))));
            this.personalInfoButton.Image = ((System.Drawing.Image)(resources.GetObject("personalInfoButton.Image")));
            this.personalInfoButton.Location = new System.Drawing.Point(392, 286);
            this.personalInfoButton.Name = "personalInfoButton";
            this.personalInfoButton.Size = new System.Drawing.Size(285, 199);
            this.personalInfoButton.TabIndex = 1;
            this.personalInfoButton.UseVisualStyleBackColor = false;
            this.personalInfoButton.Click += new System.EventHandler(this.personalInfoButton_Click);
            // 
            // containerPanel
            // 
            this.containerPanel.Location = new System.Drawing.Point(757, 60);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(898, 846);
            this.containerPanel.TabIndex = 2;
            this.containerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.containerPanel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1708, 996);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.personalInfoButton);
            this.Controls.Add(this.homepageButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button homepageButton;
        private System.Windows.Forms.Button personalInfoButton;
        private System.Windows.Forms.Panel containerPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}