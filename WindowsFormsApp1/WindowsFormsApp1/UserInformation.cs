using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
            this.userName = userName;
            this.userSurname = userSurname;

        }

        public string userName
        {
            get
            {
                return nameLabel.Text;
            }
            set
            {
                nameLabel.Text = value;
            }
        }
        public string userSurname
        {
            get
            {
                return surnameLabel.Text;
            }
            set
            {
                surnameLabel.Text = value;
            }
        }
    }
}
