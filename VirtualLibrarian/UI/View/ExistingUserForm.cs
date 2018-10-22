using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Helpers;

namespace VirtualLibrarian
{
    public partial class ExistingUserForm : Form
    {
        public event LoggedInEventHandler LoggedIn;

        private FaceCamera faceCam;

        public ExistingUserForm()
        {
            //WindowState = FormWindowState.Maximized;
            //StartPosition = FormStartPosition.Manual;
            //Location = new Point(0, 0);
            InitializeComponent();
            faceCam = new FaceCamera(loginPicBox.Width, loginPicBox.Height);
            faceCam.FrameGrabbed += OnFrameGrabbed;
            faceCam.ExistingUserRecognised += OnExistingUserRecognised;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
            Close();
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
            Properties.Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
            LoggedIn?.Invoke(this, new UserRelatedEventArgs { UserID = e.Label });
            //BeginInvoke(new Action(() => Close()));
            Invoke(new Action(()=>Close()));
        }

        private void ExistingUserForm_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.WindowState;
            this.Location = Properties.Settings.Default.WindowLocation;
            this.Size = Properties.Settings.Default.WindowSize;
        }


        private void ExistingUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.WindowLocation = this.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();
        }

        public delegate void LoggedInEventHandler(object sender, UserRelatedEventArgs e);



    }
}
