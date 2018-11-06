using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.PasswordValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest.PasswordValidate
{
    //Test case for the function to check if the password contains lowercase
    [TestClass]
    public class LowercaseCheckTest
    {
        [TestMethod]
        public void Password_Valid()
        {
            PropertyCheck password = new PropertyCheck("Al1@sdfghj");
            LowercaseCheck lowercase = new LowercaseCheck();
            bool result = lowercase.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasLowercase()
        {
            PropertyCheck password = new PropertyCheck("Asdfghj");
            LowercaseCheck lowercase = new LowercaseCheck();
            bool result = lowercase.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasNoLowercase()
        {
            PropertyCheck password = new PropertyCheck("AS1@DFGFHJ");
            LowercaseCheck lowercase = new LowercaseCheck();
            bool result = lowercase.checkPassword(password);
            Assert.AreEqual(false, result);
        }
    }
}
