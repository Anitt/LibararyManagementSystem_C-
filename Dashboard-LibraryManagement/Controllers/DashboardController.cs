using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard_LibraryManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDatabase db;
        public DashboardController() : this(new MySQLDatabase())
        {
        }
        public DashboardController(IDatabase database)
        {
            db = database;

        }
        // GET: Dashboard
        public ActionResult Index()
        {
            DashBoardViewModel viewModel = new DashBoardViewModel();
            try
            {
                DashboardTable table = new DashboardTable(db);
				UserTable userTable = new UserTable(db);

				UserAccount currentUser = userTable.GetUsers().Where(x => x.GetUserName() == User.Identity.Name).FirstOrDefault();
				if(currentUser!=null)
				{
					ViewBag.IsAdmin = currentUser.Isadmin;
				}


                viewModel.booksDueToday = table.GetBooksDueToday();
                viewModel.booksIssued = table.GetBooksIssued();
                viewModel.booksExpired = table.GetBooksExpired();
				
                viewModel.countDuetoday = viewModel?.booksDueToday != null ? viewModel.booksDueToday.Count() : 0;
                viewModel.countexpired = viewModel?.booksExpired != null ? viewModel.booksExpired.Count() : 0;
                viewModel.countIssued = viewModel?.booksIssued != null ? viewModel.booksIssued.Count() : 0;

                return View(viewModel);
            }
            catch (Exception)
            {

                throw;
            }

           
        }
    }
}