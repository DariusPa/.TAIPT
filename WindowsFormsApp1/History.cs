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
    public partial class History : UserControl
    {
        private static History _instance;

        public static History Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new History();
                return _instance;
            }
        }
        public History()
        {
            InitializeComponent();
        }
    }
}
