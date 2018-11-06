using System.Collections.Generic;
using System.Web.Mvc;
using Dashboard_LibraryManagement.Models;
using System.Linq;
using System;
using Dashboard_LibraryManagement.Validation;
using System.Web.Security;
using Dashboard_LibraryManagement.DataAccessLayer;
using Dashboard_LibraryManagement.PasswordValidate;
using log4net;

namespace Dashboard_LibraryManagement.Controllers
{
   
    public class AccountController : Controller
    {
        
        private readonly IDatabase db;
		private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public AccountController():this(new MySQLDatabase())
        {
        }
        public AccountController(IDatabase database)
        {
            db=database;

        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel user,string ReturnUrl)
        {
			log.Info("Login in functionality of the application.");
			try
            {
                if (ModelState.IsValid)
                {

					//validation using Abstract design pattern
					AbstractFactory abstractfactory = FactoryProducer.GetFactory("IUserValidation");
					IUserValidation userValidation = abstractfactory.getuservalidation("UserValidation");
					//UserValidation userValidation = new UserValidation();
                    // validating user credentials
                    UserAccount userAccount = null;
                    if (userValidation.ValidateUser(user?.Email, user?.Password, out userAccount))
                    {

                        FormsAuthentication.SetAuthCookie(userAccount.GetUserName(), user.RememberMe);

                        if(ReturnUrl!=null && !string.IsNullOrWhiteSpace(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction(ProjectConstants.Index,ProjectConstants.Dashboard,null);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,ProjectConstants.InvalidLoginMsg);
						log.Info("Login failed for the application.");
					}
                }
            }

            catch (Exception)
            {
                throw;
            }
            return View();
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction(ProjectConstants.Index, ProjectConstants.Home);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                UserTable userTable = new UserTable(db);
                PasswordCheck passwordcheck = new PasswordCheck();
                RegistrationValidation registrationvalidation = new RegistrationValidation();
                if (registrationvalidation.ValidateRegistration(account))
                {
                    if (passwordcheck.CheckPassword(account.Password))
                    {
                        userTable.Insert(account);
                        ViewBag.Message = account.Firstname + " " + account.Lastname + ProjectConstants.RegisterSuccessMsg;
                    }
                    else {

                        ViewBag.Message = ProjectConstants.PasswordValidateFailMsg;

                    }
                }
                else {

                    ViewBag.Message = ProjectConstants.RegisterFailMsg;

                }
               
                ModelState.Clear();
               

            }
            
            return View(ProjectConstants.Register);
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(UserAccount user)
        {
            return View();
        }


        public ActionResult ListUser()
        {

            try
            {
                UserTable usertable = new UserTable(db);
                IEnumerable<UserAccount> userModel = usertable.GetUsers();
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
                    userModel = userModel.Where(user => user.Firstname.Contains(searchValue));
                }

                return View(userModel);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Edit(string id)
        {
            // Get the Specific user by Id
            UserTable usertable = new UserTable(db);
            UserAccount edituser = usertable.GetUsersById(id);

            return View(edituser);
        }

        [HttpPost]
        public ActionResult Edituser(UserAccount useraccount)
        {
            // Get the Specific Book by Id
            UserTable usertable = new UserTable(db);
            usertable.Update(useraccount);

            return RedirectToActionPermanent(ProjectConstants.ListUser);
        }


        public ActionResult DeleteUser(string id)
        {
            // Get the Specific Book by Id
            UserTable usertable = new UserTable(db);
            var deleteCount = usertable.DeleteById(id);

            return RedirectToActionPermanent(ProjectConstants.ListUser);
        }
    }
}