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
            Book knygaA = new Book("A", "Autorius", "haha");
            Book knygaB = new Book("B", "Autorius", "haha");
            Book knygaC = new Book("C", "Autorius", "haha");
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
        }
    }
}