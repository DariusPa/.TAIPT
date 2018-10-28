using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using VirtualLibrarian.Model;
using VirtualLibrarian.Data;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Helpers;
using System.Collections.Generic;

namespace VirtualLibrarian
{
    public partial class UI : Form
    {
        public IUserModel User { get; set; }
		public SpeakingAI Speaker { get; set; } = new SpeakingAI();
        public AI AI { get { return aiOutput; } }


        public UI(IUserModel User) 
        {
            this.User = User;
            InitializeComponent();
            userInformation1.UserName = User.Name;
            userInformation1.UserSurname = User.Surname;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            //loading UI form window parameters
            AutomaticFormPosition.loadUIFormDelegate(this);

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
            Speaker.TellUser("Here you can search for books in the library and see if they are available for lending.", aiOutput);
            if (!containerPanel.Controls.Contains(Search.Instance))
            {
                containerPanel.Controls.Add(Search.Instance);
                Search.Instance.Dock = DockStyle.Fill;
                Search.Instance.BringToFront();
            }
            else
                Search.Instance.BringToFront();
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Scan the QR code of the book you want to take.", aiOutput);
            if (!containerPanel.Controls.Contains(TakeBook.Instance))
            {
                containerPanel.Controls.Add(TakeBook.Instance);
                TakeBook.Instance.Dock = DockStyle.Fill;
                TakeBook.Instance.BringToFront();
            }
            else
                TakeBook.Instance.BringToFront();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can return a book. Scan the QR code of the book you have previously taken.", aiOutput);
            if (!containerPanel.Controls.Contains(ReturnBook.Instance))
            {
                containerPanel.Controls.Add(ReturnBook.Instance);
                ReturnBook.Instance.Dock = DockStyle.Fill;
                ReturnBook.Instance.BringToFront();
            }
            else
                ReturnBook.Instance.BringToFront();

        }

        //TODO: linq union with book history and reserved books
        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can see your readings history.", aiOutput);
            if (!containerPanel.Controls.Contains(History.Instance))
            {
                containerPanel.Controls.Add(History.Instance);
                History.Instance.Dock = DockStyle.Fill;
                History.Instance.BringToFront();
            }
            else
                History.Instance.BringToFront();

            var takenBooks = User.TakenBooks
                .Join(LibraryDataIO.Instance.Books, 
                      takenBook => takenBook, 
                      libraryBook => libraryBook.ID,
                      (takenBook, libraryBook) => new {
                       libraryBook.Title,
                       Author = string.Join(",",libraryBook.Authors
                       .Join(LibraryDataIO.Instance.Authors,
                       author => author,
                       lbAuthor => lbAuthor.ID,
                       (author, lbAuthor) => lbAuthor.FullName)),
                       Status = "Currently taken"});

            var bookHistory = User.History
                .Join(LibraryDataIO.Instance.Books,
                      readBook => readBook.BookID,
                      libraryBook => libraryBook.ID,
                      (readBook, libraryBook) => new {
                          libraryBook.Title,
                          Author = string.Join(",", libraryBook.Authors
                       .Join(LibraryDataIO.Instance.Authors,
                       author => author,
                       lbAuthor => lbAuthor.ID,
                       (author, lbAuthor) => lbAuthor.FullName)),
                          Status = $"Lending period: {readBook.IssueDate:yyyy/MM/dd} - {readBook.ReturnDate:yyyy/MM/dd}"
                      });

            var history = takenBooks.Concat(bookHistory);

            History.Instance.dataGridView.DataSource = history.ToList();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Speaker.TellUser("Here you can change your account settings.", aiOutput);
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
            AutomaticFormPosition.SaveFormStatus(this);
            this.Close();
        }


        private void ChangeCursor(Button Btn)
        {
            Btn.TabStop = false;
            Btn.FlatStyle = FlatStyle.Flat;
            Btn.FlatAppearance.BorderSize = 0;
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            Speaker.TellUser($"Welcome, {User.Name}!", aiOutput);
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
			Speaker.run = false;
	
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutomaticFormPosition.SaveFormStatus(this);
            Speaker.TellUser("See you soon.", aiOutput);
            this.Controls.Clear();
        }

    }
}