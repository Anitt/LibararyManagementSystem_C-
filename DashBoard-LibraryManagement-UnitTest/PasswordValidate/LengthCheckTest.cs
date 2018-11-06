using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.PasswordValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest.PasswordValidate
{
//Test case for the function to check if the password satisfy the minimum length 
    [TestClass]
    public class LengthCheckTest
    {
       [TestMethod]
        public void Password_Valid()
        {
            PropertyCheck password = new PropertyCheck("Al1@sdfghj");
            LengthCheck length = new LengthCheck();
            bool result = length.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_InvalidLength()
        {
            PropertyCheck password = new PropertyCheck("Afghj");
            LengthCheck length = new LengthCheck();
            bool result = length.checkPassword(password);
            Assert.AreEqual(false, result);
        }
    }
}
