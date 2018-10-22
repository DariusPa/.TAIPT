using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian
{
    public partial class RegisterForm : Form
    {
        private FaceCamera faceCam;
        public IUserModel User;

        public event RegistrationEventHandler RegisterCompleted;

        public RegisterForm(IUserModel user)
        {
            User = user;
            InitializeComponent();
            faceCam = new FaceCamera(registerPicBox.Width, registerPicBox.Height);
            faceCam.ExistingUserRecognised += OnExistingUserRecognised;
            faceCam.NewUserRegistered += OnNewUserRegistered;
            faceCam.FrameGrabbed += OnFrameGrabbed;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceCam.StopStreaming();
        }

        private void SaveFaceButton_Click(object sender, EventArgs e)
        {
            faceCam.StartSaving();
            cancelButton.Hide();
            saveFaceButton.Hide();
        }

        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            registerPicBox.Show();
            saveFaceButton.Show();
            faceCam.AddNewFace(User.ID.ToString());
        }

        private void OnExistingUserRecognised(object sender, FaceRecognisedEventArgs e)
        {
            User = LibraryDataIO.Instance.FindUser(e.Label);
            MessageBox.Show(string.Format("User is already registered as {0} {1} !", User.Name, User.Surname));
            BeginInvoke(new Action(() => Close()));
        }

        private void OnNewUserRegistered(object sender, FaceRecognisedEventArgs e)
        {
            MessageBox.Show("Registration succeeded!");
            RegisterCompleted?.Invoke(this, e);
            BeginInvoke(new Action(()=>Close()));
        }

        private void OnFrameGrabbed(object sender, FrameGrabbedEventArgs e)
        {
            registerPicBox.Image = e.Frame;
        }

        public delegate void RegistrationEventHandler(object sender, FaceRecognisedEventArgs e);

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.WindowState;
            this.Location = Properties.Settings.Default.WindowLocation;
            this.Size = Properties.Settings.Default.WindowSize;
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
