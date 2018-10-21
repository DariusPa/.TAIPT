namespace VirtualLibrarian
{
    partial class FirstPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstPage));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.notRegisteredLabel = new System.Windows.Forms.Label();
            this.signUpLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.RichTextBox();
            this.surnameInput = new System.Windows.Forms.RichTextBox();
            this.emailInput = new System.Windows.Forms.RichTextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.loginButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.welcomeLabel.Location = new System.Drawing.Point(14, 60);
            this.welcomeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(201, 45);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome!";
            // 
            // notRegisteredLabel
            // 
            this.notRegisteredLabel.AutoSize = true;
            this.notRegisteredLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notRegisteredLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.notRegisteredLabel.Location = new System.Drawing.Point(22, 101);
            this.notRegisteredLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.notRegisteredLabel.Name = "notRegisteredLabel";
            this.notRegisteredLabel.Size = new System.Drawing.Size(141, 22);
            this.notRegisteredLabel.TabIndex = 2;
            this.notRegisteredLabel.Text = "Not registered?";
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.signUpLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.signUpLabel.Location = new System.Drawing.Point(157, 101);
            this.signUpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(86, 22);
            this.signUpLabel.TabIndex = 3;
            this.signUpLabel.Text = "Sign up!";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.nameLabel.Location = new System.Drawing.Point(22, 189);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(50, 18);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            // 
            // nameInput
            // 
            this.nameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.ForeColor = System.Drawing.Color.Black;
            this.nameInput.Location = new System.Drawing.Point(34, 221);
            this.nameInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameInput.Multiline = false;
            this.nameInput.Name = "nameInput";
            this.nameInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.nameInput.Size = new System.Drawing.Size(164, 17);
            this.nameInput.TabIndex = 7;
            this.nameInput.Text = "";
            this.nameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keydown_func);
            // 
            // surnameInput
            // 
            this.surnameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.surnameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameInput.ForeColor = System.Drawing.Color.Black;
            this.surnameInput.Location = new System.Drawing.Point(34, 297);
            this.surnameInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.surnameInput.Multiline = false;
            this.surnameInput.Name = "surnameInput";
            this.surnameInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.surnameInput.Size = new System.Drawing.Size(164, 17);
            this.surnameInput.TabIndex = 9;
            this.surnameInput.Text = "";
            this.surnameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keydown_func);
            // 
            // emailInput
            // 
            this.emailInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailInput.ForeColor = System.Drawing.Color.Black;
            this.emailInput.Location = new System.Drawing.Point(34, 374);
            this.emailInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailInput.Multiline = false;
            this.emailInput.Name = "emailInput";
            this.emailInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.emailInput.Size = new System.Drawing.Size(164, 17);
            this.emailInput.TabIndex = 11;
            this.emailInput.Text = "";
            this.emailInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keydown_func);
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.surnameLabel.Location = new System.Drawing.Point(22, 265);
            this.surnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(71, 18);
            this.surnameLabel.TabIndex = 12;
            this.surnameLabel.Text = "Surname";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.emailLabel.Location = new System.Drawing.Point(22, 341);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(114, 18);
            this.emailLabel.TabIndex = 13;
            this.emailLabel.Text = "E-mail address";
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
            this.continueButton.Location = new System.Drawing.Point(26, 420);
            this.continueButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(117, 35);
            this.continueButton.TabIndex = 14;
            this.continueButton.Text = "CONTINUE";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox4.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox4.Location = new System.Drawing.Point(26, 366);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(195, 42);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox3.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox3.Location = new System.Drawing.Point(26, 289);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(195, 42);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox2.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox2.Location = new System.Drawing.Point(26, 213);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(195, 42);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.BackgroundImage = global::VirtualLibrarian.Properties.Resources.log;
            this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.loginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Location = new System.Drawing.Point(436, 301);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(124, 111);
            this.loginButton.TabIndex = 15;
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // adminButton
            // 
            this.adminButton.BackColor = System.Drawing.Color.White;
            this.adminButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("adminButton.BackgroundImage")));
            this.adminButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.adminButton.CausesValidation = false;
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.ForeColor = System.Drawing.Color.White;
            this.adminButton.Location = new System.Drawing.Point(9, 471);
            this.adminButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(29, 28);
            this.adminButton.TabIndex = 17;
            this.adminButton.UseVisualStyleBackColor = false;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // FirstPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::VirtualLibrarian.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 515);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.surnameInput);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.signUpLabel);
            this.Controls.Add(this.notRegisteredLabel);
            this.Controls.Add(this.welcomeLabel);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(636, 554);
            this.MinimumSize = new System.Drawing.Size(636, 554);
            this.Name = "FirstPage";
            this.Text = ".TAIPT Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirstPage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label notRegisteredLabel;
        private System.Windows.Forms.Label signUpLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox nameInput;
        private System.Windows.Forms.RichTextBox surnameInput;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RichTextBox emailInput;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button continueButton;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button adminButton;
    }
}