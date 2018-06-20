using System.Web.Mvc;
using Web.Filter;

namespace Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorAttribute());
        }
    }
}