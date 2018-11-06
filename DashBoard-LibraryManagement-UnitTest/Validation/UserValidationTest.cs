using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.Controllers;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Dashboard_LibraryManagement.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dashboard_LibraryManagement_UnitTest.Validation
{
    [TestClass]
    public class UserValidationTest
    {
        [TestMethod]
        public void ValidateUser_Valid()
        {

            UserValidation record = new UserValidation();
            UserAccount useraccount = new UserAccount();
			Mock<IDatabase> mock = new Mock<IDatabase>();
			AccountController accountController = new AccountController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			parameter.Add("ID", "1");
			parameter.Add("First_Name", "Test");
			parameter.Add("Last_Name", "aaaa");
			parameter.Add("Email_id", "case");
			parameter.Add("Password", "afasf");
			parameter.Add("Is_admin", "true");
			result.Add(parameter);
			useraccount.SetUserID(12);
			useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("sharkuser@gmail.com");
            useraccount.SetPassword("Sharkuser!234");
            useraccount.SetConfirmPassword("Sharkuser!234");
            useraccount.SetAdmin(false);
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			bool uservalidate = record.ValidateUser(useraccount.Email, useraccount.Password, out useraccount);
            Assert.AreEqual(true, uservalidate);

		}

        [TestMethod]
        public void ValidateUser_InvalidEmail()
        {

            UserValidation record = new UserValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(12);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("asdf@gmail.com");
            useraccount.SetPassword("A1@sdfghj");
            useraccount.SetConfirmPassword("A1@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateUser(useraccount.Email, useraccount.Password, out useraccount);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void ValidateUser_InvalidPassword()
        {

            UserValidation record = new UserValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(12);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("ys@gmail.com");
            useraccount.SetPassword("A123sdfghj");
            useraccount.SetConfirmPassword("A123sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateUser(useraccount.Email, useraccount.Password, out useraccount);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void ValidateUser_NullEmail()
        {

            UserValidation record = new UserValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(12);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("");
            useraccount.SetPassword("A1@sdfghj");
            useraccount.SetConfirmPassword("A1@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateUser(useraccount.Email, useraccount.Password, out useraccount);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void ValidateUser_NullPassword()
        {

            UserValidation record = new UserValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(12);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("ys@gmail.com");
            useraccount.SetPassword("");
            useraccount.SetConfirmPassword("A1@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateUser(useraccount.Email, useraccount.Password, out useraccount);
            Assert.AreEqual(false, result);

        }





    }
}
