namespace VirtualLibrarian
{
    partial class PersonalInfo
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
            this.personalInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // personalInfoLabel
            // 
            this.personalInfoLabel.AutoEllipsis = true;
            this.personalInfoLabel.AutoSize = true;
            this.personalInfoLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalInfoLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.personalInfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.personalInfoLabel.Location = new System.Drawing.Point(98, 8);
            this.personalInfoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.personalInfoLabel.Name = "personalInfoLabel";
            this.personalInfoLabel.Size = new System.Drawing.Size(306, 36);
            this.personalInfoLabel.TabIndex = 2;
            this.personalInfoLabel.Text = "Personal information";
            this.personalInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PersonalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.personalInfoLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PersonalInfo";
            this.Size = new System.Drawing.Size(508, 414);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label personalInfoLabel;
    }
}
