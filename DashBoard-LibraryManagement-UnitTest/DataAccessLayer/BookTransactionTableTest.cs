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
    public class BookTransactionTableTest
    {
        [TestMethod]
        public void Insert()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            BookTranscation book = new BookTranscation();
            book.SetMemberID(1);
            book.SetBookID(2);
            book.SetBookStatus("Renewed");
            book.SetDateofissue(DateTime.Now);
            book.SetDueDate(DateTime.Now);
            int result = booktable.Insert(book);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteByTranscationId()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            int result = booktable.DeleteByTranscationId("25");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetBooksForIssue()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Author", "test");
            parameter.Add("Book_id", "9");
            parameter.Add("No_of_books", "10");
            parameter.Add("Name", "test");
            parameter.Add("Rack_No", "11");
            parameter.Add("Status", "test");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Book book = new Book();

            Assert.IsInstanceOfType(booktable.GetBooksForIssue(), typeof(List<Book>));
        }

        [TestMethod]
        public void GetBookTransactionById_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(null, booktable.GetBookTransactionById("1"));
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetBookTransactionById_ExpectedException()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("new", "test");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.IsInstanceOfType(booktable.GetBookTransactionById("1"), typeof(BookTranscation));
        }

        [TestMethod]
        public void GetBookTransactionById_Valid()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Transcation_ID", "20");
            parameter.Add("Book_ID", "4080");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "10");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.IsInstanceOfType(booktable.GetBookTransactionById("20"), typeof(BookTranscation));
        }

        [TestMethod]
        public void GetBookTransactionsByBookId()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Transcation_ID", "20");
            parameter.Add("Book_ID", "4080");
            parameter.Add("BookStatus", "Renewed");
            parameter.Add("Member_ID", "10");
            parameter.Add("Due_Date", "2018-07-22 17:35:23");
            parameter.Add("Date_of_issue", "2018-07-22 17:35:23");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.IsInstanceOfType(booktable.GetBookTransactionsByBookId(1,true), typeof(List<BookTranscation>));
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetBookTransactionsByBookId_ExpectedException()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("new", "test");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.IsInstanceOfType(booktable.GetBookTransactionsByBookId(1, true), typeof(List<BookTranscation>));
        }

        [TestMethod]
        public void GetBookTransactionCountByBookId_Zero()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(0,booktable.GetBookTransactionCountByBookId(1, true));
        }

        [TestMethod]
        public void GetBookTransactionCountByBookId()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("Book_ID", "1");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(1, booktable.GetBookTransactionCountByBookId(1, true));
        }

        [TestMethod]
        public void RenewBook()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            BookTranscationTable booktable = new BookTranscationTable(mock.Object);
            BookTranscation book = new BookTranscation();
            book.SetTranscationID(1);
            book.SetBookStatus("Renewed");
            book.SetDueDate(DateTime.Now);
            int result = booktable.Insert(book);
            Assert.AreEqual(1, result);
        }







    }
}
