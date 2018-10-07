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

namespace VirtualLibrarian
{
    class FaceCamera
    {
        private Thread savingThread;
        private Thread captureThread;

        private Form form;

        private static string resourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources";
        private static string facesPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Data\\Faces";

        private string labelFile = facesPath + "\\TrainedLabels.txt";
        private Bitmap faceFrame = (Bitmap)Bitmap.FromFile(resourcePath + "\\FaceFrame.png");
        private CascadeClassifier face = new CascadeClassifier(resourcePath + "\\haarcascade_frontalface_default.xml");

        private VideoCapture videoCapture;
        private int eigenThresh = 2000;     //The bigger, the less accurate
        private FaceRecognizer faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
        private List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();
        private List<String> faceLabels = new List<String>();
        private List<int> faceID = new List<int>();
        private bool isTrained = false;
        private int faceCount;
        private Size camSize;
        private PictureBox camPicBox;
        private int picturesPerUser = 10;
        private Image<Gray, Byte> detectedFace;

        private bool newUser;
        private bool existingUser;
        private bool saved;
        public bool saveButtonClicked = false;


        public FaceCamera(int camWidth, int camHeight, PictureBox camPicBox, Form form)
        {
            videoCapture = new VideoCapture();
            camSize = new Size(camWidth,camHeight);
            this.camPicBox = camPicBox;
            this.form = form;
            LoadRecognizer();
        }

        public void RecognizeExistingFace()
        {
            existingUser = true;
            newUser = false;
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
            savingThread?.Abort();
            videoCapture?.Dispose();
        }

        private void StartStreaming(String userLabel)
        {
            TrainRecognizer();
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

                var square = FrameSquarePicture(frame.Bitmap, camSize.Width, camSize.Height);
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
                                ((ExistingUserForm)form).userID = label;
                                form.BeginInvoke(new Action(() => form.Close()));
                                return;
                            }
                            else if (newUser)
                            {
                                MessageBox.Show("USER IS ALREADY KNOWN TO THE SYSTEM");
                                form.BeginInvoke(new Action(() => form.Close()));
                                return;
                            }
                            detectedFace.Dispose();

                            return;
                        }
                    }

                    if (newUser)
                    {
                        if (saveButtonClicked)
                        {
                            Thread saveFace = new Thread(() => SaveNewFace(userLabel));
                            savingThread = saveFace;
                            saveFace.Start();
                        }
                        else if (saved)
                        {
                            MessageBox.Show("NEW USER HAS BEEN ADDED TO THE SYSTEM!");
                            form.BeginInvoke(new Action(() => form.Close()));
                            return;
                        }
                    }

                    break;
                }

            }
        }

        private void SaveNewFace(String label)
        {
            List<Image<Gray, byte>> trainedFacesTemp = new List<Image<Gray, byte>>();
            List<String> faceLabelsTemp = new List<String>();
            List<int> faceIDTemp = new List<int>();
            int faceCountTemp = faceCount;

            saveButtonClicked = false;

            for (int picturesSaved = 0; picturesSaved < picturesPerUser;)
            {
                if (detectedFace != null)
                {
                    trainedFacesTemp.Add(detectedFace);
                    faceLabelsTemp.Add(label);
                    faceIDTemp.Add(++faceCountTemp);
                    picturesSaved++;
                    Thread.Sleep(500);
                }
            }
            /*New faces are added in one transaction to avoid the bug of saving empty images when
            process terminates after recognising that the 'new' person already exists in the database*/
            for(int i = 0; i < picturesPerUser; i++)
            {
                trainedFacesTemp[i].Save(String.Format("{0}\\{1}.bmp", facesPath,faceCount));
                File.AppendAllText(labelFile, label + "%");
                trainedFaces.Add(trainedFacesTemp[i]);
                faceLabels.Add(faceLabelsTemp[i]);
                faceID.Add(++faceCount);
            }
            saved = true;
        }

        /*Loads the recognizer with faces and their labels*/
        private void LoadRecognizer()
        {
            if (!File.Exists(labelFile))
                File.Create(labelFile).Dispose();
            string[] labels = File.ReadAllText(labelFile).Split('%');
            faceCount = labels.Length - 1;

            try
            {
                for (int j = 0; j < faceCount; j++)
                {
                    trainedFaces.Add(new Image<Gray, byte>(facesPath + "\\" + j + ".bmp"));
                    faceLabels.Add(labels[j]);
                    faceID.Add(j);
                }
            } catch (Exception e)
            {
                trainedFaces.Clear();
                faceLabels.Clear();
                faceID.Clear();
                faceCount = 0;
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

    }
}
