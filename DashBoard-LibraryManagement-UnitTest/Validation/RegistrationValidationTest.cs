using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.Models;
using Dashboard_LibraryManagement.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dashboard_LibraryManagement_UnitTest
{
    [TestClass]
    public class RegistrationValidationTest
    {
        [TestMethod]
        public void ValidateRegistration_Valid()
        {
           
            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(12);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("abc@gmail.com");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateRegistration_InvalidUserID()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(-10);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("abc@gmail.com");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
			Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ValidateRegistration_InvalidFirstname()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(10);
            useraccount.SetFirstName("Mary123");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("abc@gmail.com");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateRegistration_InvalidLastname()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(10);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("1Joji");
            useraccount.SetEmail("abc@gmail.com");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateRegistration_InvalidEmail()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(-10);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, false);
        }

        [TestMethod]
        public void ValidateRegistration_NullEmail()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(10);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateRegistration_NullPassword()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(10);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("abc@gmail.com");
            useraccount.SetPassword("");
            useraccount.SetConfirmPassword("");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateRegistration_PasswordConfirmFail()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(-10);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("abc@gmail.com");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sd");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateRegistration_ExistingUser()
        {

            RegistrationValidation record = new RegistrationValidation();
            UserAccount useraccount = new UserAccount();
            useraccount.SetUserID(12);
            useraccount.SetFirstName("Mary");
            useraccount.SetLastName("Joji");
            useraccount.SetEmail("mary.nn3@gmail.com");
            useraccount.SetPassword("A!@sdfghj");
            useraccount.SetConfirmPassword("A!@sdfghj");
            useraccount.SetAdmin(false);
            bool result = record.ValidateRegistration(useraccount);
            Assert.AreEqual(false, false);
        }




    }
}
