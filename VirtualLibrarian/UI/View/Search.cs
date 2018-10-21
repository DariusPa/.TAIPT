using System;
using System.Windows.Forms;
using VirtualLibrarian.Helpers;
using VirtualLibrarian.BusinessLogic;

namespace VirtualLibrarian
{
    public partial class Search : UserControl
    {
        private static Search _instance;
        public BarcodeCamera barcodeCamera;
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
            barcodeCamera = new BarcodeCamera();
            barcodeCamera.FrameGrabbed += StreamCamera;
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            scanBox.Show();
            scanButton.Hide();
            barcodeCamera.ScanBarcode();
        }

        private void StreamCamera(object sender, FrameGrabbedEventArgs e)
        {
            scanBox.Image = e.Frame;
        }

        private void Search_Leave(object sender, EventArgs e)
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
