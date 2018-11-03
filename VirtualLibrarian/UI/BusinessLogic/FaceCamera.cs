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

        private Bitmap faceFrame = (Bitmap)Bitmap.FromFile(LibraryDataIO.Instance.ResourcePath + "\\FaceFrame.png");
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

        public FaceCamera(int camWidth, int camHeight)
        {
            faceRecognition = new FaceRecognition();
            videoCapture = new VideoCapture();
            camSize = new Size(camWidth,camHeight);
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

        public void StartStreaming()
        {
            isTrained = faceRecognition.TrainRecognizer();
            captureThread = new Thread(DisplayCam);
            captureThread.Start();
        }


        private void DisplayCam()
        {
            while (videoCapture.IsOpened)
            {
                var frame = videoCapture.QueryFrame();
                var gray = new Mat();

                //Prepares a gray frame and increases its brightness & contrast
                CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(gray, gray);

                var square = FrameSquarePicture(frame.Bitmap, camSize.Width, camSize.Height);
                FrameGrabbed?.Invoke(this, new FrameGrabbedEventArgs { Frame = square });

                frame.Dispose();

                Rectangle[] facesDetected = faceRecognition.DetectFaces(gray);
               
                foreach (Rectangle f in facesDetected)
                {
                    detectedFace = (new Mat(gray, f)).ToImage<Gray, byte>();
                    gray.Dispose();
                    CvInvoke.Resize(detectedFace, detectedFace, new Size(100, 100), 0, 0, Inter.Cubic);

                    if (isTrained)
                    {
                        var label = faceRecognition.Recognize(detectedFace);
                        if (label != "")
                        {
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

        public void SaveFace()
        {
            Thread saveFace = new Thread(() => SaveNewFace(userLabel));
            saveFace.Start();
        }

        //TODO: move to FaceRecognition class
        private void SaveNewFace(string label)
        {
            List<Image<Gray, byte>> trainedFacesTemp = new List<Image<Gray, byte>>();
            List<String> faceLabelsTemp = new List<String>();
            List<int> faceIDTemp = new List<int>();
            int faceCountTemp = faceRecognition.FaceCount;

            for (int picturesSaved = 0; picturesSaved < LibraryDataIO.Instance.PicturesPerUser;)
            {
                if (detectedFace != null)
                {
                    trainedFacesTemp.Add(detectedFace);
                    faceLabelsTemp.Add(label);
                    faceIDTemp.Add(++faceCountTemp);
                    picturesSaved++;
                    FacePhotoSaved?.Invoke(this, EventArgs.Empty);
                    Thread.Sleep(500);
                }
            }

            faceRecognition.StoreNewFace(trainedFacesTemp, faceLabelsTemp, faceIDTemp,label);
            saved = true;
            return;
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
