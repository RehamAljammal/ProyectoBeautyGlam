using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class CatalogoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VistaProducto(int id)
        {
            return View();
        }
    }
}
