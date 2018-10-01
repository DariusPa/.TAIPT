namespace Librarian
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
            this.loginPicBox.Location = new System.Drawing.Point(4, 5);
            this.loginPicBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.loginPicBox.Name = "loginPicBox";
            this.loginPicBox.Size = new System.Drawing.Size(488, 545);
            this.loginPicBox.TabIndex = 0;
            this.loginPicBox.TabStop = false;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(203, 557);
            this.returnButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(77, 36);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // ExistingUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(501, 599);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.loginPicBox);
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximumSize = new System.Drawing.Size(517, 654);
            this.MinimumSize = new System.Drawing.Size(517, 579);
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