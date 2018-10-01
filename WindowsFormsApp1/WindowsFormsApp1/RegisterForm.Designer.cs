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
            this.saveFaceButton = new System.Windows.Forms.Button();
            this.registerPicBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.registerPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFaceButton
            // 
            this.saveFaceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveFaceButton.Location = new System.Drawing.Point(270, 455);
            this.saveFaceButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.saveFaceButton.Name = "saveFaceButton";
            this.saveFaceButton.Size = new System.Drawing.Size(113, 29);
            this.saveFaceButton.TabIndex = 2;
            this.saveFaceButton.Text = "Save your face";
            this.saveFaceButton.UseVisualStyleBackColor = true;
            this.saveFaceButton.Click += new System.EventHandler(this.saveFaceButton_Click);
            // 
            // registerPicBox
            // 
            this.registerPicBox.AccessibleName = "";
            this.registerPicBox.Location = new System.Drawing.Point(106, 6);
            this.registerPicBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.registerPicBox.Name = "registerPicBox";
            this.registerPicBox.Size = new System.Drawing.Size(435, 426);
            this.registerPicBox.TabIndex = 3;
            this.registerPicBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(409, 455);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(132, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel registration";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(619, 491);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.registerPicBox);
            this.Controls.Add(this.saveFaceButton);
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximumSize = new System.Drawing.Size(635, 551);
            this.MinimumSize = new System.Drawing.Size(635, 475);
            this.Name = "RegisterForm";
            this.Text = ".TAIPT Library | Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.Shown += new System.EventHandler(this.RegisterForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.registerPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveFaceButton;
        private System.Windows.Forms.PictureBox registerPicBox;
        private System.Windows.Forms.Button cancelButton;
    }
}