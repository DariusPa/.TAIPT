using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using static VirtualLibrarian.BusinessLogic.FaceCamera;

namespace VirtualLibrarian.BusinessLogic
{
    public class FaceRecognition
    {
        private CascadeClassifier cascadeClassifier;
        private int eigenThresh;
        public int FaceCount { get; private set; }
        private FaceRecognizer faceRecognizer;
        private List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();
        private List<String> faceLabels = new List<String>();
        private List<int> faceID = new List<int>();


        private bool photoSaved;

        public event EventHandler FacePhotoSaved;
        public event FaceRecognisedEventHandler NewUserRegistered;

        public FaceRecognition(int eigenThresh=2000)
        {
            faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            cascadeClassifier = new CascadeClassifier(LibraryDataIO.Instance.ResourcePath + "\\haarcascade_frontalface_default.xml");
            this.eigenThresh = eigenThresh;
        }

        /*Loads the recognizer with faces and their labels*/
        public void LoadRecognizer()
        {
            string[] labels = File.ReadAllText(LibraryDataIO.Instance.FaceLabelsPath).Split('%');
            FaceCount = labels.Length - 1;

            try
            {
                for (int j = 0; j < FaceCount; j++)
                {
                    trainedFaces.Add(new Image<Gray, byte>(LibraryDataIO.Instance.FacesPath + "\\" + j + ".bmp"));
                    faceLabels.Add(labels[j]);
                    faceID.Add(j);
                }
            }
            catch (Exception e)
            {
                trainedFaces.Clear();
                faceLabels.Clear();
                faceID.Clear();
                FaceCount = 0;
            }
        }

        /*Trains the recognizer to be able to connect faces with their labels.*/
        /*Must be invoked before calling the 'Recognize' method.*/
        public bool TrainRecognizer()
        {
            if (FaceCount != 0)
            {
                faceRecognizer.Train(trainedFaces.ToArray(), faceID.ToArray());
                return true;
            }
            else return false;

        }

        /*Returns the person's name if recognized.*/
        public string Recognize(Image<Gray, Byte> detectedFace)
        {

            var result = faceRecognizer.Predict(detectedFace);
            if (result.Label != -1 && result.Distance < eigenThresh)
            {
                return faceLabels[result.Label];
            }
            else return "";
        }

        public Rectangle [] DetectFaces(Mat gray)
        {
            return cascadeClassifier.DetectMultiScale(gray, 1.4, 4, new Size(20, 20));
        }
        public void SaveNewFace(string label, Image<Gray, Byte> detectedFace)
        {
            List<Image<Gray, byte>> trainedFacesTemp = new List<Image<Gray, byte>>();
            List<String> faceLabelsTemp = new List<String>();
            List<int> faceIDTemp = new List<int>();

            for (int picturesSaved = 0; picturesSaved < LibraryDataIO.Instance.PicturesPerUser;)
            {
                if (detectedFace != null)
                {
                    trainedFacesTemp.Add(detectedFace);
                    faceLabelsTemp.Add(label);
                    faceIDTemp.Add(++this.FaceCount);
                    picturesSaved++;
                    FacePhotoSaved?.Invoke(this, EventArgs.Empty);
                    Thread.Sleep(500);
                }
            }

            StoreNewFace(trainedFacesTemp, faceLabelsTemp, faceIDTemp, label);
            photoSaved = true;

            NewUserRegistered?.Invoke(this, new FaceRecognisedEventArgs { Label = label });
            return;
        }

        public void StoreNewFace(List<Image<Gray, byte>> trainedFacesTemp, List<String> faceLabelsTemp, List<int> faceIDTemp, string label)
        {
            for (int i = 0; i < LibraryDataIO.Instance.PicturesPerUser; i++)
            {
                LibraryDataIO.Instance.AddNewFace(trainedFacesTemp[i], label, FaceCount);
                trainedFaces.Add(trainedFacesTemp[i]);
                faceLabels.Add(faceLabelsTemp[i]);
                faceID.Add(++FaceCount);
            }
        }

    }
}
