using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
    }
}
