using Dashboard_LibraryManagement.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dashboard_LibraryManagement_UnitTest.Controllers
{
	[TestClass]
    public class HomeControllerTests
    {

		[TestMethod]
		public void Valid_Indexpage() {

			HomeController homecontroller = new HomeController();
			var result = homecontroller.Index() as ViewResult;
			Assert.IsNotNull(result);
       }

		[TestMethod]
		public void Valid_Aboutpage()
		{

			HomeController homecontroller = new HomeController();
			var result = homecontroller.About() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_Contactpage()
		{

			HomeController homecontroller = new HomeController();
			var result = homecontroller.Contact() as ViewResult;
			Assert.IsNotNull(result);
		}

	}
}
