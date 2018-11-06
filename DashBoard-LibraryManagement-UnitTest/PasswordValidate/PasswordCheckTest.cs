using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.PasswordValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest.PasswordValidate
{
//Test case to check the chain of Responsibility pattern
    [TestClass]
    public class PasswordCheckTest
    {
        [TestMethod]
        public void Password_Valid()
        {
            PasswordCheck check = new PasswordCheck();
            bool result=check.CheckPassword("Al1@sdfghj");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_InvalidDigit()
        {
            PasswordCheck check = new PasswordCheck();
            bool result = check.CheckPassword("A@sdfghj");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Password_InvalidLenth()
        {
            PasswordCheck check = new PasswordCheck();
            bool result = check.CheckPassword("Adfghj");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Password_InvalidSymbol()
        {
            PasswordCheck check = new PasswordCheck();
            bool result = check.CheckPassword("Adfghj");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Password_InvalidUppercase()
        {
            PasswordCheck check = new PasswordCheck();
            bool result = check.CheckPassword("hjdfghj");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Password_InvalidLowercase()
        {
            PasswordCheck check = new PasswordCheck();
            bool result = check.CheckPassword("MJDGFJ");
            Assert.AreEqual(false, result);
        }
    }
}
