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

        public event EventHandler<BarcodeDetectedEventArgs> BarcodeDetected;
        public event EventHandler<FrameGrabbedEventArgs> FrameGrabbed;
        public delegate void EventHandler<T>(object sender, T e);


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

    }
}
