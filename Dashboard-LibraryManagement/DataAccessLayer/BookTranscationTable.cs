using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.DataAccessLayer
{
    public class BookTranscationTable
    {

        private IDatabase database;
        public BookTranscationTable() : this(new MySQLDatabase())
        {
        }
        /// Constructor that takes a MySQLDatabase instance 
        public BookTranscationTable(IDatabase database)
        {
            this.database = database;
        }

        public int Insert(BookTranscation booktranscation)
        {
            string commandText =ProjectConstants.BTInsert;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(ProjectConstants.TransactionID, booktranscation.TranscationID);
            parameters.Add(ProjectConstants.MemberID, booktranscation.MemberID);
            parameters.Add(ProjectConstants.BookID, booktranscation.BookID);
            parameters.Add(ProjectConstants.DateOfIssue, booktranscation.DateofIssue);
            parameters.Add(ProjectConstants.DueDate, booktranscation.DueDate);
            parameters.Add(ProjectConstants.TransactionBookStatus, booktranscation.BookStatus);
            
            return database.Execute(commandText, parameters);
        }

        public int DeleteByTranscationId(string transcationid)
        {
            string commandText = ProjectConstants.BTDeleteById;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(ProjectConstants.TransactionID, transcationid);

            return database.Execute(commandText, parameters);
        }

        public int Delete(BookTranscation booktranscation)
        {
            return DeleteByTranscationId(booktranscation.TranscationID.ToString());
        }


        public IEnumerable<Book> GetBooksForIssue()
        {
            try
            {
                string commandText = ProjectConstants.BTGetBooksForIssue;

                List<Dictionary<string, string>> booktranscations = database.Query(commandText, null);
                List<Book> output = new List<Book>();
                foreach (var book in booktranscations)
                {
                    Book currentBook = new Book();
                    currentBook.Author = book[ProjectConstants.KeyBookAuthor];
                    currentBook.BookID = Convert.ToInt32(book[ProjectConstants.KeyBookID]);
                    currentBook.Count = Convert.ToInt32(book[ProjectConstants.KeyBookNoOfBooks]);
                    currentBook.Name = book[ProjectConstants.KeyBookName];
                    currentBook.Status = book[ProjectConstants.KeyBookStatus];
                    output.Add(currentBook);
                }
                return output;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public BookTranscation GetBookTransactionById(string transasctionId)
        {
            try
            {
                string commandText = ProjectConstants.BTGetBookById;
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(ProjectConstants.transactionId, transasctionId);

                var book = database.Query(commandText, parameters).FirstOrDefault();
                if (book == null)
                    return null;

                BookTranscation currentBook = new BookTranscation();
                currentBook.TranscationID = Convert.ToInt32(book[ProjectConstants.KeyTransactionID]);
                currentBook.BookID = Convert.ToInt32(book["Book_ID"]);
                currentBook.BookStatus = book["BookStatus"];
                currentBook.MemberID = Convert.ToInt32(book["Member_ID"]);
                currentBook.DueDate = DateTime.Parse( book["Due_Date"]);
                currentBook.DateofIssue =DateTime.Parse( book["Date_of_issue"]);
 
                return currentBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<BookTranscation> GetBookTransactionsByBookId(int bookId, bool onlyIssuedAndRenewed = true)
        {
            try
            {
                string commandText = ProjectConstants.BTGetBookByBookId;
                if (onlyIssuedAndRenewed)
                {
                    commandText += " and BookStatus != '" + BookTransactionStatus.Returned + "'";
                }
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@bookId", bookId);

                var transasction = database.Query(commandText, parameters);
                if (transasction == null)
                    return null;
                List<BookTranscation> result = new List<BookTranscation>();
                foreach (var book in transasction)
                {
                    BookTranscation currentBook = new BookTranscation();
                    currentBook.TranscationID = Convert.ToInt32(book["Transcation_ID"]);
                    currentBook.BookID = Convert.ToInt32(book["Book_ID"]);
                    currentBook.BookStatus = book["BookStatus"];
                    currentBook.MemberID = Convert.ToInt32(book["Member_ID"]);
                    currentBook.DueDate = DateTime.Parse(book["Due_Date"]);
                    currentBook.DateofIssue = DateTime.Parse(book["Date_of_issue"]);
                    result.Add(currentBook);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetBookTransactionCountByBookId(int bookId, bool onlyIssuedAndRenewed = true)
        {
            try
            {
                string commandText = ProjectConstants.BTGetBTCountByBookId;
                if(onlyIssuedAndRenewed)
                {
                    commandText += " and BookStatus != '" + BookTransactionStatus.Returned+"'";
                }
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@bookId", bookId);

                var book = database.Query(commandText, parameters);

                return book != null ? book.Count : 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int RenewBook(BookTranscation booktranscation)
        {
            string commandText = ProjectConstants.BTRenewBook;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@duedate", booktranscation.DueDate);
            parameters.Add("@BookStatus", booktranscation.BookStatus);
            parameters.Add("@transcationid", booktranscation.TranscationID);



            return database.Execute(commandText, parameters);
        }

    }
}