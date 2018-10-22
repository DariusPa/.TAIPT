using NUnit.Framework;
using VirtualLibrarian;
using VirtualLibrarian.Model;
using System;
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
        [Test]
        public void sorts()
        {
            var sut = new Sorter();
            Book[] books = new Book[4];
            Book knygaA = new Book("A", "Butorius", "haha");
            Book knygaB = new Book("B", "Cutorius", "haha");
            Book knygaC = new Book("C", "Dutorius", "haha");
            Book knygaD = new Book("D", "Autorius", "haha");
            books[0] = knygaA;
            books[1] = knygaD;
            books[2] = knygaB;
            books[3] = knygaC;
            sut.SortBooks(books, "title");
            Assert.AreEqual("A", books[0].Title);
            Assert.AreEqual("B", books[1].Title);
            Assert.AreEqual("C", books[2].Title);
            Assert.AreEqual("D", books[3].Title);
            sut.SortBooks(books, "Author");
            Assert.AreEqual("Autorius", books[0].Author);
            Assert.AreEqual("Butorius", books[1].Author);
            Assert.AreEqual("Cutorius", books[2].Author);
            Assert.AreEqual("Dutorius", books[3].Author);
        }
    }
}