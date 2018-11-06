using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using log4net;
using log4net.Config;

namespace Dashboard_LibraryManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            XmlConfigurator.Configure(new System.IO.FileInfo("~/Web.Config"));
            Startup.UpdateLogFilePath();
        }


        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                if (FormsAuthentication.CookiesSupported == false)
                    return;

                if(Request.Cookies[FormsAuthentication.FormsCookieName]==null)
                {
                    return;
                }


                try
                {
                    string userName = FormsAuthentication.Decrypt(Request.Cookies.Get(FormsAuthentication.FormsCookieName).Value).Name;

                    HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(userName, "form"), new string[] { });
                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        protected void Application_Error(Object sender, EventArgs e)
        {
            ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Exception exception = Server.GetLastError();
            Response.Clear();
            log.Error(exception.Message, exception);
            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "General";
                        break;
                }

                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
                return;
            }

            if(exception is DatabaseException)
            {
                Response.Redirect(String.Format("~/Error/{0}/?message={1}", "DatabaseError", exception.Message));
                return;
            }

            Response.Redirect("~/Error/General");
        }

    }
}