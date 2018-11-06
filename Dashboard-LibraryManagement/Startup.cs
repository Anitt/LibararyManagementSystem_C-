using Microsoft.Owin;
using Owin;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

[assembly: OwinStartupAttribute(typeof(Dashboard_LibraryManagement.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace Dashboard_LibraryManagement
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


        public static void UpdateLogFilePath()
        {
            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
            for(int counter = 0; counter < hierarchy.Root.Appenders.Count; counter++)
            {
                if(hierarchy.Root.Appenders[counter] is RollingFileAppender)
                {
                    RollingFileAppender rollAppender = hierarchy.Root.Appenders[counter] as RollingFileAppender;
                    string filepath = System.Web.Configuration.WebConfigurationManager.AppSettings["LogFilePath"];

                        rollAppender.File = filepath;
                        rollAppender.ActivateOptions();
                        break;
                   
                }
            }
        }



    }
}