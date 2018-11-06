using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dashboard_LibraryManagement.Controllers;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dashboard_LibraryManagement_UnitTest
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public void AddBookTest_Valid()
        {
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
            Book book = new Book();
            book.SetBookID(1);
            book.SetName("New York Times");
            book.SetAuthor("James Keith");
            book.SetStatus("Available");
            book.SetPrice(25);
            book.SetRackno(12);
            book.SetCount(2);
            var result= bookcontroller.AddBook(book) as ViewResult ;
            Assert.AreEqual("AddBook", result.ViewName);
        }

        [TestMethod]
        public void AddBookTest_Invalid()
        {
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			Book book = new Book();
            book.SetBookID(1);
            book.SetName("Times");
            book.SetAuthor("David Stanley");
            book.SetStatus("Available");
            book.SetPrice(25);
            book.SetRackno(12);
            book.SetCount(0);
            var result = bookcontroller.AddBook(book) as ViewResult;
			Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IssueBook_ValidCount()
        {
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			var book = new BookTranscation { TranscationID = 100, MemberID = 25, BookID = 4080, BookStatus = "available", DateofIssue = new DateTime(2018, 07, 12), DueDate = new DateTime(2018, 07, 22) };
            var result = bookcontroller.IssueBook(book) as ViewResult;
            Assert.AreEqual("IssueBook", result.ViewName);

        }
		[TestMethod]
		public void IssueBook_inValidCount()
		{
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			var book = new BookTranscation { TranscationID = 100, MemberID = 25, BookID = 22, BookStatus = "available", DateofIssue = new DateTime(2018, 07, 12), DueDate = new DateTime(2018, 07, 22) };
			var result = bookcontroller.IssueBook(book) as ViewResult;
			Assert.AreEqual("IssueBook", result.ViewName);

		}
		[TestMethod]
		public void IssueBook_InvalidMemberID()
		{
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			var book = new BookTranscation { TranscationID = 100, MemberID = 01, BookID = 4080, BookStatus = "available", DateofIssue = new DateTime(2018, 07, 12), DueDate = new DateTime(2018, 07, 22) };
			var result = bookcontroller.IssueBook(book) as ViewResult;
			Assert.IsNotNull(result);

		}

		[TestMethod]
		public void IssueBook_NullBookID() {
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			var book = new BookTranscation();
			book.SetTranscationID(11);
			book.SetMemberID(25);
			book.SetBookID(0);
			book.SetBookStatus("available");
			book.SetDateofissue(new DateTime(2018, 07, 22));
			book.SetDueDate(new DateTime(2018, 07, 22));
			var result = bookcontroller.IssueBook(book) as ViewResult;
			Assert.IsNotNull(result);

		}
		[TestMethod]
		public void IssueBook_invalidBookID()
		{
			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			var book = new BookTranscation();
			book.SetTranscationID(11);
			book.SetMemberID(25);
			book.SetBookID(3);
			book.SetBookStatus("available");
			book.SetDateofissue(new DateTime(2018, 07, 22));
			book.SetDueDate(new DateTime(2018, 07, 22));
			var result = bookcontroller.IssueBook(book) as ViewResult;
			Assert.IsNotNull(result);

		}
		[TestMethod]
		public void Valid_Edit()
		{

			BookController bookcontroller = new BookController();
			var result = bookcontroller.Edit("15") as ViewResult;
			Assert.IsNotNull(result);

		}

		[TestMethod]
		public void InValid_Edit()
		{

			BookController bookcontroller = new BookController();
			var result = bookcontroller.Edit("0") as ViewResult;
			Assert.IsNotNull(result);

		}
		[TestMethod]
		public void Valid_EditBook()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			Book book = new Book();
			book.SetBookID(1);
			book.SetName("Times");
			book.SetAuthor("David Stanley");
			book.SetStatus("Available");
			book.SetPrice(25);
			book.SetRackno(12);
			book.SetCount(0);
			var result = bookcontroller.EditBook(book) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void InValid_EditBook()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			Book book = new Book();
			book.SetBookID(0);
			book.SetName("Times");
			book.SetAuthor("David Stanley");
			book.SetStatus("Available");
			book.SetPrice(25);
			book.SetRackno(12);
			book.SetCount(0);
			var result = bookcontroller.EditBook(book) as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}

		[TestMethod]

		public void Valid_DeleteBook()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController  bookcontroller = new BookController(mock.Object);
			Book book = new Book();
			book.SetBookID(1);
			book.SetName("Times");
			book.SetAuthor("David Stanley");
			book.SetStatus("Available");
			book.SetPrice(25);
			book.SetRackno(12);
			book.SetCount(0);
			var result = bookcontroller.DeleteBook("12") as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void InValid_DeleteBook()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
			BookController bookcontroller = new BookController(mock.Object);
			Book book = new Book();
			book.SetBookID(-1);
			book.SetName("Times");
			book.SetAuthor("David Stanley");
			book.SetStatus("Available");
			book.SetPrice(25);
			book.SetRackno(12);
			book.SetCount(0);
			var result = bookcontroller.DeleteBook("12") as RedirectToRouteResult;
			Assert.IsNotNull(result);
		}


		[TestMethod]
		public void Valid_Issue() {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			parameter.Add("Book_id", "4081");
			parameter.Add("Author", "Test");
			parameter.Add("No_of_books", "10");
			parameter.Add("Name", "case");
			parameter.Add("Rack_No", "12");
			parameter.Add("Status", "case");
			result.Add(parameter);
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			//Book book = new Book();

			//Assert.IsInstanceOfType(bookcontroller.Issue("4081"), typeof(Book));
			var booksissued = bookcontroller.Issue("4081") as ViewResult;
			Assert.IsNotNull(booksissued);

        }

		[TestMethod]
		public void Valid_IssueBook() {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			BookTransactionViewModel bookTransactionViewModel = new BookTransactionViewModel() { Name = "Anitt" , Author = "AnittRajendran" ,BookID = 4081 , BookStatus = "Available" , DateofIssue = new DateTime(2018, 07, 12) , DueDate = new DateTime(2018, 07, 12) };
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			parameter.Add("Member_ID", "90");
			parameter.Add("First_Name", "case");
			parameter.Add("Last_Name", "case");
			parameter.Add("Email_id", "case");
			parameter.Add("Phone_no", "case");
			parameter.Add("Address", "case");
			parameter.Add("DOB", "case");
			result.Add(parameter);
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			Dictionary<string, string> parameterbook = new Dictionary<string, string>();
			List<Dictionary<string, string>> resultbook = new List<Dictionary<string, string>>();
			parameter.Add("Book_id", "4081");
			parameter.Add("Author", "Test");
			parameter.Add("No_of_books", "10");
			parameter.Add("Name", "case");
			parameter.Add("Rack_No", "12");
			parameter.Add("Status", "case");
			result.Add(parameterbook);
			var booktranscation = bookcontroller.Issue(bookTransactionViewModel) as RedirectToRouteResult;
			Assert.IsNotNull(booktranscation);
    }


		[TestMethod]
		public void InValid_IssueBook()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			BookTransactionViewModel bookTransactionViewModel = new BookTransactionViewModel() { Name = "Anitt", Author = "AnittRajendran", BookID = 4081, BookStatus = "Available", DateofIssue = new DateTime(2018, 07, 12), DueDate = new DateTime(2018, 07, 12) };
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			parameter.Add("Member_ID", "-1");
			parameter.Add("First_Name", "case");
			parameter.Add("Last_Name", "case");
			parameter.Add("Email_id", "case");
			parameter.Add("Phone_no", "case");
			parameter.Add("Address", "case");
			parameter.Add("DOB", "case");
			result.Add(parameter);
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			Dictionary<string, string> parameterbook = new Dictionary<string, string>();
			List<Dictionary<string, string>> resultbook = new List<Dictionary<string, string>>();
			parameter.Add("Book_id", "4081");
			parameter.Add("Author", "Test");
			parameter.Add("No_of_books", "10");
			parameter.Add("Name", "case");
			parameter.Add("Rack_No", "12");
			parameter.Add("Status", "case");
			result.Add(parameterbook);
			var booktranscation = bookcontroller.Issue(bookTransactionViewModel) as RedirectToRouteResult;
			Assert.IsNotNull(booktranscation);
		}
		[TestMethod]
		public void Valid_RenewBook() {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            BookTranscation booktranscation = new BookTranscation();
            booktranscation.SetTranscationID(11);
			booktranscation.SetMemberID(25);
			booktranscation.SetBookID(3);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "4081");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookrenew = bookcontroller.RenewBook("4081") as ViewResult;
			Assert.IsNotNull(bookrenew);
}
		[TestMethod]
		public void InValid_RenewBook()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			BookTranscation booktranscation = new BookTranscation();
			booktranscation.SetTranscationID(11);
			booktranscation.SetMemberID(25);
			booktranscation.SetBookID(3);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "123");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookrenew = bookcontroller.RenewBook("4081") as ViewResult;
			Assert.IsNotNull(bookrenew);
		}

		[TestMethod]
		public void Valid_ReturnBook() {


			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			BookTranscation booktranscation = new BookTranscation();
			booktranscation.SetTranscationID(11);
			booktranscation.SetMemberID(25);
			booktranscation.SetBookID(3);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "123");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookreturn = bookcontroller.ReturnBook("4081") as ViewResult;
			Assert.IsNotNull(bookreturn);


		}

		[TestMethod]
		public void InValid_ReturnBook()
		{


			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			BookTranscation booktranscation = new BookTranscation();
			booktranscation.SetTranscationID(0);
			booktranscation.SetMemberID(0);
			booktranscation.SetBookID(0);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "123");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookreturn = bookcontroller.ReturnBook("4081") as ViewResult;
			Assert.IsNotNull(bookreturn);


		}

		[TestMethod]
		public void Valid_RenewTranscation() {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			BookTranscation booktranscation = new BookTranscation();
			booktranscation.SetTranscationID(123);
			booktranscation.SetMemberID(25);
			booktranscation.SetBookID(4081);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "123");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookrenewtrancation = bookcontroller.RenewTransaction("123") as RedirectToRouteResult;
			Assert.IsNotNull(bookrenewtrancation);


		}
		[TestMethod]
		public void InValid_RenewTranscation()
		{

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			BookTranscation booktranscation = new BookTranscation();
			booktranscation.SetTranscationID(0);
			booktranscation.SetMemberID(0);
			booktranscation.SetBookID(0);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "123");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookrenewtrancation = bookcontroller.RenewTransaction("123") as RedirectToRouteResult;
			Assert.IsNotNull(bookrenewtrancation);
        }

		[TestMethod]
		public void Valid_ReturnTranscation() {

			Mock<IDatabase> mock = new Mock<IDatabase>();
			BookController bookcontroller = new BookController(mock.Object);
			Dictionary<string, string> parameter = new Dictionary<string, string>();
			List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
			BookTranscation booktranscation = new BookTranscation();
			booktranscation.SetTranscationID(0);
			booktranscation.SetMemberID(0);
			booktranscation.SetBookID(0);
			booktranscation.SetBookStatus("available");
			booktranscation.SetDateofissue(new DateTime(2018, 07, 22));
			booktranscation.SetDueDate(new DateTime(2018, 07, 22));
			mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
			parameter.Add("Transcation_ID", "11");
			parameter.Add("Member_ID", "25");
			parameter.Add("Book_ID", "123");
			parameter.Add("BookStatus", "Available");
			parameter.Add("Due_Date", "2018, 07, 22");
			parameter.Add("Date_of_issue", "2018, 07, 22");
			result.Add(parameter);
			var bookreturntranscation = bookcontroller.RenewTransaction("4081") as RedirectToRouteResult;
			Assert.IsNotNull(bookreturntranscation);





		}


	}
}
