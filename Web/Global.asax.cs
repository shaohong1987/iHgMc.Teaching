using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using log4net;
using Web.Helper;

namespace Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            #region 日志
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (HgMc.LogQueue.Count > 0)
                    {
                        var log = HgMc.LogQueue.Dequeue();
                        if (log != null)
                        {
                            var logger = LogManager.GetLogger(log.TypeName);
                            logger.Error(log.Content);
                        }
                        else
                        {
                            Thread.Sleep(HgMc.LogHandInterval);
                        }
                    }
                    else
                    {
                        Thread.Sleep(HgMc.LogHandInterval);
                    }
                }
            });
            #endregion
        }
    }
}