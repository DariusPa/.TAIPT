using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;
using VirtualLibrarian.Presenter;
using VirtualLibrarian.Properties;

namespace VirtualLibrarian
{
    public partial class FirstPage : Form
    {

        public IUserModel User { get; set; }
        private FirstPagePresenter firstPagePresenter;
        private AdministratorPresenter adminPresenter;
        
        public event RegisterEventHandler Register;
        public event EventHandler LogIn;
        public event EventHandler Administrate;
        private RegexUtilities Verifier = new RegexUtilities();

        public FirstPage()
        {
                InitializeComponent();
            loginButton.FlatAppearance.BorderSize = 0;
            firstPagePresenter = new FirstPagePresenter(this);
            adminPresenter = new AdministratorPresenter(this);
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && !string.IsNullOrWhiteSpace(surnameInput.Text) && !string.IsNullOrWhiteSpace(emailInput.Text) && Verifier.IsValidEmail(emailInput.Text))
            {
                Properties.Settings.Default.WindowState = this.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.WindowLocation = this.Location;
                    Properties.Settings.Default.WindowSize = this.Size;
                }
                else
                {
                    Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                    Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
                }
                Properties.Settings.Default.Save();

                User = new User { Name = nameInput.Text, Surname = surnameInput.Text, Email = emailInput.Text };
                Register?.Invoke(this,new UserRelatedEventArgs { PendingUser = User });
                Hide();
            } else {
                if (string.IsNullOrWhiteSpace(nameInput.Text))
                {
                    nameLabel.Text = "Name (required)";
                }
                if (string.IsNullOrWhiteSpace(surnameInput.Text))
                {
                    surnameLabel.Text = "Surname (required)";
                }
                if (string.IsNullOrWhiteSpace(emailInput.Text) || Verifier.IsValidEmail(emailInput.Text) == false)
                {
                    emailLabel.Text = "E-mail (required)";
                }
            }
        }

        private void Keydown_func(object sender, KeyPressEventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;
            if (textBox.Name == "nameInput")
            {
                nameLabel.Text = "Name";
            } else if (textBox.Name == "surnameInput")
            {
                surnameLabel.Text = "Surname";
            } else if (textBox.Name == "emailInput")
            {
                emailLabel.Text = "E-mail address";
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }
            Properties.Settings.Default.Save();
            LogIn?.Invoke(this, e);
            Hide();
        }

        private void FirstPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowLocation = Properties.Settings.Default.StartingWindowLocation;
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();
            Application.Exit();
        }
        
        private void FirstPage_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.WindowState;
            this.Location = Properties.Settings.Default.WindowLocation;
            this.Size = Properties.Settings.Default.WindowSize;
        }


        //TEMP
        private void adminButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();
            Administrate?.Invoke(this, e);
            Hide();
        }

        public delegate void RegisterEventHandler(object sender, UserRelatedEventArgs e);
    }
}
