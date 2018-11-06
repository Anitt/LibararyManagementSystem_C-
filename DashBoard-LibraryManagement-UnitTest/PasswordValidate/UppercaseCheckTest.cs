using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.PasswordValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest.PasswordValidate
{
    //Test case for the function to check if the password contains uppercase
    [TestClass]
    public class UppercaseCheckTest
    {
        [TestMethod]
        public void Password_Valid()
        {
            PropertyCheck password = new PropertyCheck("Al1@sdfghj");
            UppercaseCheck uppercase = new UppercaseCheck();
            bool result = uppercase.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasUppercase()
        {
            PropertyCheck password = new PropertyCheck("Alghj");
            UppercaseCheck uppercase = new UppercaseCheck();
            bool result = uppercase.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasNoUppercase()
        {
            PropertyCheck password = new PropertyCheck("l12#ghj");
            UppercaseCheck uppercase = new UppercaseCheck();
            bool result = uppercase.checkPassword(password);
            Assert.AreEqual(false, result);
        }
    }
}
