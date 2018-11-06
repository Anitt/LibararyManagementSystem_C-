using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.Models;
using Dashboard_LibraryManagement.Validation;

namespace Dashboard_LibraryManagement.Controllers
{
    public class MemberController : Controller
    {
        private readonly IDatabase db;
        public MemberController() : this(new MySQLDatabase())
        {
        }
        public MemberController(IDatabase database)
        {
            db = database;

        }
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(LibMember newmember)
        {   
            if (ModelState.IsValid)
            {
                //MemberValidation membervalidation = new MemberValidation();
				AbstractFactory abstractfactory = FactoryProducer.GetFactory("IMemberValidation");
				IMemberValidation membervalidation = abstractfactory.getmembervalidation("MemberValidation");
				if (membervalidation.ValidateMember(newmember))
                {

                    MemberTable memberTable = new MemberTable(db);
                    memberTable.Insert(newmember);
                    ModelState.Clear();

                    ViewBag.Message = newmember.Firstname + ProjectConstants.SuccessMsg;

                }
                else {

                    ViewBag.Message1 = ProjectConstants.MemberExistingMsg;

                }
                
            }
            return View(ProjectConstants.AddMember);
        }

        public ActionResult Edit(string id)
        {
            // Get the Specific Book by Id
            MemberTable memberTable = new MemberTable(db);
            LibMember EditMember = memberTable.GetMemberById(id);

            return View(EditMember);
        }

        [HttpPost]
        public ActionResult EditMember(LibMember member)
        {
            // Get the Specific Book by Id
            MemberTable memberTable = new MemberTable(db);
            memberTable.Update(member);

            return RedirectToActionPermanent(ProjectConstants.ListMember);
        }

        public ActionResult DeleteMember(string id)
        {
            // Get the Specific Book by Id
            MemberTable membertable = new MemberTable(db);
            var deleteCount = membertable.DeleteById(id);

            return RedirectToActionPermanent(ProjectConstants.ListMember);
        }

        public ActionResult ListMember()
        {

            try
            {
                MemberTable membertable = new MemberTable(db);
                IEnumerable<LibMember> membermodel = membertable.GetMembers();
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
                    membermodel = membermodel.Where(member => member.Firstname.Contains(searchValue));
                }

                return View(membermodel);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}