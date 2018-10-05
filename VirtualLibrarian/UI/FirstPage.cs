using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class FirstPage : Form
    {
        private RegisterForm registerForm;
        private ExistingUserForm existingUserForm;

        public FirstPage()
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            InitializeComponent();
            loginButton.FlatAppearance.BorderSize = 0;
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            //TODO: save new user AFTER taking his pictures
            if (!string.IsNullOrWhiteSpace(nameInput.Text) && !string.IsNullOrWhiteSpace(surnameInput.Text) && !string.IsNullOrWhiteSpace(emailInput.Text))
            {
                //registration parameters
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("Name", nameInput.Text));
                sqlParams.Add(new SqlParameter("Surname", surnameInput.Text));
                sqlParams.Add(new SqlParameter("EmailAdress", emailInput.Text));

                //parameters to check if account already exists
                List<SqlParameter> validationSqlParams = new List<SqlParameter>();
                validationSqlParams.Add(new SqlParameter("EmailAdress", emailInput.Text));


                DataTable dtRegisterResults = DAL.ExecSP("ValidateNewAcc", validationSqlParams);

                if (dtRegisterResults.Rows.Count == 1)
                {
                    //string userName = dtRegisterResults.Rows[0]["Name"].ToString();
                    //string userSurname =  dtRegisterResults.Rows[0]["Surname"].ToString();
                    //string userEmailAdress = dtRegisterResults.Rows[0]["EmailAdress"].ToString();
                    //account with that email adress already exists
                    MessageBox.Show("Account with this email already exists!");
                }
                else
                {
                    //inserting user to db
                    DAL.ExecSP("InsertUser", sqlParams);

                    //get user ID
                    //DataTable dtUserInfo = DAL.ExecSP("GetLastUserInfo",validationSqlParams);
                    //MessageBox.Show(dtUserInfo.Rows[0]["UID"].ToString());
                    //int UID = Int32.Parse(dtUserInfo.Rows[0]["UID"].ToString());
                    //int UID = 0;



                    MessageBox.Show("Creating user:"  + nameInput.Text + " "+ surnameInput.Text + " " + emailInput.Text);
                    registerForm = new RegisterForm(this, nameInput.Text);
                    registerForm.Show();
                    this.Hide();
                }
                //open new form window and get face
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
            existingUserForm = new ExistingUserForm(this);
            existingUserForm.Show();
            this.Hide();
        }

        private void FirstPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
