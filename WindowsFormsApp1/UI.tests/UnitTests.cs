using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WindowsFormsApp1;

namespace UI.tests
{
    [TestFixture]
    class UnitTests
    {
        [TestCase("sdg@one.lt")]
        [TestCase("gh")]
        [TestCase("a")]
        public void validatesEmail(string email)
        {
            var sut = new FirstPage();
            Assert.AreEqual(true, sut.IsValidEmail(email));
        }
    }
}
