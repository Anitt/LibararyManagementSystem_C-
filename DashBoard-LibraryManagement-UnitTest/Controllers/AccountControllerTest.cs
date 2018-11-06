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
{    [TestClass]
	public class AccountControllerTest
	{  
		//[TestMethod]
		//public void Valid_Login() {

		//	LoginViewModel loginviewmodel = new LoginViewModel();
		//	AccountController accountcontroller = new AccountController();
		//	loginviewmodel.SetEmail("anitt.anv19@gmail.com");
		//	loginviewmodel.SetPassword("anittanitt");
		//	var result = accountcontroller.Login(loginviewmodel, null) as ViewResult;
		//	Assert.AreEqual("Index", result.ViewName);
		
		//}
		[TestMethod]
		public void InvalidLogin_EmailNotExisiting()
		{

			LoginViewModel loginviewmodel = new LoginViewModel();
			AccountController accountcontroller = new AccountController();
			loginviewmodel.SetEmail("hello.anv19@gmail.com");
			loginviewmodel.SetPassword("anittanitt");
			var result = accountcontroller.Login(loginviewmodel, null) as ViewResult;
			Assert.AreEqual("", result.ViewName);

		}
		[TestMethod]
		public void InvalidLogin_WrongPassword()
		{

			LoginViewModel loginviewmodel = new LoginViewModel();
			AccountController accountcontroller = new AccountController();
			loginviewmodel.SetEmail("anitt.anv19@gmail.com");
			loginviewmodel.SetPassword("anitt");
			var result = accountcontroller.Login(loginviewmodel, null) as ViewResult;
			Assert.AreEqual("", result.ViewName);

		}

		[TestMethod]
		public void InvalidLogin_NullEmailID()
		{

			LoginViewModel loginviewmodel = new LoginViewModel();
			AccountController accountcontroller = new AccountController();
			loginviewmodel.SetEmail("");
			loginviewmodel.SetPassword("anitt");
			var result = accountcontroller.Login(loginviewmodel, null) as ViewResult;
			Assert.AreEqual("", result.ViewName);

		}

		[TestMethod]
		public void InvalidLogin_NullPassword()
		{

			LoginViewModel loginviewmodel = new LoginViewModel();
			AccountController accountcontroller = new AccountController();
			loginviewmodel.SetEmail("anitt.anv19@gmail.com");
			loginviewmodel.SetPassword("");
			var result = accountcontroller.Login(loginviewmodel, null) as ViewResult;
			Assert.AreEqual("", result.ViewName);

		}
		[TestMethod]
		public void Valid_Searchcase() {

			AccountController accountcontroller = new AccountController();


		}
		[TestMethod]
		public void Valid_Edit() {

			AccountController accountcontroller = new AccountController();
			var result = accountcontroller.Edit("15") as ViewResult;
			Assert.IsNotNull(result);

		}

		[TestMethod]

		public void Valid_DeleteUser() {

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
			var result = accountcontroller.DeleteUser("12") as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]

		public void Valid_EditUser()
		{

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
			var result = accountcontroller.Edituser(useraccount) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_Indexpage()
		{

			AccountController accountcontroller = new AccountController();
			var result = accountcontroller.Index() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_AddAdmin()
		{

			AccountController accountcontroller = new AccountController();
			var result = accountcontroller.AddAdmin() as ViewResult;
			Assert.IsNotNull(result);
		}


	}
}
