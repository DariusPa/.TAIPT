using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        public RegisterForm(FirstPage firstPage, string userName)
        {
            InitializeComponent();
            this.firstPage = firstPage;
            this.userLabel = userName;
            this.faceCam = new FaceCamera(registerPicBox.Width, registerPicBox.Height, registerPicBox,this);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceCam.StopStreaming();
            firstPage.Show();
        }

        private void saveFaceButton_Click(object sender, EventArgs e)
        {
            faceCam.saveButtonClicked = true;
            cancelButton.Hide();
            saveFaceButton.Hide();

        }

        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            registerPicBox.Show();
            saveFaceButton.Show();
            faceCam.AddNewFace(userLabel);
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void registerPicBox_Click(object sender, EventArgs e)
        {

        }
    }
}
