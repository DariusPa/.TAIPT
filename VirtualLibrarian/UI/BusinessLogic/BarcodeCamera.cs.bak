using Emgu.CV;
using System;
using System.Threading;
using System.Windows.Forms;
using ZXing;

namespace VirtualLibrarian
{
    public class BarcodeCamera
    {
        private Thread captureThread;

        private VideoCapture videoCapture;
        private PictureBox camPicBox;

        public event EventHandler BarcodeDetected;


        public BarcodeCamera(PictureBox camPicBox)
        {
            this.camPicBox = camPicBox;
        }

        public void ScanBarcode()
        {
            videoCapture = new VideoCapture();
            captureThread = new Thread(DisplayCam);
            captureThread.Start();
        }

        public void StopStreaming()
        {
            camPicBox.Image = null;
            captureThread?.Abort();
            videoCapture?.Dispose();
        }

        private void DisplayCam()
        {
            while (videoCapture.IsOpened)
            {
                var frame = videoCapture.QueryFrame();
                camPicBox.Image = frame.Bitmap;
                var barcodeReader = new BarcodeReader();
                
                var barcodeDetected = barcodeReader.Decode(frame.Bitmap);
                if (barcodeDetected != null)
                {
                    OnBarcodeDetected(new BarcodeDetectedEventArgs{ DecodedText = barcodeDetected.Text });
                    camPicBox.BeginInvoke(new Action(() => camPicBox.Hide()));
                    return;
                }
                
            }
        }

        protected virtual void OnBarcodeDetected(BarcodeDetectedEventArgs e)
        {
            BarcodeDetected?.Invoke(this, e);
        }

        public class BarcodeDetectedEventArgs: EventArgs
        {
            public string DecodedText { get; set; }
        }

        public delegate void EventHandler(object sender, BarcodeDetectedEventArgs e);

    }
}
