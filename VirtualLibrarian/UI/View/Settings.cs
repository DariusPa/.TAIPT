using System;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class Settings : UserControl
    {
        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();
                return _instance;
            }
        }
        public Settings()
        {
            InitializeComponent();
        }

        public Settings(string userName, string userSurname, string userEmail) : this()
        {
            UserName = userName;
            UserSurname = userSurname;
            UserEmail = userEmail;
        }

        public string UserName
        {
            get { return sNameInput.Text; }
            set { sNameInput.Text = value; }
        }

        public string UserSurname
        {
            get { return sSurnameInput.Text; }
            set { sSurnameInput.Text = value; }
        }

        public string UserEmail
        {
            get { return sEmailInput.Text; }
            set { sEmailInput.Text = value; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (soundsCheckBox.Checked)
            {
                soundsCheckBox.BackgroundImage = Properties.Resources._checked;
            } else
            {
                soundsCheckBox.BackgroundImage = Properties.Resources._unchecked;
            }
        }
    }
}
