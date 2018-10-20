using Emgu.CV;
using System.Threading;
using VirtualLibrarian.Helpers;
using ZXing;

namespace VirtualLibrarian.BusinessLogic
{
    public class BarcodeCamera
    {
        private Thread captureThread;
        private VideoCapture videoCapture;

        public event EventHandler BarcodeDetected;
        public event FrameGrabbedEventHandler FrameGrabbed;

        public void ScanBarcode()
        {
            videoCapture = new VideoCapture();
            captureThread = new Thread(DisplayCam);
            captureThread.Start();
        }

        public void StopStreaming()
        {
            captureThread?.Abort();
            videoCapture?.Dispose();
        }

        private void DisplayCam()
        {
            while (videoCapture.IsOpened)
            {
                var frame = videoCapture.QueryFrame();
                FrameGrabbed?.Invoke(this, new FrameGrabbedEventArgs { Frame = frame.Bitmap });
                var barcodeReader = new BarcodeReader();
                
                var barcodeDetected = barcodeReader.Decode(frame.Bitmap);
                if (barcodeDetected != null)
                {
                    BarcodeDetected?.Invoke(this, new BarcodeDetectedEventArgs { DecodedText = barcodeDetected.Text });
                    return;
                }
            }
        }

        public delegate void EventHandler(object sender, BarcodeDetectedEventArgs e);
        public delegate void FrameGrabbedEventHandler(object sender, FrameGrabbedEventArgs e);
        

    }
}
