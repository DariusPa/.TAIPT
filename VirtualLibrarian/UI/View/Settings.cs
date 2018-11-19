using System;
using System.Windows.Forms;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.Model;

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
        private Settings()
        {
            InitializeComponent();
            soundsCheckBox.Checked = true;
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

        public event SaveChangesEventHandler SaveChanges;
        public event SoundSettingsEventHandler SoundSettingsChanged;
        public delegate void SaveChangesEventHandler(object sender, UserRelatedEventArgs args);
        public delegate void SoundSettingsEventHandler(object sender, SoundSettingsEventArgs args);

        private void soundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (soundsCheckBox.Checked)
            {
                soundsCheckBox.BackgroundImage = Properties.Resources._checked;
                SoundSettingsChanged?.Invoke(this, new SoundSettingsEventArgs {SoundEnabled = true });
            }
            else
            {
                soundsCheckBox.BackgroundImage = Properties.Resources._unchecked;
                SoundSettingsChanged?.Invoke(this, new SoundSettingsEventArgs { SoundEnabled = false });
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            SaveChanges?.Invoke(this, new UserRelatedEventArgs(UserName, UserSurname, UserEmail));

        }
    }
}
