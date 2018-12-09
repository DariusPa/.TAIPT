using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.BusinessLogic;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public sealed class SharedResources
    {
        private static readonly Lazy<SharedResources> shared = new Lazy<SharedResources>(() => new SharedResources());
        public static SharedResources Instance { get { return shared.Value; } }

        public FaceRecognition FaceRecognition { get; set; }
        public bool IsRecogniserTrained { get; set; }
        public Speaker Speaker { get; set; }
        public int ID { get; set; }


        private SharedResources()
        {
            FaceRecognition = new FaceRecognition(2500);
            FaceRecognition.LoadRecognizer();
            IsRecogniserTrained = FaceRecognition.TrainRecognizer();
            Speaker = new Speaker();
        }

    }
}
