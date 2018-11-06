using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dashboard_LibraryManagement_UnitTest.DataAccessLayer
{

    [TestClass]
    public class DashboardTableTest
    {
        [TestMethod]
        public void GetActiveBookTranscation()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            DashboardTable dashboardtable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Transcation_ID", "10");
            parameter.Add("Book_ID", "9");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "25");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            //Book book = new Book();

            Assert.IsInstanceOfType(dashboardtable.GetActiveBookTranscation(), typeof(List<BookTranscation>));
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetActiveBookTranscation_Exception()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            DashboardTable dashboardtable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Blank_ID", "10");
            parameter.Add("Book_ID", "9");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "25");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            //Book book = new Book();

            Assert.IsInstanceOfType(dashboardtable.GetActiveBookTranscation(), typeof(List<BookTranscation>));
        }

        [TestMethod]
        public void GetBooksIssued()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            Mock<DashboardTable> mockdash = new Mock<DashboardTable>();
            DashboardTable dashboardtable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Transcation_ID", "10");
            parameter.Add("Book_ID", "9");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "25");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            BookTranscation book = new BookTranscation();
            book.SetMemberID(1);
            book.SetBookID(2);
            book.SetBookStatus("Issued");
            book.SetDateofissue(DateTime.Now);
            book.SetDueDate(DateTime.Now);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            //mockdash.Setup(x => x.GetActiveBookTranscation()).Returns(book);
            Assert.IsInstanceOfType(dashboardtable.GetBooksIssued(), typeof(IEnumerable<BookTranscation>));


        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetBooksIssued_Eception()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            Mock<DashboardTable> mockdash = new Mock<DashboardTable>();
            DashboardTable dashboardtable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Blank", "10");
            parameter.Add("Book_ID", "9");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "25");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            BookTranscation book = new BookTranscation();
            book.SetMemberID(1);
            book.SetBookID(2);
            book.SetBookStatus("Issued");
            book.SetDateofissue(DateTime.Now);
            book.SetDueDate(DateTime.Now);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            //mockdash.Setup(x => x.GetActiveBookTranscation()).Returns(book);
            Assert.IsInstanceOfType(dashboardtable.GetBooksIssued(), typeof(IEnumerable<BookTranscation>));


        }

        [TestMethod]
        public void GetBooksDueToday()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            Mock<DashboardTable> mockdash = new Mock<DashboardTable>();
            DashboardTable dashboardtable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Transcation_ID", "10");
            parameter.Add("Book_ID", "9");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "25");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            BookTranscation book = new BookTranscation();
            book.SetMemberID(1);
            book.SetBookID(2);
            book.SetBookStatus("Issued");
            book.SetDateofissue(DateTime.Now);
            book.SetDueDate(DateTime.Now);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            //mockdash.Setup(x => x.GetActiveBookTranscation()).Returns(book);
            Assert.IsInstanceOfType(dashboardtable.GetBooksDueToday(), typeof(IEnumerable<BookTranscation>));


        }

        [TestMethod]
        public void GetBooksExpired()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            Mock<DashboardTable> mockdash = new Mock<DashboardTable>();
            DashboardTable dashboardtable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Transcation_ID", "10");
            parameter.Add("Book_ID", "9");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "25");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            BookTranscation book = new BookTranscation();
            book.SetMemberID(1);
            book.SetBookID(2);
            book.SetBookStatus("Issued");
            book.SetDateofissue(DateTime.Now);
            book.SetDueDate(DateTime.Now);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            //mockdash.Setup(x => x.GetActiveBookTranscation()).Returns(book);
            Assert.IsInstanceOfType(dashboardtable.GetBooksExpired(), typeof(IEnumerable<BookTranscation>));


        }

        [TestMethod]
        public void GetCountBooksIssued()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            DashboardTable booktable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            BookTranscation book = new BookTranscation();
            parameter.Add("BookStatus", "Issued");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(1, booktable.GetCountBooksIssued());
        }

        [TestMethod]
        public void GetCountBooksIssued_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            DashboardTable booktable = new DashboardTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            BookTranscation book = new BookTranscation();
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(0, booktable.GetCountBooksIssued());
        }
    }
}
