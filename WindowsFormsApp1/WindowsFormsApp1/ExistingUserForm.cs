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
        private UI uiForm;
        private FaceCamera faceCam;

        public string userName = "";


        public ExistingUserForm(FirstPage firstPage)
        {
            InitializeComponent();
            this.firstPage = firstPage;
            this.faceCam = new FaceCamera(loginPicBox.Width, loginPicBox.Height, loginPicBox,this);
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExistingUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceCam.StopStreaming();
            if (!userName.Equals(""))
            {
                //TODO: get user's surname
                uiForm = new UI(firstPage,userName,"");
                uiForm.Show();
            }
            else firstPage.Show();
        }

        private void ExistingUserForm_Load(object sender, EventArgs e)
        {
        }

        private void ExistingUserForm_Shown(object sender, EventArgs e)
        {
            faceCam.RecognizeExistingFace();
        }

    }
}
