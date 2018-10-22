﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using VirtualLibrarian.Model;
using VirtualLibrarian.Data;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Temp;

namespace VirtualLibrarian
{
    public partial class UI : Form
    {
        public IUserModel User { get; set; }
		private SpeakingAI Speaker = new SpeakingAI();

        public UI(IUserModel User) 
        {
            this.User = User;

            //WindowState = FormWindowState.Maximized;                  
            //StartPosition = FormStartPosition.Manual;     
            //Location = new Point(0, 0);
            InitializeComponent();
            userInformation1.UserName = User.Name;
            userInformation1.UserSurname = User.Surname;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.WindowState;
            this.Location = Properties.Settings.Default.WindowLocation;
            this.Size = Properties.Settings.Default.UIWindowSize;

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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can find a book which you want to take.", ai1);
            if (!containerPanel.Controls.Contains(Search.Instance))
            {
                containerPanel.Controls.Add(Search.Instance);
                Search.Instance.Dock = DockStyle.Fill;
                Search.Instance.BringToFront();
            }
            else
                Search.Instance.BringToFront();
        }

        private void PersonalInfoButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can see your personal information.", ai1);
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
            Speaker.TellUser("Here you can return a book.", ai1);
            if (!containerPanel.Controls.Contains(ReturnBook.Instance))
            {
                containerPanel.Controls.Add(ReturnBook.Instance);
                ReturnBook.Instance.Dock = DockStyle.Fill;
                ReturnBook.Instance.BringToFront();
            }
            else
                ReturnBook.Instance.BringToFront();

            RefreshDataGrid();
        }

        //TODO: write interfaces to use this method for different controls
        public void RefreshDataGrid()
        {
            // Query syntax
            //var query = from s in LibraryDataIO.Instance.Books
            //            where s.ReaderID == User.ID
            //            select new { s.ID, s.Title };

            // Method syntax
            var query = LibraryDataIO.Instance.Books.Where(s => s.ReaderID == User.ID).Select( s => new { s.ID, s.Title } );

            ReturnBook.Instance.dataGridView.DataSource = query.ToList();
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can see your readings history.", ai1);
            if (!containerPanel.Controls.Contains(History.Instance))
            {
                containerPanel.Controls.Add(History.Instance);
                History.Instance.Dock = DockStyle.Fill;
                History.Instance.BringToFront();
            }
            else
                History.Instance.BringToFront();


            var booksByAuthor = Temp.Author.GetAllAuthors()
                                     .GroupJoin(Temp.Book.GetAllBooks(),
                                               a => a.ID,
                                               b => b.AuthorID,
                                               (a, b) => new
                                               {
                                                   Author = a.Name,
                                                   Books = b.Last().Title
                                               });
            //var booksByAuthor = from a in Temp.Author.GetAllAuthors()
            //                    join b in Temp.Book.GetAllBooks()
            //                    on a.ID equals b.AuthorID
            //                    select new { Author = a.Name, Book = b.Title };

            History.Instance.dataGridView.DataSource = booksByAuthor.ToList();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can change your account settings.", ai1);
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
            Speaker.TellUser("Welcome, " + User.Name, ai1);
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
			Speaker.run = false;
	
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Speaker.TellUser("See you soon.", ai1);
            this.Controls.Clear();
        }

    }
}