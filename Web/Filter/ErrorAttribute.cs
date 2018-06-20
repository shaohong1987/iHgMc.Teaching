using System.Web.Mvc;
using Web.Helper;
using Web.Models;

namespace Web.Filter
{
    public class ErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            HgMc.LogQueue.Enqueue(new LogModel()
            {
                TypeName = "Error",
                Content = filterContext.Exception.ToString()
            });
            base.OnException(filterContext);
        }
    }
}