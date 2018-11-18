﻿using System;
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
            InitializeComponent();
            faceCam = new FaceCamera(loginPicBox.Width, loginPicBox.Height, new FaceRecognition());
            faceCam.FrameGrabbed += OnFrameGrabbed;
            faceCam.ExistingUserRecognised += OnExistingUserRecognised;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            AutomaticFormPosition.SaveFormStatus(this);
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
            AutomaticFormPosition.SaveFormStatus(this);
            LoggedIn?.Invoke(this, new UserRelatedEventArgs { UserID = e.Label });
            //BeginInvoke(new Action(() => Close()));
            Invoke(new Action(()=>Close()));
        }

        private void ExistingUserForm_Load(object sender, EventArgs e)
        {
            AutomaticFormPosition.loadingFormDelegate(this);
        }


        private void ExistingUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutomaticFormPosition.SaveFormStatus(this);
        }

        public delegate void LoggedInEventHandler(object sender, UserRelatedEventArgs e);



    }
}
