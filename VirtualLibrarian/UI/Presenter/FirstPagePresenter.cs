using System;
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
        public User User { get; set; }
        public User PendingUser { get; set; }
        
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

            LibraryDataIO.Instance.AddUser(PendingUser);

            RegisterForm = new RegisterForm(PendingUser);
            RegisterForm.RegisterCompleted += RegisterUser;
            RegisterForm.RegisterFailed += CancelRegistration;
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
            User = LibraryDataIO.Instance.FindUser(int.Parse(e.UserID));
        }

        private void RegisterUser(object sender, FaceRecognisedEventArgs e)
        {
            User = PendingUser;
        }

        private void CancelRegistration(object sender, EventArgs e)
        {
            LibraryDataIO.Instance.RemoveUser(PendingUser);
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
