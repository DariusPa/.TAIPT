using System;
using System.Drawing;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;
using VirtualLibrarian.View;
using static VirtualLibrarian.FaceCamera;

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
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
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
            User = LibraryData.Instance.FindUser(e.Label);
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

    }
}
