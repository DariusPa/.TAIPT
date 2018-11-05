using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.Helpers
{
    public static class StringConstants
    {
        public static string fullNameString = "FullName";
        public static string missingInfo = "Information missing!";

        public static string nameRequirement = "Name (required)";
        public static string surnameRequirement = "Surname (required)";
        public static string emailRequirement = "E-mail (required)";

        public static string nameString = "Name";
        public static string surnameString = "Surname";
        public static string emailAdressString = "E-mail adress";

        public static string nameInputString = "nameInput";
        public static string surnameInputString = "surnameInput";
        public static string emailInputString = "emailInput";

        public static string successfulRegistration = "Registration succeeded!";

        public static string aiSearchLibraryGreeting = "Here you can search for books in the library and see if they are available for lending.";
        public static string aiScanBookQRString = "Scan the QR code of the book you want to take.";
        public static string aiReturnBookString = "Here you can return a book. Scan the QR code of the book you have previously taken.";
        public static string aiReadingHistoryGreeting = "Here you can see your readings history.";
        public static string aiAccountSettingsGreeting = "Here you can change your account settings.";
        public static string aiGoodbye = "See you soon.";
        public static string aiIssued = "Book has been successfully issued to you.";
        public static string aiIssuingFailed = "Issuing failed!";
        public static string aiReturnedBook = "You successfully returned the book.";
        public static string aiReturnFailed = "Returning failed! You might have returned this book earlier or it had been taken by another user.";

        public static string currentlyTakenString = "Currently taken";
        public static string aiSaveChangesFailed = "Updating your account settings failed.";
        public static string aiChangesSaved = "Your account settings have been successfully updated.";

        public static string AIGreeting(string name)
        {
            return "Welcome " + name + "!";
        }

        public static string ExistingUserErrorString (string name, string surname)
        {
            return "User is already registered as " + name + " " + surname + "!";
        }
    }
}
