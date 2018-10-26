using System;
using System.Drawing;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Helpers
{
    public class BookRelatedEventArgs : EventArgs
    {
        public IBookModel Book { get; set; }
        public Author Author { get; set; }
    }

    public class UserRelatedEventArgs : EventArgs
    {
        public string UserID { get; set; }
        public IUserModel PendingUser { get; set; }
    }

    public class FrameGrabbedEventArgs : EventArgs
    {
        public Bitmap Frame { get; set; }
    }

    public class FaceRecognisedEventArgs : EventArgs
    {
        public string Label { get; set; }
    }

    public class BarcodeDetectedEventArgs : EventArgs
    {
        public string DecodedText { get; set; }
    }

}
