using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using Data;
using System.Linq;
using System.Collections.Generic;

namespace VirtualLibrarian
{
    public partial class UI : Form
    {
        private bool run = true;
        private bool show = true;
        private bool restart = false;
        private string userName;
        private string userSurname;
        private FirstPage firstPage;
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private Label lbl;
        private string text = "";
        private Thread t;

        private User reader;

        public UI(FirstPage firstPage, string userID)
        {
            this.reader = Library.Instance.readers.Find(x => x.ID == int.Parse(userID));

            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            InitializeComponent();
            this.firstPage = firstPage;
            this.userName = reader.Name;
            this.userSurname = reader.Surname;
            userInformation1.UserName = userName;
            userInformation1.UserSurname = userSurname;

            synthesizer.Volume = 100;
            synthesizer.Rate = -2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On load show homepage user control 
            containerPanel.Controls.Add(Homepage.Instance);
            Search.Instance.Dock = DockStyle.Fill;
            Search.Instance.BringToFront();

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
            ai1.guideLabel.Text = "";
            this.text = msg;
            show = true;
            restart = true;
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SpeakAsync(msg);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            TellUser("Here you can find a book which you want to take.");
            if (!containerPanel.Controls.Contains(Search.Instance))
            {
                containerPanel.Controls.Add(Search.Instance);
                Search.Instance.Dock = DockStyle.Fill;
                Search.Instance.Reader = reader;
                Search.Instance.BringToFront();
            }
            else
                Search.Instance.BringToFront();
        }

        private void PersonalInfoButton_Click(object sender, EventArgs e)
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

        private void ReturnButton_Click(object sender, EventArgs e)
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

        private void HistoryButton_Click(object sender, EventArgs e)
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

            var query = from s in Library.Instance.books
                         where s.Reader == reader.ID
                         select new { s.Author, s.Title };

            History.Instance.dataGridView.DataSource = query.ToList();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
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

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ChangeCursor(Button Btn)
        {
            Btn.TabStop = false;
            Btn.FlatStyle = FlatStyle.Flat;
            Btn.FlatAppearance.BorderSize = 0;
        }

        public void SendString(string text)
        {
            if (text == "success")
            {
                MessageBox.Show("ok");
                this.Show();
            }
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            lbl = ai1.guideLabel;
            t = new Thread(new ThreadStart(WriteSlowly));
            t.Start();
            TellUser("Welcome, " + userName);
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            firstPage.Show();
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            TellUser("See you soon.");
            this.Controls.Clear();
            run = false;
        }

        public void WriteSlowly()
        {
            while (run)
            {
                if (show)
                {
                replay:
                    Random rnd = new Random();
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in text)
                    {
                        if (restart)
                        {
                            restart = false;
                            goto replay;
                        }
                        sb.Append(c);
                        if (lbl.InvokeRequired)
                        {
                            try
                            {
                                lbl.Invoke((MethodInvoker)delegate { lbl.Text = sb.ToString(); });
                            }
                            catch (Exception e)
                            {
                                //throw 
                            }
                        }
                        else
                        {
                            lbl.Text = sb.ToString();
                        }
                        Thread.Sleep(rnd.Next(50, 80));
                    }
                    show = false;
                }

            }
        }

    }
}