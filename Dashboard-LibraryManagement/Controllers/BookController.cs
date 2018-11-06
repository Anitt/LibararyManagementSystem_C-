using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Dashboard_LibraryManagement.Validation;
using log4net;


namespace Dashboard_LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IDatabase db;
        public BookController() : this(new MySQLDatabase())
        {
        }
        public BookController(IDatabase database)
        {
            db = database;

        }

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Book
        public ActionResult Index()
        {
            log.Info("calling the index method of book controller");
            return View();

        }


        public ActionResult AddBook()
        {
            log.Info("Adding a Book to the application");
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book newbook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // BookValidation bookValidation = new BookValidation();
					// validating whether the book already exists or not
					// Abstract Factory pattern
					AbstractFactory abstractfactory = FactoryProducer.GetFactory("IBookValidation");
					IBookValidation bookValidation = abstractfactory.getbookvalidation("BookValidation");
					
                    if (bookValidation.ValidateBook(newbook))
                    {
                        int id = newbook.BookID;
                        BookTable booktable = new BookTable(db);
                        newbook.Status = BookStatus.Available.ToString();
                        booktable.Insert(newbook);
                        ModelState.Clear();
                        ViewBag.Message = newbook.Name + ProjectConstants.SuccessMsg;
                    }
                    else {

                        ViewBag.Message =  ProjectConstants.AddBookFailMsg;
                        return View(ProjectConstants.AddBook);

                    }
                        return View(ProjectConstants.AddBook);


                }

            }

            catch (Exception)
            {
                log.Error("Error while adding book to the database");
                throw;
            }
            return View(ProjectConstants.AddBook);

        }
        public ActionResult IssueBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IssueBook(BookTranscation booktranscation)
        {
            if (ModelState.IsValid)
            {

                BookTranscationTable bookTranscation = new BookTranscationTable(db);
                bookTranscation.Insert(booktranscation);

            }
            return View(ProjectConstants.IssueBook);
        }


        public ActionResult ListBook()
        {

            try
            {
                BookTable bookTable = new BookTable(db);
                IEnumerable<Book> booksModel = bookTable.GetBooks();
                string searchValue = Request.Form[ProjectConstants.SearchValue];

                //IF it is a clear action, empty the search textbox
                if (Request.Form[ProjectConstants.Action] != null && Request.Form[ProjectConstants.Action] == ProjectConstants.Clear)
                {
                    searchValue = null;
                }

                //Check for filter
                if (searchValue != null)
                {

                    ViewBag.SearchValue = searchValue;
                    booksModel = booksModel.Where(book => book.Name.Contains(searchValue));
                }

                return View(booksModel);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Edit(string id)
        {
            // Get the Specific Book by Id
            BookTable bookTable = new BookTable(db);
            Book editBook = bookTable.GetBookById(id);

            return View(editBook);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            // Get the Specific Book by Id
            BookTable bookTable = new BookTable(db);
            bookTable.Update(book);

            return RedirectToActionPermanent(ProjectConstants.ListBook);
        }


        public ActionResult DeleteBook(string id)
        {
            // Get the Specific Book by Id
            BookTable bookTable = new BookTable(db);
            var deleteCount = bookTable.DeleteById(id);

            return RedirectToActionPermanent(ProjectConstants.ListBook);
        }


        public ActionResult ListBooktranscation()
        {

            try
            {
                BookTable bookTable = new BookTable(db);
                IEnumerable<Book> booksModel = bookTable.GetBooks();
                string searchValue = Request.Form[ProjectConstants.SearchValue];

                //IF it is a clear action, empty the search textbox
                if (Request.Form[ProjectConstants.Action] != null && Request.Form[ProjectConstants.Action] == ProjectConstants.Clear)
                {
                    searchValue = null;
                }

                //Check for filter
                if (searchValue != null)
                {

                    ViewBag.SearchValue = searchValue;
                    booksModel = booksModel.Where(book => book.Name.Contains(searchValue));
                }

                return View(booksModel);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Issue(string id)
       {
      
            // Read the Due Date day from
            int dueDateDays = Convert.ToInt32(WebConfigurationManager.AppSettings[ProjectConstants.BookDueDateDays]);

            BookTable bookTable = new BookTable(db);
            Book book = bookTable.GetBookById(id);

            BookTransactionViewModel newTransaction = new BookTransactionViewModel()
            {
                Name = book.Name,
                Author = book.Author,
                BookStatus = BookTransactionStatus.Issued.ToString(),
                BookID = book.BookID,
                DateofIssue = DateTime.Now,
                DueDate = DateTime.Now.AddDays(Convert.ToDouble(WebConfigurationManager.AppSettings[ProjectConstants.BookDueDateDays]))
            };

            // Get the Count of existing book transactions
            ViewBag.Remaining = book.Count -  (new BookTranscationTable(db)).GetBookTransactionCountByBookId(book.BookID, true);
            
            return View(newTransaction);
        }

        [HttpPost]
        public ActionResult Issue(BookTransactionViewModel transactionViewModel)
        {
            try
            {
                if(transactionViewModel == null)
                {
                    throw new ArgumentException(ProjectConstants.InvalidTransactionMsg);
                }

                MemberTable memberTable = new MemberTable(db);
                LibMember member =  memberTable.GetMemberById(Convert.ToString(transactionViewModel.MemberID));
                if(member==null)
                {
                    ModelState.AddModelError(string.Empty, ProjectConstants.MemberIdNotExistMsg);
                    return View(transactionViewModel);
                }

                BookTable bookTable = new BookTable(db);
                Book book = bookTable.GetBookById(Convert.ToString(transactionViewModel.BookID));
               
                BookTranscationTable bookTranscationTable = new BookTranscationTable(db);
                BookTranscation bookTranscation = new BookTranscation()
                {
                    BookID = transactionViewModel.BookID,BookStatus = transactionViewModel.BookStatus,MemberID =transactionViewModel.MemberID,
                    DateofIssue = transactionViewModel.DateofIssue, DueDate = transactionViewModel.DueDate
                };
                bookTranscationTable.Insert(bookTranscation);

                int existingBookTransactionCount = bookTranscationTable.GetBookTransactionCountByBookId(bookTranscation.BookID);

                if(existingBookTransactionCount>=book.Count)
                {
                    // update the book status as Not Available
                    book.Status = BookStatus.NotAvailable.ToString();
                    bookTable.Update(book);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(ProjectConstants.ListBookTranscation);
        }


        public ActionResult RenewBook(string id)
        {
            BookTranscationTable bookTranscationTable = new BookTranscationTable(db);
            IEnumerable<BookTranscation> edittranscations = bookTranscationTable.GetBookTransactionsByBookId(Convert.ToInt32(id), true);
            return View(edittranscations);
        }

		public ActionResult ReturnBook(string id)
		{
			BookTranscationTable bookTranscationTable = new BookTranscationTable(db);
			IEnumerable<BookTranscation> edittranscations = bookTranscationTable.GetBookTransactionsByBookId(Convert.ToInt32(id), true);
			return View(edittranscations);
		}

		public ActionResult RenewTransaction(string id)
        {
            string bookId = string.Empty;
            try
            {
                BookTranscationTable bookTransactionTable = new BookTranscationTable(db);


                BookTranscation currentTransaction = bookTransactionTable.GetBookTransactionById(id);

                if(currentTransaction!=null)
                {
                    currentTransaction.DueDate = currentTransaction.DueDate.AddDays(Convert.ToDouble( WebConfigurationManager.AppSettings[ProjectConstants.BookDueDateDays]));
                    currentTransaction.BookStatus = BookTransactionStatus.Renewed.ToString();
                    bookTransactionTable.RenewBook(currentTransaction);
                    bookId = Convert.ToString(currentTransaction.BookID);
                }
                else
                {
                    return RedirectToAction(ProjectConstants.ListBookTranscation);
                }


            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(ProjectConstants.RenewBook, new { @id = bookId });
        }


		public ActionResult ReturnTransaction(string id)
		{
			string bookId = string.Empty;
			try
			{
				BookTranscationTable bookTransactionTable = new BookTranscationTable(db);


				BookTranscation currentTransaction = bookTransactionTable.GetBookTransactionById(id);

				if (currentTransaction != null)
				{
					currentTransaction.BookStatus = BookTransactionStatus.Returned.ToString();
					bookTransactionTable.RenewBook(currentTransaction);
					bookId = Convert.ToString(currentTransaction.BookID);
				}
				else
				{
					return RedirectToAction(ProjectConstants.ListBookTranscation);
				}


			}
			catch (Exception)
			{

				throw;
			}
			return RedirectToAction(ProjectConstants.ReturnBook, new { @id = bookId });
		}

		

	}


}
