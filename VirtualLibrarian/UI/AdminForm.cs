using Data;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZXing;

namespace VirtualLibrarian
{
    public partial class AdminForm : Form
    {
        private Library library = Library.Instance;

        private BarcodeWriter barcodeWriter = new BarcodeWriter();
        private static string barcodesPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\Barcodes";

        public AdminForm()
        {
            InitializeComponent();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var library = Library.Instance;
            if(!string.IsNullOrWhiteSpace(titleBox.Text) && !string.IsNullOrWhiteSpace(isbnBox.Text) 
                && !string.IsNullOrWhiteSpace(publisherBox.Text) && !string.IsNullOrWhiteSpace(authorBox.Text) 
                && !string.IsNullOrWhiteSpace(genreBox.Text))
            {
                if (!library.authors.Contains(authorBox.Text))
                {
                    library.AddAuthor(authorBox.Text);
                }
                var book = new Book(titleBox.Text, authorBox.Text, publisherBox.Text, (Genre)Enum.Parse(typeof(Genre), genreBox.Text), isbnBox.Text/*,richTextBox1?.Text*/);
                var filePath = string.Format("{0}\\{1}.bmp", barcodesPath, book.ID);
                library.AddBook(book);
                barcodeWriter.Write((book.ID).ToString()).Save(filePath);
                barcodeBox.Image = Image.FromFile(filePath);
                barcodeBox.Show();

            }
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            genreBox.DataSource = Enum.GetValues(typeof (Genre));
            
        }

        private void authorBox_Enter(object sender, EventArgs e)
        {
            authorBox.DataSource = library.authors.ToArray();
        }
    }
}
