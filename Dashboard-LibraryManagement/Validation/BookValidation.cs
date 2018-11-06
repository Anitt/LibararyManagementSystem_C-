using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_LibraryManagement.Validation
{
    public class BookValidation : IBookValidation
    {
        public Boolean ValidateBook(Book newbook) {

            try
            { 
                
              BookTable bookTable = new BookTable(new MySQLDatabase());
              IEnumerable<Book> ListofBooks = bookTable.GetBooks();
                //  validate and check whether the Book is already existing
                foreach (var book in ListofBooks) {

                    if (newbook.Name == book.Name && newbook.Author == book.Author) {

                        return false;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
           
            try
            {
                // to check whether Status is null or empty
                if (String.IsNullOrEmpty(newbook.Status))
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                // to check whether a rack no is greater then zero and not negative

                if (newbook.Rackno <= 0) {

                    return false ;
                }
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                // No of books should atleast be 1
                if (newbook.Count <= 0) {

                    return false;

               }
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        
            
    }


}