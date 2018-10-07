using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VirtualLibrarian.BarcodeCamera;
using Data;

namespace VirtualLibrarian
{
    public partial class Search : UserControl
    {
        private static Search _instance;
        public BarcodeCamera BarcodeCamera { get; private set; }
        public User Reader { get; set; }
        public string DetectedBook;


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
            BarcodeCamera = new BarcodeCamera(scanBox);
            BarcodeCamera.BarcodeDetected += barcodeCamera_BarcodeDetected;
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            scanBox.Show();
            scanButton.Hide();
            BarcodeCamera.ScanBarcode();


        }

        private void scanBox_VisibleChanged(object sender, EventArgs e)
        {
            if (!scanBox.Visible)
            {
                BarcodeCamera.StopStreaming();
                scanButton.Show();
            }
        }

        private void Search_Leave(object sender, EventArgs e)
        {
            BarcodeCamera.StopStreaming();
            scanBox.Hide();
            scanButton.Show();
        }

        private void barcodeCamera_BarcodeDetected(object sender, BarcodeDetectedEventArgs e)
        {
            Book book = Library.Instance.books.Find(x => x.ID == int.Parse(e.DecodedText));
            if (Reader!= null && book!= null)
            {
                if (Library.Instance.IssueBookToReader(Reader, book))
                    MessageBox.Show("Book has been issued");
                else MessageBox.Show("Issuing failed!");
            }
            
            

        }
    }
}
