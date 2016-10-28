using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using log4net.Config;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string configFilePath = this.Server.MapPath(@"~/App_Data/System/Log4Net.xml");//注册Log4Net
            XmlConfigurator.Configure(new FileInfo(configFilePath));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception baseException = this.Server.GetLastError().GetBaseException();

            //写入日志
            ILog log = LogManager.GetLogger(typeof(MvcApplication));
            LogHelper.LogException(log, baseException);
        }
    }
}
