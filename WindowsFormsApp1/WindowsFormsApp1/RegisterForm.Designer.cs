namespace Librarian
{
    partial class RegisterForm
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.saveFaceButton = new System.Windows.Forms.Button();
            this.registerPicBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.registerPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(20, 23);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(246, 31);
            this.nameBox.TabIndex = 0;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(11, 76);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(205, 48);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // saveFaceButton
            // 
            this.saveFaceButton.Location = new System.Drawing.Point(622, 875);
            this.saveFaceButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveFaceButton.Name = "saveFaceButton";
            this.saveFaceButton.Size = new System.Drawing.Size(226, 55);
            this.saveFaceButton.TabIndex = 2;
            this.saveFaceButton.Text = "Save your face";
            this.saveFaceButton.UseVisualStyleBackColor = true;
            this.saveFaceButton.Visible = false;
            this.saveFaceButton.Click += new System.EventHandler(this.saveFaceButton_Click);
            // 
            // registerPicBox
            // 
            this.registerPicBox.AccessibleName = "";
            this.registerPicBox.Location = new System.Drawing.Point(300, 23);
            this.registerPicBox.Margin = new System.Windows.Forms.Padding(2);
            this.registerPicBox.Name = "registerPicBox";
            this.registerPicBox.Size = new System.Drawing.Size(870, 820);
            this.registerPicBox.TabIndex = 3;
            this.registerPicBox.TabStop = false;
            this.registerPicBox.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(906, 875);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(264, 55);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel registration";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1232, 962);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registerPicBox);
            this.Controls.Add(this.saveFaceButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.nameBox);
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1258, 1033);
            this.MinimumSize = new System.Drawing.Size(1258, 1033);
            this.Name = "RegisterForm";
            this.Text = ".TAIPT Library | Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.Shown += new System.EventHandler(this.RegisterForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.registerPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button saveFaceButton;
        private System.Windows.Forms.PictureBox registerPicBox;
        private System.Windows.Forms.Button cancelButton;
    }
}