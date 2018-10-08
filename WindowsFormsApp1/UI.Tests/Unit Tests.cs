using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WindowsFormsApp1;

namespace UI.Tests
{
    [TestFixture]
    public class Class1
    {
        [TestCase("labasgmail.com")]
        [TestCase("labas@gmailcom")]
        [TestCase("labas@gmail")]
        [TestCase("labas@.com")]
        [TestCase("labas@gmail.")]
        public void ValidatesEmail(string email)
        {
            var sut = new RegexUtilities();
            Assert.AreEqual(false, sut.IsValidEmail(email));
        }
    }
}
