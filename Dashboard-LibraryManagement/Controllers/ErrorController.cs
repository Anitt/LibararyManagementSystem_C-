﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard_LibraryManagement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HttpError404() {

            return View();
        }

        public ActionResult HttpError500()
        {

            return View();
        }


        public ActionResult General()
        {

            return View();
        }

        public ActionResult DatabaseError()
        {
            return View();
        }
    }
}
