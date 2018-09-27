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
    public partial class ExistingUserForm : Form
    {
        private FirstPage firstPage;
        private UI userMenu;
        private FaceCamera faceCam;

        public ExistingUserForm(FirstPage firstPage)
        {
            InitializeComponent();
            this.firstPage = firstPage;
            this.faceCam = new FaceCamera(loginPicBox.Width, loginPicBox.Height, loginPicBox);
            faceCam.initiateForm(this);
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExistingUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceCam.StopStreaming();
            firstPage.Show();
        }

        private void ExistingUserForm_Load(object sender, EventArgs e)
        {
        }

        private void ExistingUserForm_Shown(object sender, EventArgs e)
        {
            faceCam.RecognizeExistingFace();
        }

        public void sendString(string text)
        {
            if(text == "success")
            {
                MessageBox.Show("ok");
                UI user = new UI();
                user.Show();
                this.Close();
            }
        }
    }
}
