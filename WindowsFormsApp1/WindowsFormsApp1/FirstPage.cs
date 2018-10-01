using Librarian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FirstPage : Form
    {
        private RegisterForm registerForm;
        private ExistingUserForm existingUserForm;

        public FirstPage()
        {
            WindowState = FormWindowState.Maximized;
            //StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            loginButton.FlatAppearance.BorderSize = 0;
        }

        private void FirstPage_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && !string.IsNullOrWhiteSpace(surnameInput.Text) && !string.IsNullOrWhiteSpace(emailInput.Text))
            {
                registerForm = new RegisterForm(this, nameInput.Text);
                registerForm.Show();
                this.Hide();
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

        private void keydown_func(object sender, KeyPressEventArgs e)
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            existingUserForm = new ExistingUserForm(this);
            existingUserForm.Show();
            this.Hide();
        }

    }
}
