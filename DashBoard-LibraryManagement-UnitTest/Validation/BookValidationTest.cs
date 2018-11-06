using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard_LibraryManagement.Models;
using Dashboard_LibraryManagement.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dashboard_LibraryManagement_UnitTest
{
    [TestClass]
    public class BookValidationTest
    {
        [TestMethod]
        public void ValidateBook_Valid()
        {
            BookValidation bookvalid = new BookValidation();
            Book book = new Book();
            book.SetBookID(1);
            book.SetName("Times");
            book.SetAuthor("David Bolton");
            book.SetStatus("Available");
            book.SetPrice(25);
            book.SetRackno(12);
            book.SetCount(2);
            
            bool result = bookvalid.ValidateBook(book);
            Assert.AreEqual(true, result);
        }

        

        [TestMethod]
        public void ValidateBook_InvalidBookID()
        {
            BookValidation bookvalid = new BookValidation();
            Book book = new Book();
            book.SetBookID(-1);
            book.SetName("Times");
            book.SetAuthor("David Bolton");
            book.SetStatus("Available");
            book.SetPrice(25);
            book.SetRackno(12);
            book.SetCount(2);

            bool result = bookvalid.ValidateBook(book);
			Assert.AreEqual(false,false);
        }

        [TestMethod]
        public void ValidateBook_InvalidCount()
        {
            BookValidation bookvalid = new BookValidation();
            Book book = new Book();
            book.SetBookID(-1);
            book.SetName("Times");
            book.SetAuthor("David Bolton");
            book.SetStatus("Available");
            book.SetPrice(25);
            book.SetRackno(12);
            book.SetCount(0);

            bool result = bookvalid.ValidateBook(book);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateBook_InvalidRackno()
        {
            BookValidation bookvalid = new BookValidation();
            Book book = new Book();
            book.SetBookID(-1);
            book.SetName("Times");
            book.SetAuthor("David Bolton");
            book.SetStatus("Available");
            book.SetPrice(25);
            book.SetRackno(0);
            book.SetCount(2);

            bool result = bookvalid.ValidateBook(book);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidateBook_NullStatus()
        {
            BookValidation bookvalid = new BookValidation();
            Book book = new Book();
            book.SetBookID(-1);
            book.SetName("Times");
            book.SetAuthor("David Bolton");
            book.SetStatus("");
            book.SetPrice(25);
            book.SetRackno(0);
            book.SetCount(2);

            bool result = bookvalid.ValidateBook(book);
            Assert.AreEqual(false, result);
        }

        public void ValidateBook_ExistingBook()
        {
            BookValidation bookvalid = new BookValidation();
            Book book = new Book();
            book.SetBookID(-1);
            book.SetName("Times");
            book.SetAuthor("David Stanley");
            book.SetStatus("");
            book.SetPrice(25);
            book.SetRackno(0);
            book.SetCount(2);

            bool result = bookvalid.ValidateBook(book);
            Assert.AreEqual(false, result);
        }


    }
}
