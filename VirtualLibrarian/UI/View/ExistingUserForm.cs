using System;
using System.Drawing;
using System.Windows.Forms;
using static VirtualLibrarian.FaceCamera;

namespace VirtualLibrarian
{
    public partial class ExistingUserForm : Form
    {
        public event LoggedInEventHandler LoggedIn;

        private FaceCamera faceCam;

        public ExistingUserForm()
        {
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            InitializeComponent();
            faceCam = new FaceCamera(loginPicBox.Width, loginPicBox.Height);
            faceCam.FrameGrabbed += OnFrameGrabbed;
            faceCam.ExistingUserRecognised += OnExistingUserRecognised;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExistingUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceCam.StopStreaming();
        }

        private void ExistingUserForm_Shown(object sender, EventArgs e)
        {
            faceCam.RecognizeExistingFace();
        }

        private void OnFrameGrabbed (object sender, FrameGrabbedEventArgs e)
        {
            loginPicBox.Image = e.Frame;
        }

        private void OnExistingUserRecognised (object sender, FaceRecognisedEventArgs e)
        {
            LoggedIn?.Invoke(this, new LoggedInEventArgs { UserID = e.Label });
            BeginInvoke(new Action(() => Close()));
        }

        public class LoggedInEventArgs : EventArgs
        {
            public string UserID { get; set; }
        }

        public delegate void LoggedInEventHandler(object sender, LoggedInEventArgs e);



    }
}
