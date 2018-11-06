using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dashboard_LibraryManagement.Controllers;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dashboard_LibraryManagement_UnitTest.Controllers
{
    [TestClass]
    public class MemberControllerTest
    {
        [TestMethod]
        public void AddMemberTest_Valid()
        {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			MemberController member = new MemberController();
            LibMember lib = new LibMember();
            //var mock = new Mock<LibMember>();
 //member.AddMember(mock.Object);
            lib.SetFirstname("Priyanka");
            lib.SetLastname("Shanmukha");
            lib.SetEmail("priyanks@gmail.com");
            lib.SetPhone("123456");
            lib.SetDob("08-08-1993");
            lib.SetAddress("145 Edward Street");
            var result = member.AddMember(lib) as ViewResult;
            Assert.AreEqual("AddMember", result.ViewName);
            
         }
		[TestMethod]
		public void AddMemberTest_InValidFirstName()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			MemberController member = new MemberController();
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("123");
			lib.SetLastname("Shanmukha");
			lib.SetEmail("priyanks@gmail.com");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("145 Edward Street");
			var result = member.AddMember(lib) as ViewResult;
			Assert.AreEqual("AddMember", result.ViewName);
     	}

		[TestMethod]
		public void AddMemberTest_InValidLastName()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			MemberController member = new MemberController();
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("Priyanka");
			lib.SetLastname("123");
			lib.SetEmail("priyanks@gmail.com");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("145 Edward Street");
			var result = member.AddMember(lib) as ViewResult;
			Assert.AreEqual("AddMember", result.ViewName);
		}

		[TestMethod]
		public void AddMemberTest_InValidEmail()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			MemberController member = new MemberController();
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("Priyanka");
			lib.SetLastname("123");
			lib.SetEmail("");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("145 Edward Street");
			var result = member.AddMember(lib) as ViewResult;
			Assert.AreEqual("AddMember", result.ViewName);
		}

		//[ExpectedException(typeof(KeyNotFoundException))]
		[TestMethod]
		public void AddMemberTest_EmtpyEmail()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			MemberController member = new MemberController();
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("Priyanka");
			lib.SetLastname("123");
			lib.SetEmail("");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("145 Edward Street");
			var result = member.AddMember(lib) as ViewResult;
			Assert.AreEqual("AddMember", result.ViewName);
		}

		[TestMethod]
		public void AddMemberTest_EmtpyAddress()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			MemberController member = new MemberController();
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("Priyanka");
			lib.SetLastname("123");
			lib.SetEmail("");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("");
			var result = member.AddMember(lib) as ViewResult;
			Assert.AreEqual("AddMember", result.ViewName);
		}

		
		[TestMethod]
		public void Valid_Edit()
		{

			MemberController memberController = new MemberController();
			var result = memberController.Edit("25") as ViewResult;
			Assert.IsNotNull(result);

		}

		[TestMethod]
		public void InValid_Edit()
		{

			MemberController memberController = new MemberController();
			var result = memberController.Edit("-1") as ViewResult;
			Assert.IsNotNull(result);

		}

		[TestMethod]
		public void Valid_EditMember()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("Priyanka");
			lib.SetLastname("123");
			lib.SetEmail("");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("");
			var result = membercontroller.EditMember(lib) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void InvalidValid_EditMember()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("");
			lib.SetLastname("123");
			lib.SetEmail("");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("");
			var result = membercontroller.EditMember(lib) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]

		public void Valid_DeleteMember()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("");
			lib.SetLastname("123");
			lib.SetEmail("");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("");
			var result = membercontroller.DeleteMember("26") as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void InValid_DeleteMember()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			MemberController membercontroller = new MemberController(mock.Object);
			LibMember lib = new LibMember();
			//var mock = new Mock<LibMember>();
			//member.AddMember(mock.Object);
			lib.SetFirstname("Anitt");
			lib.SetLastname("123");
			lib.SetEmail("anitt@dal.ca");
			lib.SetPhone("123456");
			lib.SetDob("08-08-1993");
			lib.SetAddress("");
			var result = membercontroller.DeleteMember("-1") as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}
	}
}
