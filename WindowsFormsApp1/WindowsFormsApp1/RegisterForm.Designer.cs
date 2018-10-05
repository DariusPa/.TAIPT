﻿namespace VirtualLibrarian
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
            this.registerPicBox = new System.Windows.Forms.PictureBox();
            this.saveFaceButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.registerPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // registerPicBox
            // 
            this.registerPicBox.AccessibleName = "";
            this.registerPicBox.Location = new System.Drawing.Point(0, -1);
            this.registerPicBox.Margin = new System.Windows.Forms.Padding(2);
            this.registerPicBox.Name = "registerPicBox";
            this.registerPicBox.Size = new System.Drawing.Size(1000, 1000);
            this.registerPicBox.TabIndex = 3;
            this.registerPicBox.TabStop = false;
            // 
            // saveFaceButton
            // 
            this.saveFaceButton.Location = new System.Drawing.Point(391, 915);
            this.saveFaceButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveFaceButton.Name = "saveFaceButton";
            this.saveFaceButton.Size = new System.Drawing.Size(226, 55);
            this.saveFaceButton.TabIndex = 5;
            this.saveFaceButton.Text = "Start";
            this.saveFaceButton.UseVisualStyleBackColor = true;
            this.saveFaceButton.Click += new System.EventHandler(this.SaveFaceButton_Click);
            this.saveFaceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(182)))), ((int)(((byte)(243)))));
            this.saveFaceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveFaceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(182)))), ((int)(((byte)(243)))));
            this.saveFaceButton.FlatAppearance.BorderSize = 0;
            this.saveFaceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(152)))), ((int)(((byte)(230)))));
            this.saveFaceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(152)))), ((int)(((byte)(230)))));
            this.saveFaceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveFaceButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.saveFaceButton.ForeColor = System.Drawing.Color.White;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(713, 915);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(264, 55);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1002, 987);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveFaceButton);
            this.Controls.Add(this.registerPicBox);
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1028, 1058);
            this.MinimumSize = new System.Drawing.Size(1028, 1058);
            this.Name = "RegisterForm";
            this.Text = ".TAIPT Library | Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.Shown += new System.EventHandler(this.RegisterForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.registerPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox registerPicBox;
        private System.Windows.Forms.Button saveFaceButton;
        private System.Windows.Forms.Button cancelButton;
    }
}