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
    public partial class PersonalInfo : UserControl
    {
        private static PersonalInfo _instance;

        public static PersonalInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersonalInfo();
                return _instance;
            }
        }

        public PersonalInfo()
        {
            InitializeComponent();
        }
    }
}