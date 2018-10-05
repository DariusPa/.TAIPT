using System;
using System.Drawing;
using System.Windows.Forms;


namespace VirtualLibrarian
{
    public partial class ExistingUserForm : Form
    {
        private FirstPage firstPage;
        private UI uiForm;
        private FaceCamera faceCam;

        public string userName="";


        public ExistingUserForm(FirstPage firstPage)
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            InitializeComponent();
            this.firstPage = firstPage;
            this.faceCam = new FaceCamera(loginPicBox.Width, loginPicBox.Height, loginPicBox,this);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
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

        private void ExistingUserForm_Shown(object sender, EventArgs e)
        {
            faceCam.RecognizeExistingFace();
        }

        private void ExistingUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
