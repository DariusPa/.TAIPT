namespace VirtualLibrarian
{
    partial class ExistingUserForm
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
            this.loginPicBox = new System.Windows.Forms.PictureBox();
            this.returnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginPicBox
            // 
            this.loginPicBox.AccessibleName = "";
            this.loginPicBox.Location = new System.Drawing.Point(-7, -1);
            this.loginPicBox.Margin = new System.Windows.Forms.Padding(1);
            this.loginPicBox.Name = "loginPicBox";
            this.loginPicBox.Size = new System.Drawing.Size(517, 533);
            this.loginPicBox.TabIndex = 3;
            this.loginPicBox.TabStop = false;
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.returnButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.returnButton.ForeColor = System.Drawing.Color.White;
            this.returnButton.Location = new System.Drawing.Point(356, 476);
            this.returnButton.Margin = new System.Windows.Forms.Padding(1);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(132, 28);
            this.returnButton.TabIndex = 4;
            this.returnButton.Text = "Cancel";
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // ExistingUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(506, 526);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.loginPicBox);
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(522, 571);
            this.MinimumSize = new System.Drawing.Size(522, 556);
            this.Name = "ExistingUserForm";
            this.Text = ".TAIPT Library | Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExistingUserForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExistingUserForm_FormClosed);
            this.Load += new System.EventHandler(this.ExistingUserForm_Load);
            this.Shown += new System.EventHandler(this.ExistingUserForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.loginPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox loginPicBox;
        private System.Windows.Forms.Button returnButton;
    }
}