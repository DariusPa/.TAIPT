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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.RichTextBox();
            this.surnameInput = new System.Windows.Forms.RichTextBox();
            this.emailInput = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(19, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Good evening!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.label2.Location = new System.Drawing.Point(29, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Not registered?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.label3.Location = new System.Drawing.Point(209, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sign up!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(29, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            // 
            // nameInput
            // 
            this.nameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.ForeColor = System.Drawing.Color.Black;
            this.nameInput.Location = new System.Drawing.Point(45, 272);
            this.nameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameInput.Multiline = false;
            this.nameInput.Name = "nameInput";
            this.nameInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.nameInput.Size = new System.Drawing.Size(219, 21);
            this.nameInput.TabIndex = 7;
            this.nameInput.Text = "";
            this.nameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keydown_func);
            // 
            // surnameInput
            // 
            this.surnameInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.surnameInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameInput.ForeColor = System.Drawing.Color.Black;
            this.surnameInput.Location = new System.Drawing.Point(45, 366);
            this.surnameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.surnameInput.Multiline = false;
            this.surnameInput.Name = "surnameInput";
            this.surnameInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.surnameInput.Size = new System.Drawing.Size(219, 21);
            this.surnameInput.TabIndex = 9;
            this.surnameInput.Text = "";
            this.surnameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keydown_func);
            // 
            // emailInput
            // 
            this.emailInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailInput.ForeColor = System.Drawing.Color.Black;
            this.emailInput.Location = new System.Drawing.Point(45, 460);
            this.emailInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailInput.Multiline = false;
            this.emailInput.Name = "emailInput";
            this.emailInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.emailInput.Size = new System.Drawing.Size(219, 21);
            this.emailInput.TabIndex = 11;
            this.emailInput.Text = "";
            this.emailInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Keydown_func);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(29, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Surname";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(29, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "E-mail address";
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
            this.continueButton.Location = new System.Drawing.Point(35, 517);
            this.continueButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(156, 43);
            this.continueButton.TabIndex = 14;
            this.continueButton.Text = "CONTINUE";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox4.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox4.Location = new System.Drawing.Point(35, 450);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(260, 52);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox3.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox3.Location = new System.Drawing.Point(35, 356);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(260, 52);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox2.InitialImage = global::VirtualLibrarian.Properties.Resources.input;
            this.pictureBox2.Location = new System.Drawing.Point(35, 262);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(260, 52);
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
            this.loginButton.Location = new System.Drawing.Point(581, 370);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(165, 137);
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
            this.adminButton.Location = new System.Drawing.Point(12, 580);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(39, 34);
            this.adminButton.TabIndex = 17;
            this.adminButton.UseVisualStyleBackColor = false;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // FirstPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::VirtualLibrarian.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 626);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.surnameInput);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(873, 578);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(843, 673);
            this.MinimumSize = new System.Drawing.Size(843, 673);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox nameInput;
        private System.Windows.Forms.RichTextBox surnameInput;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RichTextBox emailInput;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button continueButton;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button adminButton;
    }
}