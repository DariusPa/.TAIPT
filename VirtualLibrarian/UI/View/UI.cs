using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using VirtualLibrarian.Model;
using VirtualLibrarian.Data;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VirtualLibrarian
{
    public partial class UI : Form
    {
        public IUserModel User { get; set; }
		public SpeakingAI Speaker { get; set; }
        public AI AI { get { return aiOutput; } }

        public event EventHandler SearchRequested;
        public event EventHandler HistoryRequested;


        public UI(IUserModel Users) 
        {
            InitializeComponent();
            Speaker = new SpeakingAI(AI);
            User = Users;
            userInformation.UserName = User.Name;
            userInformation.UserSurname = User.Surname;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            //loading UI form window parameters
            AutomaticFormPosition.loadUIFormDelegate(this);

            // On load show homepage user control 
            containerPanel.Controls.Add(Homepage.Instance);
            Search.Instance.Dock = DockStyle.Fill;
            Search.Instance.BringToFront();

            // Remove outline on all buttons
            foreach (Control button in this.Controls)
            {
                if (button is Button)
                {
                    ChangeCursor((Button)button);
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Speaker.SpeakAndWrite(StringConstants.aiSearchLibraryGreeting);
            if (!containerPanel.Controls.Contains(Search.Instance))
            {
                containerPanel.Controls.Add(Search.Instance);
                Search.Instance.Dock = DockStyle.Fill;
            }
            SearchRequested?.Invoke(this, EventArgs.Empty);
            Search.Instance.BringToFront();
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            Speaker.SpeakAndWrite(StringConstants.aiScanBookQRString);
            if (!containerPanel.Controls.Contains(TakeBook.Instance))
            {
                containerPanel.Controls.Add(TakeBook.Instance);
                TakeBook.Instance.Dock = DockStyle.Fill;
            }
            TakeBook.Instance.BringToFront();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Speaker.SpeakAndWrite(StringConstants.aiReturnBookString);
            if (!containerPanel.Controls.Contains(ReturnBook.Instance))
            {
                containerPanel.Controls.Add(ReturnBook.Instance);
                ReturnBook.Instance.Dock = DockStyle.Fill;
            }
            ReturnBook.Instance.BringToFront();

        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Speaker.SpeakAndWrite(StringConstants.aiReadingHistoryGreeting);
            if (!containerPanel.Controls.Contains(History.Instance))
            {
                containerPanel.Controls.Add(History.Instance);
                History.Instance.Dock = DockStyle.Fill;
            }
            HistoryRequested?.Invoke(this, EventArgs.Empty);
            History.Instance.BringToFront();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Speaker.SpeakAndWrite(StringConstants.aiAccountSettingsGreeting);
            if (!containerPanel.Controls.Contains(Settings.Instance))
            {
                containerPanel.Controls.Add(Settings.Instance);
                Settings.Instance.Dock = DockStyle.Fill;
                Settings.Instance.BringToFront();
                Settings.Instance.UserName = User.Name;
                Settings.Instance.UserSurname = User.Surname;
                Settings.Instance.UserEmail = User.Email;
            }
            else
                Settings.Instance.BringToFront();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            AutomaticFormPosition.SaveFormStatus(this);
            Close();
        }


        private void ChangeCursor(Button Btn)
        {
            Btn.TabStop = false;
            Btn.FlatStyle = FlatStyle.Flat;
            Btn.FlatAppearance.BorderSize = 0;
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            Speaker.SpeakAndWrite(StringConstants.AIGreeting(User.Name));
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
			Speaker.run = false;
	
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutomaticFormPosition.SaveFormStatus(this);
            Speaker.SpeakAndWrite(StringConstants.aiGoodbye);
            this.Controls.Clear();
        }

        public void UpdateUser()
        {
            userInformation.UserName = User.Name;
            userInformation.UserSurname = User.Surname;
        }

    }
}