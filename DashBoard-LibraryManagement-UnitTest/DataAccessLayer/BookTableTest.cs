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
    public class BookTableTest
    {
        [TestMethod]
        public void Insert()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            BookTable booktable = new BookTable(mock.Object);
            Book book = new Book();
            book.SetName("TestBook");
            book.SetAuthor("TestSuthor");
            book.SetStatus("available");
            book.SetPrice(25);
            book.SetRackno(5);
            book.SetCount(10);
            int result = booktable.Insert(book);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeletebyId()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            BookTable booktable = new BookTable(mock.Object);
            int result = booktable.DeleteById("25");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetBookbyId_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTable booktable = new BookTable(mock.Object);
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.AreEqual(null, booktable.GetBookById("1"));
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void GetBookbyId_ExpectedException()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTable booktable = new BookTable(mock.Object);
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            parameter.Add("new", "test");
            result.Add(parameter);
            mock.Setup(x => x.Query(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(result);
            Assert.IsInstanceOfType(booktable.GetBookById("1"), typeof(Book));
        }

        [TestMethod]
        public void GetBookbyId_Valid()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTable booktable = new BookTable(mock.Object);
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
           Assert.IsInstanceOfType(booktable.GetBookById("1"), typeof(Book));
        }

        [TestMethod]
        public void Update()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Setup(x => x.Execute(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(1);
            BookTable booktable = new BookTable(mock.Object);
            Book book = new Book();
            book.SetName("TestBook");
            book.SetAuthor("TestSuthor");
            book.SetStatus("available");
            book.SetPrice(25);
            book.SetRackno(5);
            book.SetCount(10);
            int result = booktable.Update(book);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetBooks()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            BookTable booktable = new BookTable(mock.Object);
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

            Assert.IsInstanceOfType(booktable.GetBooks(), typeof(List<Book>));
        }
    }
}
