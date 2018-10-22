using NUnit.Framework;
using VirtualLibrarian;
namespace Library.Tests
{
    [TestFixture]
    class Unit_Tests
    {
        [TestCase("labasgmail.com")]
        [TestCase("laba..s@gmail.com")]
        [TestCase("labas@gmail.")]
        [TestCase("labas@.com")]
        public void validatesEmail(string email)
        {
            var sut = new RegexUtilities();
            Assert.AreEqual(false, sut.IsValidEmail(email));
        }
    }
}