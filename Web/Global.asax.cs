using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Text;

namespace Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Web.config")));
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            #region 捕获全局异常

            Exception error = Server.GetLastError().GetBaseException();
            Exception ex = Server.GetLastError().GetBaseException();
            string ip = Request.ServerVariables.Get("HTTP_X_FORWARDED_FOR") == null ?
            Request.ServerVariables.Get("Remote_Addr").ToString().Trim() :
            Request.ServerVariables.Get("HTTP_X_FORWARDED_FOR").ToString().Trim();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("========== {0} Application_Error BEGIN ==========", DateTime.Now));
            builder.AppendLine("Ip:" + ip);
            builder.AppendLine("浏览器:" + Request.Browser.Browser.ToString());
            builder.AppendLine("浏览器版本:" + Request.Browser.MajorVersion.ToString());
            builder.AppendLine("操作系统:" + Request.Browser.Platform.ToString());
            builder.AppendLine("页面：" + Request.Url.ToString());
            builder.AppendLine("错误信息：" + ex.Message);
            builder.AppendLine("错误源：" + ex.Source);
            builder.AppendLine("异常方法：" + ex.TargetSite);
            builder.AppendLine("堆栈信息：" + ex.StackTrace);
            builder.AppendLine("========== Application_Error END ===================");
            var logger = log4net.LogManager.GetLogger("Error");
            lock (logger)
            {
                logger.Error(builder.ToString());
            }
            Server.ClearError();
            Response.Redirect("/Error");//跳出至404页面
            #endregion
        }
    }
}