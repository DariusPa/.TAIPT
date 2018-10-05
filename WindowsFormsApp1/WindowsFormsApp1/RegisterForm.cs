using System;
using System.Drawing;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class RegisterForm : Form
    {
        private FirstPage firstPage;
        private FaceCamera faceCam;
        private string userLabel;

        public RegisterForm(FirstPage firstPage, string userName)
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
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

        private void SaveFaceButton_Click(object sender, EventArgs e)
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

    }
}
