using System;
using System.Windows.Forms;
using static VirtualLibrarian.BarcodeCamera;
using VirtualLibrarian.Model;

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

        //private void scanBox_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (!scanBox.Visible)
        //    {
        //        BeginInvoke(new Action(()=>barcodeCamera.StopStreaming()));
        //        scanButton.Show();
        //    }
        //}

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
