using NUnit.Framework;
using VirtualLibrarian;
using VirtualLibrarian.Model;
namespace Library.Tests
{
    [TestFixture]
    class Unit_Tests
    {
        public void validatesEmail(string email)
        {
            var sut = new RegexUtilities();
            Assert.AreEqual(false, sut.IsValidEmail(email));
        }
        public void sorts()
        {
            var sut = new Sorter();
            Book[] books = new Book[20];
            sut.SortBooks(books, "Title");
            Book knyga = new Book("A", "Autorius", "haha");
            books[0] = knyga;
        }
    }
}