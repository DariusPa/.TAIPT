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
        public User User;

        public event RegistrationEventHandler RegisterCompleted;
        public event EventHandler RegisterFailed;

        public RegisterForm(User user)
        {
            User = user;
            InitializeComponent();
            faceCam = new FaceCamera(registerPicBox.Width, registerPicBox.Height, new FaceRecognition());
            faceCam.ExistingUserRecognised += OnExistingUserRecognised;
            faceCam.NewUserRegistered += OnNewUserRegistered;
            faceCam.FrameGrabbed += OnFrameGrabbed;
            faceCam.FacePhotoSaved += UpdateProgressBar;
            progressBar.Maximum = LibraryDataIO.Instance.PicturesPerUser;
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
            faceCam.SaveFace();
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
            User = LibraryDataIO.Instance.FindUser(int.Parse(e.Label));
            MessageBox.Show(StringConstants.ExistingUserErrorString(User.Name, User.Surname));
            RegisterFailed?.Invoke(this, EventArgs.Empty);
            BeginInvoke(new Action(() => Close()));
        }

        private void OnNewUserRegistered(object sender, FaceRecognisedEventArgs e)
        {
            MessageBox.Show(StringConstants.successfulRegistration);
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
            AutomaticFormPosition.loadingFormDelegate(this);
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateProgressBar(object sender, EventArgs e)
        {
            if(!IsDisposed)
            BeginInvoke(new Action(()=>
            {
                progressBar.Value += 1;
            }));
        }
    }
}
