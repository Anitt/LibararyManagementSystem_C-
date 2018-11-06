using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.PasswordValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest.PasswordValidate
{
//Test case for the function to check if the password contains digit
    [TestClass]
    public class DigitCheckTest
    {
        [TestMethod]
        public void Password_Valid()
        {
            PropertyCheck password = new PropertyCheck("Al1@sdfghj");
            DigitCheck digit = new DigitCheck();
            bool result = digit.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasDigit()
        {
            PropertyCheck password = new PropertyCheck("Al1");
            DigitCheck digit = new DigitCheck();
            bool result = digit.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_NoDigit()
        {
            PropertyCheck password = new PropertyCheck("Alsdf@fh");
            DigitCheck digit = new DigitCheck();
            bool result = digit.checkPassword(password);
            Assert.AreEqual(false, result);
        }

    }
}
