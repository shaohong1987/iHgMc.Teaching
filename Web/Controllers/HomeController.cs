using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}