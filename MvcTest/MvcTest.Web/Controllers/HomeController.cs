using System.Web.Mvc;

namespace MvcTest.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "People");
        }
    }
}