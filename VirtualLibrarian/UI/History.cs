using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace VirtualLibrarian
{
    public partial class History : UserControl
    {
        private static History _instance;
        public DataGridView dataGridView
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }

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
