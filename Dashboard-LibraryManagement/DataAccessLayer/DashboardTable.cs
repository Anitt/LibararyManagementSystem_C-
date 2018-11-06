using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.DataAccessLayer
{
    public class DashboardTable
    {

        private IDatabase database;
        public DashboardTable() : this(new MySQLDatabase())
        {
        }

        /// Constructor that takes a MySQLDatabase instance 
        public DashboardTable(IDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<BookTranscation> GetActiveBookTranscation()
        {
            try
            {
                string commandText = ProjectConstants.DashboardGetActiveBookTransaction+BookTransactionStatus.Returned+"'";

                List<Dictionary<string, string>> books = database.Query(commandText, null);
                List<BookTranscation> result = new List<BookTranscation>();
                foreach (var book in books)
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


        public IEnumerable<BookTranscation> GetBooksIssued()
        {
            try
            {
                var allBookTransaction = GetActiveBookTranscation();
                return allBookTransaction.Where(x => x.BookStatus == BookTransactionStatus.Issued.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BookTranscation> GetBooksExpired()
        {
            try
            {
                var allBookTransaction = GetActiveBookTranscation();
                return allBookTransaction.Where(x => DateTime.Now.Date > x.DueDate.Date);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BookTranscation> GetBooksDueToday()
        {
            try
            {
                var allBookTransaction = GetActiveBookTranscation();
                return allBookTransaction.Where(x => DateTime.Equals(x.DueDate.Date,DateTime.Now.Date));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCountBooksIssued() {

            try
            {
                string commandText = ProjectConstants.DashboardGetCountBooksIssued;
                List<Dictionary<string, string>> books = database.Query(commandText, null);

                return books!=null ? books.Count:0;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public int GetCountBooksDue()
        {

            try
            {
                string commandText = ProjectConstants.DashboardGetCountBooksDue;
                List<Dictionary<string, string>> books = database.Query(commandText, null);
                return books != null ? books.Count : 0;

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}