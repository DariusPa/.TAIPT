using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Librarian
{
    class FaceCamera
    {
        private static String frameSrc = "images/FaceFrame.png";
        private static Bitmap faceFrame = (Bitmap)Bitmap.FromFile(frameSrc);

        private VideoCapture videoCapture;
        private Thread captureThread;
        private CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml");
        //private bool isSaved;

        private int eigenThresh = 2000;     //The bigger, the less accurate
        private FaceRecognizer faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
        private List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();
        private List<String> faceLabels = new List<String>();
        private List<int> faceID = new List<int>();
        private bool isTrained = false;
        private int faceCount;
        private Size camSize;

        private string labelFile = "Faces/TrainedLabels.txt";
        private PictureBox camPicBox;

        private int picturesPerUser = 10;
        private bool newUser;
        private bool existingUser;

        private Image<Gray, Byte> detectedFace;

        public bool saveButtonClicked = false;
        private bool savingInProgress = false;

        public FaceCamera(int camWidth, int camHeight, PictureBox camPicBox)
        {
            videoCapture = new VideoCapture();
            camSize = new Size(camWidth,camHeight);
            this.camPicBox = camPicBox;
            LoadRecognizer();
        }

        public void RecognizeExistingFace()
        {
            existingUser = true;
            newUser = false;
            TrainRecognizer();
            StartStreaming("");
        }

        public void AddNewFace(String userLabel)
        {
            newUser = true;
            existingUser = false;
            StartStreaming(userLabel);
        }
       
        public void StopStreaming()
        {
            camPicBox.Image = null;
            captureThread?.Abort();
            videoCapture?.Dispose();
           
        }

        private void StartStreaming(String userLabel)
        {
            
            captureThread = new Thread(() => DisplayCam(userLabel));
            captureThread.Start();
        }

        private void DisplayCam(String userLabel)
        {
            while (videoCapture.IsOpened)
            {
                var frame = videoCapture.QueryFrame();
                var gray = new Mat();

                //Prepares a gray frame and increases its brightness & contrast
                CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(gray, gray);

                var square = FaceCamera.FrameSquarePicture(frame.Bitmap, camSize.Width, camSize.Height);
                camPicBox.Image = square;

                frame.Dispose();

                Rectangle[] facesDetected = face.DetectMultiScale(gray, 1.4, 4, new Size(20, 20));
               

                foreach (Rectangle f in facesDetected)
                {
                    detectedFace = (new Mat(gray, f)).ToImage<Gray, byte>();
                    gray.Dispose();
                    CvInvoke.Resize(detectedFace, detectedFace, new Size(100, 100), 0, 0, Inter.Cubic);

                    if (isTrained)
                    {
                        var label = Recognize(detectedFace);
                        if (label != "")
                        {
                            if (existingUser)
                            {
                                MessageBox.Show("HELLO " + label);
                                StopStreaming();
                            }
                            else if (newUser && !savingInProgress)
                            {
                                MessageBox.Show("USER '" + userLabel + "' IS ALREADY KNOWN TO THE SYSTEM AS '" + label + "'");
                                StopStreaming();
                            }
                            detectedFace.Dispose();

                            return;
                        }
                    }

                    if (newUser && saveButtonClicked)
                    {
                        savingInProgress = true;
                        Thread saveFace = new Thread(() => SaveNewFace(userLabel));
                        saveFace.Start();
                    }
                    break;
                }

            }
        }

        private void SaveNewFace(String label)
        {
            saveButtonClicked = false;
            for (int picturesSaved = 0; picturesSaved < picturesPerUser; )
            {
                if (detectedFace != null)
                {
                    detectedFace.Save(String.Format("Faces/{0}.bmp", faceCount));
                    File.AppendAllText(labelFile, label + "%");

                    trainedFaces.Add(detectedFace);
                    faceLabels.Add(label);
                    faceID.Add(++faceCount);
                    picturesSaved++;
                    Thread.Sleep(500);
                }
            }
            
            MessageBox.Show("NEW USER '" + label + "' HAS BEEN ADDED TO THE SYSTEM!");
            StopStreaming();
            TrainRecognizer();

        }

        /*Loads the recognizer with faces and their labels*/
        private void LoadRecognizer()
        {
            string[] labels = File.ReadAllText(labelFile).Split('%');
            faceCount = labels.Length - 1;

            for (int j = 0; j < faceCount; j++)
            {
                trainedFaces.Add(new Image<Gray, byte>("Faces/" + j + ".bmp"));
                faceLabels.Add(labels[j]);
                faceID.Add(j);
            }

            TrainRecognizer();
        }

        /*Trains the recognizer to be able to connect faces with their labels.*/
        /*Must be invoked before calling the 'Recognize' method.*/
        private void TrainRecognizer()
        {
            if (faceCount < 1)
            {
                //MessageBox.Show("There are no known faces in the database.");
                return;
            }

            faceRecognizer.Train(trainedFaces.ToArray(), faceID.ToArray());

            isTrained = true;
        }

        /*Returns the person's name if recognized.*/
        private string Recognize(Image<Gray, Byte> detectedFace)
        {
            var result = faceRecognizer.Predict(detectedFace);
            if (result.Label != -1 && result.Distance < eigenThresh)
            {
                return faceLabels[result.Label];
            }
            else return "";
        }

        /*Resizes the snapshot from camera and puts the frame picture on it*/
        public static Bitmap FrameSquarePicture(Bitmap cameraFrame, int width, int height)
        {
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

    }
}
