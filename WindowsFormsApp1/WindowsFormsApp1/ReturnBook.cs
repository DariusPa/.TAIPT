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
    public partial class ReturnBook : UserControl
    {
        private static ReturnBook _instance;

        public static ReturnBook Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReturnBook();
                return _instance;
            }
        }
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
