using Dashboard_LibraryManagement.Controllers;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dashboard_LibraryManagement_UnitTest.Controllers
{
	[TestClass]
	public class AccountControllerRegisterTest
	{
		[TestMethod]
		public void Validate_RegistrationValid() {

			// mocking 
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			AccountController accountcontroller = new AccountController(mock.Object);
            UserAccount useraccount = new UserAccount();
			useraccount.SetUserID(12);
			useraccount.SetFirstName("yuvi");
			useraccount.SetLastName("subramanium");
			useraccount.SetEmail("abc@gmail.com");
			useraccount.SetPassword("A!@sdfghj");
			useraccount.SetConfirmPassword("A!@sdfghj");
			useraccount.SetAdmin(false);
			var result = accountcontroller.Register(useraccount) as ViewResult;
			Assert.AreEqual("Register", result.ViewName);
		}
		[TestMethod]
		public void Invalidate_InvalidFirstName() {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			AccountController accountcontroller = new AccountController(mock.Object);
			UserAccount useraccount = new UserAccount();
			useraccount.SetUserID(12);
			useraccount.SetFirstName("yuvaraj12");
			useraccount.SetLastName("subramanium");
			useraccount.SetEmail("abc@gmail.com");
			useraccount.SetPassword("A!@sdfghj");
			useraccount.SetConfirmPassword("A!@sdfghj");
			useraccount.SetAdmin(false);
			var result = accountcontroller.Register(useraccount) as ViewResult;
			Assert.AreEqual("Register", result.ViewName);


		}




	}
}
