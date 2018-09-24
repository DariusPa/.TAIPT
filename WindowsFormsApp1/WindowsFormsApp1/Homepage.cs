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
    public partial class Homepage : UserControl
    {
        private static Homepage _instance;

        public static Homepage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Homepage();
                return _instance;
            }
        }
        public Homepage()
        {
            InitializeComponent();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
        }
    }
}
