﻿using System;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Presenter
{
    public class FirstPagePresenter
    {
        private FirstPage FirstPage;
        private RegisterForm RegisterForm;
        private ExistingUserForm ExistingUserForm;
        private UIPresenter uiPresenter;
        public IUserModel User { get; set; }
        public IUserModel PendingUser { get; set; }
        
        public FirstPagePresenter(FirstPage firstPage)
        {
            FirstPage = firstPage;
            FirstPage.LogIn += LogInUser;
            FirstPage.Register += RegisterNewUser;
            uiPresenter = new UIPresenter();
            uiPresenter.UIClosed += ShowFirstPage;
        }

        private void RegisterNewUser(object sender, UserRelatedEventArgs e)
        {
            PendingUser = e.PendingUser;
            User = null;
            RegisterForm = new RegisterForm(PendingUser);
            RegisterForm.RegisterCompleted += RegisterUser;
            RegisterForm.FormClosed += ShowFirstPage;
            RegisterForm.Show();
        }

        private void LogInUser(object sender, EventArgs e)
        {
            User = null;
            ExistingUserForm = new ExistingUserForm();
            ExistingUserForm.LoggedIn += LogUserIn;
            ExistingUserForm.FormClosed += SelectFormToShow;
            ExistingUserForm.Show();
        }

        private void ShowFirstPage(object sender, EventArgs e)
        {
            AutomaticFormPosition.loadingFormDelegate(FirstPage);
            FirstPage.Show();
        }

        private void LogUserIn(object sender, UserRelatedEventArgs e)
        {
            User = LibraryDataIO.Instance.FindUser(e.UserID);
        }

        private void RegisterUser(object sender, FaceRecognisedEventArgs e)
        {
            User = PendingUser;
            LibraryDataIO.Instance.AddUser(User);
        }

        private void ShowUI()
        {
            uiPresenter.PrepareUI(User);
        }

        private void SelectFormToShow(object sender, EventArgs e)
        {
            if (User == null)
                ShowFirstPage(sender, e);
            else
                ShowUI();
        }
    }
}
