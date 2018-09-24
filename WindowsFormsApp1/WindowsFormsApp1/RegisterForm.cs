using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Librarian
{
    public partial class RegisterForm : Form
    {
        private FirstPage firstPage;
        private FaceCamera faceCam;
        private String userLabel;

        public RegisterForm(FirstPage firstPage)
        {
            InitializeComponent();
            this.firstPage = firstPage;
            this.faceCam = new FaceCamera(registerPicBox.Width, registerPicBox.Height, registerPicBox);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstPage.Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var userLabel = nameBox.Text;
            if (userLabel != "")
            {
                nameBox.Hide();
                registerButton.Hide();
                registerPicBox.Show();
                saveFaceButton.Show();
                faceCam.AddNewFace(userLabel);
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceCam.StopStreaming();
            firstPage.Show();
        }

        private void saveFaceButton_Click(object sender, EventArgs e)
        {
            cancelButton.Hide();
            saveFaceButton.Hide();
            faceCam.saveButtonClicked = true;

        }

        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            cancelButton.Show();
            nameBox.Show();
            saveFaceButton.Show();
            registerPicBox.Hide();
            saveFaceButton.Hide();
        }
    }
}
