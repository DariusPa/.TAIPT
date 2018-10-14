using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;
using VirtualLibrarian.View;
using static VirtualLibrarian.ExistingUserForm;
using static VirtualLibrarian.FaceCamera;
using static VirtualLibrarian.FirstPage;

namespace VirtualLibrarian.Presenter
{
    public class FirstPagePresenter
    {
        private FirstPage FirstPage;
        private RegisterForm RegisterForm;
        private ExistingUserForm ExistingUserForm;
        private UI UI;
        public IUserModel User { get; set; }
        public IUserModel PendingUser { get; set; }
        
        

        public FirstPagePresenter(FirstPage firstPage)
        {
            FirstPage = firstPage;
            FirstPage.LogIn += LogInUser;
            FirstPage.Register += RegisterNewUser;
        }

        private void RegisterNewUser(object sender, RegisterEventArgs e)
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
            FirstPage.Show();
        }

        private void LogUserIn(object sender, LoggedInEventArgs e)
        {
            User = LibraryData.Instance.FindUser(e.UserID);
        }

        private void RegisterUser(object sender, FaceRecognisedEventArgs e)
        {
            User = PendingUser;
            LibraryData.Instance.AddUser(User);
        }

        private void ShowUI()
        {
            UI = new UI(User);
            UI.FormClosing += ShowFirstPage;
            UI.Show();
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
