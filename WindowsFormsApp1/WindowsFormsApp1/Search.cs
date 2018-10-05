﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian
{
    public partial class Search : UserControl
    {
        private static Search _instance;

        public static Search Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Search();
                return _instance;
            }
        }
        public Search()
        {
            InitializeComponent();
        }
    }
}
