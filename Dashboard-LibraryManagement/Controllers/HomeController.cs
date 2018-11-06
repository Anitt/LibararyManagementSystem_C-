using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Dashboard_LibraryManagement.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            log.Info("Index Method action called.");

            return View();
        }

        public ActionResult About()
        {
            log.Info("About Method action called.");
            ViewBag.Message = ProjectConstants.AppDescriptionPage;

            return View();
        }

        public ActionResult Contact()
        {
            log.Info("Contact Method action called.");
            ViewBag.Message = ProjectConstants.ContactPage;

            return View();
        }
    }
}