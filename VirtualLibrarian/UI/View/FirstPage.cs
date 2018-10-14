using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using VirtualLibrarian.Model;
using VirtualLibrarian.Presenter;

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

        public FirstPage()
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            InitializeComponent();
            loginButton.FlatAppearance.BorderSize = 0;
            firstPagePresenter = new FirstPagePresenter(this);
            adminPresenter = new AdministratorPresenter(this);
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && !string.IsNullOrWhiteSpace(surnameInput.Text) && !string.IsNullOrWhiteSpace(emailInput.Text))
            {
                User = new User { Name = nameInput.Text, Surname = surnameInput.Text, Email = emailInput.Text };
                Register?.Invoke(this,new RegisterEventArgs { PendingUser = User });
                Hide();
            } else {
                if (string.IsNullOrWhiteSpace(nameInput.Text))
                {
                    label4.Text = "Name (required)";
                }
                if (string.IsNullOrWhiteSpace(surnameInput.Text))
                {
                    label5.Text = "Surname (required)";
                }
                if (string.IsNullOrWhiteSpace(emailInput.Text))
                {
                    label6.Text = "E-mail (required)";
                }
            }
        }

        private void Keydown_func(object sender, KeyPressEventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;
            if (textBox.Name == "nameInput")
            {
                label4.Text = "Name";
            } else if (textBox.Name == "surnameInput")
            {
                label5.Text = "Surname";
            } else if (textBox.Name == "emailInput")
            {
                label6.Text = "E-mail address";
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LogIn?.Invoke(this, e);
            Hide();
        }

        private void FirstPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
            //Environment.Exit(Environment.ExitCode);
        }


        //TEMP FUNCTION
        private void adminButton_Click(object sender, EventArgs e)
        {
            Administrate?.Invoke(this, e);
            Hide();
        }


        public class RegisterEventArgs : EventArgs
        {
            public IUserModel PendingUser { get; set; }
        }

        public delegate void RegisterEventHandler(object sender, RegisterEventArgs e);
    }
}
