using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;

namespace VirtualLibrarian.BusinessLogic
{
    public class FaceCamera
    {
        private Thread captureThread;

        private Bitmap faceFrame;
        private VideoCapture videoCapture;

        private bool isTrained = false;
        private Size camSize;
        private Image<Gray, Byte> detectedFace;

        private bool saved;

        public event FrameGrabbedEventHandler FrameGrabbed;
        public event FaceRecognisedEventHandler ExistingUserRecognised;
        public event FaceRecognisedEventHandler NewUserRegistered;
        public event EventHandler FacePhotoSaved;

        public string userLabel;

        private FaceRecognition faceRecognition;

        private Thread saveFace;

        public FaceCamera(int camWidth, int camHeight)
        {
            faceFrame = (Bitmap)Bitmap.FromFile(LibraryDataIO.Instance.ResourcePath + "\\FaceFrame.png");
            faceRecognition = new FaceRecognition();
            videoCapture = new VideoCapture();
            camSize = new Size(camWidth,camHeight);
            faceRecognition.FacePhotoSaved += (object sender,EventArgs e) => FacePhotoSaved?.Invoke(sender, e);
            faceRecognition.LoadRecognizer();
        }

        public void RecognizeExistingFace()
        {
            StartStreaming();
        }

        public void AddNewFace(String userLabel)
        {
            this.userLabel = userLabel;
            StartStreaming();
        }
       
        public void StopStreaming()
        {
            captureThread?.Abort();
            videoCapture?.Dispose();
        }

        public async void SaveFace()
        {
            saved = await Task.Run(() => faceRecognition.SaveNewFace(userLabel, ref detectedFace));
        }

        private void StartStreaming()
        {
            isTrained = faceRecognition.TrainRecognizer();
            captureThread = new Thread(DisplayCam);
            captureThread.Start();
        }

        private void DisplayCam()
        {
            while (videoCapture.IsOpened)
            {
                Mat frame;
                try
                {   
                    frame = videoCapture.QueryFrame();
                }
                catch 
                {
                    LibraryDataIO.Instance.UILogger.LogError("Camera stopped.");
                    return;
                }
                
                var gray = new Mat();

                //Prepares a gray frame and increases its brightness & contrast
                CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(gray, gray);

                var square = FrameSquarePicture(frame.Bitmap, camSize.Width, camSize.Height);
                FrameGrabbed?.Invoke(this, new FrameGrabbedEventArgs { Frame = square });

                frame.Dispose();

                Rectangle[] facesDetected = faceRecognition.DetectFaces(gray);

                //Forget the previously detected face so if no faces were detected in current iteration,
                //the same value wouldn't get stored
                detectedFace = null;
               
                foreach (Rectangle face in facesDetected)
                {
                    var grayFace = new Mat(gray, face);
                    detectedFace = grayFace.ToImage<Gray, byte>();
                    gray.Dispose();
                    CvInvoke.Resize(detectedFace, detectedFace, new Size(100, 100), 0, 0, Inter.Cubic);

                    if (isTrained)
                    {
                        var label = faceRecognition.Recognize(detectedFace);
                        if (label != "")
                        {
                            saveFace?.Abort();
                            ExistingUserRecognised?.Invoke(this, new FaceRecognisedEventArgs { Label = label });
                            return;
                        }
                    }

                    if (saved)
                    {
                        NewUserRegistered?.Invoke(this, new FaceRecognisedEventArgs { Label = userLabel });
                        return;
                    }
                    
                    break;
                }

            }
        }





        /*Resizes the snapshot from camera and puts the frame picture on it*/
        private Bitmap FrameSquarePicture(Bitmap cameraFrame, int width, int height)
        {
            cameraFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            var framedPhoto = new Bitmap(width, height);
            var camWidth = (double)cameraFrame.Width;
            var camHeight = (double)cameraFrame.Height;

            var ratioX = width / camWidth;
            var ratioY = height / camHeight;

            double ratio = ratioX > ratioY ? ratioX : ratioY;

            camHeight = camHeight * ratio;
            camWidth = camWidth * ratio;

            Graphics g = Graphics.FromImage(framedPhoto);
            g.DrawImage(cameraFrame, 0,0,(int)camWidth,(int)camHeight);
            g.DrawImage(faceFrame, 0, 0, width, height);

            g.Dispose();

            return framedPhoto;
        }

        public delegate void FaceRecognisedEventHandler(object sender, FaceRecognisedEventArgs e);
        public delegate void FrameGrabbedEventHandler(object sender, FrameGrabbedEventArgs e);
    }
}
