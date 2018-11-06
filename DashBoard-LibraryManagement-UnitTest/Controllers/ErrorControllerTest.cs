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
	public class ErrorControllerTest
	{
		[TestMethod]
		public void Valid_Indexpage()
		{

			ErrorController errorcontroller = new ErrorController();
			var result = errorcontroller.Index() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_HTTPError404()
		{

			ErrorController errorcontroller = new ErrorController();
			var result = errorcontroller.HttpError404() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_HTTPError500()
		{

			ErrorController errorcontroller = new ErrorController();
			var result = errorcontroller.HttpError500() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_General()
		{

			ErrorController errorcontroller = new ErrorController();
			var result = errorcontroller.General() as ViewResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Valid_DatabaseError()
		{

			ErrorController errorcontroller = new ErrorController();
			var result = errorcontroller.DatabaseError() as ViewResult;
			Assert.IsNotNull(result);
		}



	}
}
