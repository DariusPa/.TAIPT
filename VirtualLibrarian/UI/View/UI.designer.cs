namespace VirtualLibrarian
{
    partial class UI
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
            this.containerPanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.settingsButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.takeBookButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.aiOutput = new VirtualLibrarian.AI();
            this.userInformation1 = new VirtualLibrarian.UserInformation();
            this.settings1 = new VirtualLibrarian.Settings();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.Location = new System.Drawing.Point(678, 156);
            this.containerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1016, 796);
            this.containerPanel.TabIndex = 2;
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(206)))), ((int)(((byte)(180)))));
            this.settingsButton.Image = global::VirtualLibrarian.Properties.Resources.taipt_13;
            this.settingsButton.Location = new System.Drawing.Point(42, 754);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(284, 198);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(153)))), ((int)(((byte)(188)))));
            this.logoutButton.Image = global::VirtualLibrarian.Properties.Resources.taipt_13_14;
            this.logoutButton.Location = new System.Drawing.Point(352, 754);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(284, 198);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(99)))), ((int)(((byte)(74)))));
            this.historyButton.Image = global::VirtualLibrarian.Properties.Resources.taipt_09_10;
            this.historyButton.Location = new System.Drawing.Point(352, 529);
            this.historyButton.Margin = new System.Windows.Forms.Padding(4);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(284, 198);
            this.historyButton.TabIndex = 5;
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(129)))), ((int)(((byte)(156)))));
            this.returnButton.Image = global::VirtualLibrarian.Properties.Resources.taipt_09;
            this.returnButton.Location = new System.Drawing.Point(42, 529);
            this.returnButton.Margin = new System.Windows.Forms.Padding(4);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(284, 198);
            this.returnButton.TabIndex = 4;
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // takeBookButton
            // 
            this.takeBookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(57)))), ((int)(((byte)(136)))));
            this.takeBookButton.BackgroundImage = global::VirtualLibrarian.Properties.Resources.takebook;
            this.takeBookButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.takeBookButton.Location = new System.Drawing.Point(352, 310);
            this.takeBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.takeBookButton.Name = "takeBookButton";
            this.takeBookButton.Size = new System.Drawing.Size(284, 198);
            this.takeBookButton.TabIndex = 1;
            this.takeBookButton.UseVisualStyleBackColor = false;
            this.takeBookButton.Click += new System.EventHandler(this.TakeBookButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(111)))), ((int)(((byte)(105)))));
            this.searchButton.Image = global::VirtualLibrarian.Properties.Resources.taipt_03;
            this.searchButton.Location = new System.Drawing.Point(42, 310);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(284, 198);
            this.searchButton.TabIndex = 0;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // aiOutput
            // 
            this.aiOutput.BackColor = System.Drawing.Color.White;
            this.aiOutput.Location = new System.Drawing.Point(678, 0);
            this.aiOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aiOutput.Name = "aiOutput";
            this.aiOutput.Size = new System.Drawing.Size(1000, 150);
            this.aiOutput.TabIndex = 8;
            // 
            // userInformation1
            // 
            this.userInformation1.BackColor = System.Drawing.Color.White;
            this.userInformation1.Location = new System.Drawing.Point(42, 56);
            this.userInformation1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userInformation1.Name = "userInformation1";
            this.userInformation1.Size = new System.Drawing.Size(594, 248);
            this.userInformation1.TabIndex = 3;
            this.userInformation1.UserName = "NAME";
            this.userInformation1.UserSurname = "SURNAME";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1444, 852);
            this.Controls.Add(this.aiOutput);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.userInformation1);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.takeBookButton);
            this.Controls.Add(this.searchButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1714, 1015);
            this.MinimumSize = new System.Drawing.Size(1426, 794);
            this.Name = "UI";
            this.Text = ".TAIPT Library | Logged in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UI_FormClosed);
            this.Load += new System.EventHandler(this.UI_Load);
            this.Shown += new System.EventHandler(this.UI_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button takeBookButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel containerPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UserInformation userInformation1;
        private Settings settings1;
        private AI aiOutput;
    }
}