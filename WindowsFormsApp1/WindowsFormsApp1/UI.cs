using Librarian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class UI : Form
    {
        private string userName;
        private string userSurname;
        private FirstPage firstPage;
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public UI(FirstPage firstPage, string userName, string userSurname)
        {
            InitializeComponent();

            this.firstPage = firstPage;
            this.userName = userName;
            this.userSurname = userSurname;
            userInformation1.userName = userName;
            userInformation1.userSurname = userSurname;

            synthesizer.Volume = 100;
            synthesizer.Rate = -2;
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

        private void TellUser(string msg)
        {
            SlowWriter.Write(msg, ai1?.guideLabel);
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SpeakAsync(msg);

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            TellUser("Here you can find a book which you want to take.");
            if (!containerPanel.Controls.Contains(Search.Instance))
            {
                containerPanel.Controls.Add(Search.Instance);
                Search.Instance.Dock = DockStyle.Fill;
                Search.Instance.BringToFront();
            }
            else
                Search.Instance.BringToFront();
        }

        private void personalInfoButton_Click(object sender, EventArgs e)
        {
            TellUser("Here you can see your personal information.");
            if (!containerPanel.Controls.Contains(PersonalInfo.Instance))
            {
                containerPanel.Controls.Add(PersonalInfo.Instance);
                PersonalInfo.Instance.Dock = DockStyle.Fill;
                PersonalInfo.Instance.BringToFront();
            }
            else
                PersonalInfo.Instance.BringToFront();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            TellUser("Here you can return a book.");
            if (!containerPanel.Controls.Contains(ReturnBook.Instance))
            {
                containerPanel.Controls.Add(ReturnBook.Instance);
                ReturnBook.Instance.Dock = DockStyle.Fill;
                ReturnBook.Instance.BringToFront();
            }
            else
                ReturnBook.Instance.BringToFront();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            TellUser("Here you can see your readings history.");
            if (!containerPanel.Controls.Contains(History.Instance))
            {
                containerPanel.Controls.Add(History.Instance);
                History.Instance.Dock = DockStyle.Fill;
                History.Instance.BringToFront();
            }
            else
                History.Instance.BringToFront();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            TellUser("Here you can change your account settings.");
            if (!containerPanel.Controls.Contains(Settings.Instance))
            {
                containerPanel.Controls.Add(Settings.Instance);
                Settings.Instance.Dock = DockStyle.Fill;
                Settings.Instance.BringToFront();
            }
            else
                Settings.Instance.BringToFront();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            TellUser("See you soon.");
            this.Close();
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

        public void sendString(string text)
        {
            if (text == "success")
            {
                MessageBox.Show("ok");
                this.Show();
            }
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            TellUser("Welcome" + userName);
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            firstPage.Show();
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SlowWriter.mustTerminate = true;
        }
    }


    public class SlowWriter
    {
        public static bool mustTerminate;
        public static void Write(string text, Label lbl)
        {
            Task.Run(() =>
            {
                Random rnd = new Random();
                StringBuilder sb = new StringBuilder();
                foreach (char c in text)
                {
                    if (mustTerminate)
                    {
                        Thread.CurrentThread.Abort();
                    }
                    sb.Append(c);
                    if (lbl.InvokeRequired)
                    {
                        try
                        {
                            lbl.Invoke((MethodInvoker)delegate { lbl.Text = sb.ToString(); });
                        } catch (Exception e)
                        {
                            //TODO: handle it xd
                        }
                    }
                    else
                    {
                        lbl.Text = sb.ToString();
                    }
                    Thread.Sleep(rnd.Next(50, 80));
                }
            });
        }
    }
}