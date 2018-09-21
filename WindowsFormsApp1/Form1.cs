using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On load show homepage user control 
            containerPanel.Controls.Add(Homepage.Instance);
            Homepage.Instance.Dock = DockStyle.Fill;
            Homepage.Instance.BringToFront();

            // Remove outline on all buttons
            foreach (Control button in this.Controls)
            {
                if (button is Button)
                {
                    ChangeCursor((Button)button);
                }
            }
        }

        private void homepageButton_Click(object sender, EventArgs e)
        {
            if (!containerPanel.Controls.Contains(Homepage.Instance))
            {
                containerPanel.Controls.Add(Homepage.Instance);
                Homepage.Instance.Dock = DockStyle.Fill;
                Homepage.Instance.BringToFront();
            }
            else
                Homepage.Instance.BringToFront();
        }

        private void personalInfoButton_Click(object sender, EventArgs e)
        {
            if (!containerPanel.Controls.Contains(PersonalInfo.Instance))
            {
                containerPanel.Controls.Add(PersonalInfo.Instance);
                PersonalInfo.Instance.Dock = DockStyle.Fill;
                PersonalInfo.Instance.BringToFront();
            }
            else
                PersonalInfo.Instance.BringToFront();
        }

        private void ChangeCursor(System.Windows.Forms.Button Btn)
        {
            Btn.TabStop = false;
            Btn.FlatStyle = FlatStyle.Flat;
            Btn.FlatAppearance.BorderSize = 0;
        }

        private void containerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
