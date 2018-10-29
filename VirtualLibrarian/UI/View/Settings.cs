using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Model;

namespace VirtualLibrarian
{
    public partial class Settings : UserControl
    {
        private static Settings _instance;
        public IUserModel User { get; set; }

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(checkBox1.Checked)
            {
                checkBox1.BackgroundImage = Properties.Resources._checked;
            } else
            {
                checkBox1.BackgroundImage = Properties.Resources._unchecked;
            }
        }
    }
}
