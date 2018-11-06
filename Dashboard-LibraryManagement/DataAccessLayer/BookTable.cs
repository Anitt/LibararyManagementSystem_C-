using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.DataAccessLayer
{
    public class BookTable
    {
       private IDatabase database;
        public BookTable() : this(new MySQLDatabase())
        {
        }

        /// Constructor that takes a MySQLDatabase instance 
        public BookTable(IDatabase database)
        {
            this.database = database;
        }

        public int Insert(Book book)
        {
            string commandText = ProjectConstants.BookInsert;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(ProjectConstants.BookID, book.BookID);
            parameters.Add(ProjectConstants.BookName, book.Name);
            parameters.Add(ProjectConstants.BookAuthor, book.Author);
            parameters.Add(ProjectConstants.BookStatus, book.Status);
            parameters.Add(ProjectConstants.BookPrice, book.Status);
            parameters.Add(ProjectConstants.BookRackNo, book.Rackno);
            parameters.Add(ProjectConstants.BookNoOfBooks, book.Count);


            return database.Execute(commandText, parameters);
        }
      
       /// Deletes a book from the Book table
       public int DeleteById(string bookid)
        {
            string commandText = ProjectConstants.BookDeleteById;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(ProjectConstants.BookID, bookid);

            return database.Execute(commandText, parameters);
        }
        public int Delete(Book book)
        {
            return DeleteById(book.BookID.ToString());
        }


        public IEnumerable<Book> GetBooks()
        {
            try
            {
                string commandText = ProjectConstants.BookGetBooks;
               
                List<Dictionary<string,string>> books =   database.Query(commandText, null);
                List<Book> results = new List<Book>();
                foreach(var book in books)
                {
                    Book currentBook = new Book();
                    currentBook.Author = book[ProjectConstants.KeyBookAuthor];
                    currentBook.BookID = Convert.ToInt32( book[ProjectConstants.KeyBookID]);
                    currentBook.Count = Convert.ToInt32( book[ProjectConstants.KeyBookNoOfBooks]);
                    currentBook.Name = book[ProjectConstants.KeyBookName];
                    currentBook.Rackno = Convert.ToInt32( book[ProjectConstants.KeyBookRackNo]);
                    currentBook.Status = book[ProjectConstants.KeyBookStatus];
                    results.Add(currentBook);
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Book GetBookById(string bookid)
        {
            try
            {
                string commandText = ProjectConstants.BookGetBookById;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(ProjectConstants.BookID, bookid);

                var book = database.Query(commandText, parameters).FirstOrDefault();
                if (book == null)
                    return null;

                Book currentBook = new Book();
                currentBook.Author = book[ProjectConstants.KeyBookAuthor];
                currentBook.BookID = Convert.ToInt32(book[ProjectConstants.KeyBookID]);
                currentBook.Count = Convert.ToInt32(book[ProjectConstants.KeyBookNoOfBooks]);
                currentBook.Name = book[ProjectConstants.KeyBookName];
                currentBook.Rackno = Convert.ToInt32(book[ProjectConstants.KeyBookRackNo]);
                currentBook.Status = book[ProjectConstants.KeyBookStatus];

                return currentBook;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Book book)
        {
            string commandText = ProjectConstants.BookUpdate;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(ProjectConstants.BookID, book.BookID);
            parameters.Add(ProjectConstants.BookName, book.Name);
            parameters.Add(ProjectConstants.BookName, book.Author);
            parameters.Add(ProjectConstants.BookStatus, book.Status);
            parameters.Add(ProjectConstants.BookRackNo, book.Rackno);
            parameters.Add(ProjectConstants.BookNoOfBooks, book.Count);

            return database.Execute(commandText, parameters);
        }
    }

}
