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
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }

        public UserRelatedEventArgs() { }
        public UserRelatedEventArgs(string name, string surname, string email) : this()
        {
            UserName = name;
            UserSurname = surname;
            UserEmail = email;
        }
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

    public class SoundSettingsEventArgs : EventArgs
    {
        public bool SoundEnabled { get; set; }
    }

}
