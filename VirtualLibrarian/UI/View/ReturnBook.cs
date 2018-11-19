using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Model;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.BusinessLogic;

namespace VirtualLibrarian
{
    public partial class ReturnBook : UserControl
    {
        private static ReturnBook _instance;
        public BarcodeCamera barcodeCamera;
        public string DetectedBook;

        public static ReturnBook Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReturnBook();
                return _instance;
            }
        }

        public ReturnBook()
        {
            InitializeComponent();
            barcodeCamera = new BarcodeCamera();
            barcodeCamera.FrameGrabbed += StreamCamera;
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            scanBox.Show();
            scanButton.Hide();
            barcodeCamera.ScanBarcode();
        }

        private void StreamCamera(object sender, FrameGrabbedEventArgs e)
        {
            scanBox.Image = e.Frame;
        }

        private void ReturnBook_Leave(object sender, EventArgs e)
        {
            barcodeCamera.StopStreaming();
            scanBox.Hide();
            scanButton.Show();
        }

        public void HideScanner()
        {
            BeginInvoke(new Action(() => { scanBox.Hide(); scanButton.Show(); }));
        }

    }
}
