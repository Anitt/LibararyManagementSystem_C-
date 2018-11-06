using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.PasswordValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest.PasswordValidate
{
    //Test case for the function to check if the password contains symbol

    [TestClass]
    public class SymbolCheckTest
    {
        [TestMethod]
        public void Password_Valid()
        {
            PropertyCheck password = new PropertyCheck("Al1@sdfghj");
            SymbolCheck symbol = new SymbolCheck();
            bool result = symbol.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasSymbol()
        {
            PropertyCheck password = new PropertyCheck("#l1@hj");
            SymbolCheck symbol = new SymbolCheck();
            bool result = symbol.checkPassword(password);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Password_HasNoSymbol()
        {
            PropertyCheck password = new PropertyCheck("asl1DFhj");
            SymbolCheck symbol = new SymbolCheck();
            bool result = symbol.checkPassword(password);
            Assert.AreEqual(false, result);
        }
    }
}
