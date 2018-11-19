using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Helpers;

namespace VirtualLibrarian
{
    public partial class TakeBook : UserControl
    {
        private static TakeBook _instance;

        public BarcodeCamera barcodeCamera;
        public string DetectedBook;

        public static TakeBook Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TakeBook();
                return _instance;
            }
        }

        public TakeBook()
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

        private void TakeBook_Leave(object sender, EventArgs e)
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
