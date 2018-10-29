namespace VirtualLibrarian
{
    partial class Settings
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
            this.settingsLabel = new System.Windows.Forms.Label();
            this.soundsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.sEmailInput = new System.Windows.Forms.RichTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.sSurnameInput = new System.Windows.Forms.RichTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.sNameInput = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoEllipsis = true;
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.settingsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsLabel.Location = new System.Drawing.Point(376, 15);
            this.settingsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(263, 72);
            this.settingsLabel.TabIndex = 1;
            this.settingsLabel.Text = "Settings";
            this.settingsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // soundsCheckBox
            // 
            this.soundsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.soundsCheckBox.BackgroundImage = global::VirtualLibrarian.Properties.Resources._unchecked;
            this.soundsCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.soundsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundsCheckBox.Location = new System.Drawing.Point(81, 189);
            this.soundsCheckBox.Name = "soundsCheckBox";
            this.soundsCheckBox.Size = new System.Drawing.Size(56, 56);
            this.soundsCheckBox.TabIndex = 2;
            this.soundsCheckBox.UseVisualStyleBackColor = true;
            this.soundsCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Program sounds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(672, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Personal details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "Account settings";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.emailLabel.Location = new System.Drawing.Point(565, 470);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(225, 36);
            this.emailLabel.TabIndex = 22;
            this.emailLabel.Text = "E-mail address";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.surnameLabel.Location = new System.Drawing.Point(565, 324);
            this.surnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(144, 36);
            this.surnameLabel.TabIndex = 21;
            this.surnameLabel.Text = "Surname";
            // 
            // sEmailInput
            // 
            this.sEmailInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sEmailInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sEmailInput.ForeColor = System.Drawing.Color.Black;
            this.sEmailInput.Location = new System.Drawing.Point(589, 533);
            this.sEmailInput.Margin = new System.Windows.Forms.Padding(4);
            this.sEmailInput.Multiline = false;
            this.sEmailInput.Name = "sEmailInput";
            this.sEmailInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.sEmailInput.Size = new System.Drawing.Size(328, 35);
            this.sEmailInput.TabIndex = 20;
            this.sEmailInput.Text = "";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox4.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox4.Location = new System.Drawing.Point(573, 518);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(390, 83);
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            // 
            // sSurnameInput
            // 
            this.sSurnameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sSurnameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sSurnameInput.ForeColor = System.Drawing.Color.Black;
            this.sSurnameInput.Location = new System.Drawing.Point(589, 385);
            this.sSurnameInput.Margin = new System.Windows.Forms.Padding(4);
            this.sSurnameInput.Multiline = false;
            this.sSurnameInput.Name = "sSurnameInput";
            this.sSurnameInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.sSurnameInput.Size = new System.Drawing.Size(328, 35);
            this.sSurnameInput.TabIndex = 18;
            this.sSurnameInput.Text = "";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox3.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox3.Location = new System.Drawing.Point(573, 370);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(390, 83);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // sNameInput
            // 
            this.sNameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sNameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sNameInput.ForeColor = System.Drawing.Color.Black;
            this.sNameInput.Location = new System.Drawing.Point(589, 239);
            this.sNameInput.Margin = new System.Windows.Forms.Padding(4);
            this.sNameInput.Multiline = false;
            this.sNameInput.Name = "sNameInput";
            this.sNameInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.sNameInput.Size = new System.Drawing.Size(328, 35);
            this.sNameInput.TabIndex = 16;
            this.sNameInput.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox2.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox2.Location = new System.Drawing.Point(573, 224);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(390, 83);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.nameLabel.Location = new System.Drawing.Point(565, 177);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(99, 36);
            this.nameLabel.TabIndex = 14;
            this.nameLabel.Text = "Name";
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(182)))), ((int)(((byte)(243)))));
            this.continueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.continueButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(182)))), ((int)(((byte)(243)))));
            this.continueButton.FlatAppearance.BorderSize = 0;
            this.continueButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(152)))), ((int)(((byte)(230)))));
            this.continueButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(152)))), ((int)(((byte)(230)))));
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.continueButton.ForeColor = System.Drawing.Color.White;
            this.continueButton.Location = new System.Drawing.Point(649, 699);
            this.continueButton.Margin = new System.Windows.Forms.Padding(4);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(314, 67);
            this.continueButton.TabIndex = 23;
            this.continueButton.Text = "SAVE CHANGES";
            this.continueButton.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.sEmailInput);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.sSurnameInput);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.sNameInput);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soundsCheckBox);
            this.Controls.Add(this.settingsLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1016, 796);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.CheckBox soundsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.RichTextBox sEmailInput;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.RichTextBox sSurnameInput;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RichTextBox sNameInput;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button continueButton;
    }
}
