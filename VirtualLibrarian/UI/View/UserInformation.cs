using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class UserInformation : UserControl
    {
        private static UserInformation _instance;

        public static UserInformation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserInformation();
                return _instance;
            }
        }

        public UserInformation()
        {
            InitializeComponent();
        }

        public UserInformation(string userName, string userSurname) :this()
        {
            UserName = userName;
            UserSurname = userSurname;
        }

        public string UserName
        {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value; }
        }
        public string UserSurname
        {
            get { return surnameLabel.Text; }
            set { surnameLabel.Text = value; }
        }
    }
}
