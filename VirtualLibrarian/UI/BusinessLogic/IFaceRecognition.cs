using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualLibrarian.BusinessLogic
{
    public interface IFaceRecognition
    {
        bool SaveNewFace(string label, ref Image<Gray, Byte> detectedFace, CancellationToken token);
        bool TrainRecognizer();
        void LoadRecognizer();
        Rectangle[] DetectFaces(Mat gray);
        event EventHandler FacePhotoSaved;

        string Recognize(Image<Gray, Byte> detectedFace);
    }
}
