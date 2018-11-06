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
	//[TestClass]
	//public class DashBoardControllerTest
	//{
		
	//	[TestMethod]
	//	public void valid_index() {
	//		Mock<IDatabase> mock = new Mock<IDatabase>();
	//		mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
	//		AccountController accountcontroller = new AccountController(mock.Object);
	//		UserAccount useraccount = new UserAccount();
	//		useraccount.SetUserID(12);
	//		useraccount.SetFirstName("yuvi");
	//		useraccount.SetLastName("subramanium");
	//		useraccount.SetEmail("abc@gmail.com");
	//		useraccount.SetPassword("A!@sdfghj");
	//		useraccount.SetConfirmPassword("A!@sdfghj");
	//		useraccount.SetAdmin(false);

	//		Dictionary<string, string> parameterbbok = new Dictionary<string, string>();
	//		List<Dictionary<string, string>> resultbook = new List<Dictionary<string, string>>();
	//		parameterbbok.Add("Transcation_ID", "10");
	//		parameterbbok.Add("Book_ID", "9");
	//		parameterbbok.Add("BookStatus", "Renewed");
	//		parameterbbok.Add("Member_ID", "25");
	//		parameterbbok.Add("Due_Date", "2018-07-22 17:35:23");
	//		parameterbbok.Add("Date_of_issue", "2018-07-22 17:35:23");
	//		resultbook.Add(parameterbbok);
	//		BookTranscation book = new BookTranscation();
	//		book.SetMemberID(1);
	//		book.SetBookID(2);
	//		book.SetBookStatus("Issued");
	//		book.SetDateofissue(DateTime.Now);
	//		book.SetDueDate(DateTime.Now);
	//		mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(resultbook);
	//		//book expired
	//		Dictionary<string, string> parameterexpired = new Dictionary<string, string>();
	//		List<Dictionary<string, string>> resultexpired = new List<Dictionary<string, string>>();
	//		parameterexpired.Add("Transcation_ID", "10");
	//		parameterexpired.Add("Book_ID", "9");
	//		parameterexpired.Add("BookStatus", "Renewed");
	//		parameterexpired.Add("Member_ID", "25");
	//		parameterexpired.Add("Due_Date", "2018-07-22 17:35:23");
	//		parameterexpired.Add("Date_of_issue", "2018-07-22 17:35:23");
	//		resultexpired.Add(parameterexpired);
	//	//setting
	//		book.SetMemberID(1);
	//		book.SetBookID(2);
	//		book.SetBookStatus("Issued");
	//		book.SetDateofissue(DateTime.Now);
	//		book.SetDueDate(DateTime.Now);
	//		mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(resultexpired);
	//		// books due today

	//		Dictionary<string, string> parameterduetoday = new Dictionary<string, string>();
	//		List<Dictionary<string, string>> resultduetoday = new List<Dictionary<string, string>>();
	//		parameterduetoday.Add("Transcation_ID", "10");
	//		parameterduetoday.Add("Book_ID", "9");
	//		parameterduetoday.Add("BookStatus", "Renewed");
	//		parameterduetoday.Add("Member_ID", "25");
	//		parameterduetoday.Add("Due_Date", "2018-07-22 17:35:23");
	//		parameterduetoday.Add("Date_of_issue", "2018-07-22 17:35:23");
	//		resultduetoday.Add(parameterduetoday);
	//		book.SetMemberID(1);
	//		book.SetBookID(2);
	//		book.SetBookStatus("Issued");
	//		book.SetDateofissue(DateTime.Now);
	//		book.SetDueDate(DateTime.Now);
	//		mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(resultduetoday);
	//		DashboardController dashboardController = new DashboardController();
	//		var controllerresult = dashboardController.Index() as ViewResult;
	//		Assert.IsNotNull(controllerresult);



	//	}

	//}
}
