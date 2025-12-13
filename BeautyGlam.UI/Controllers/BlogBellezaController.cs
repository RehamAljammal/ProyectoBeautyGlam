using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class BlogBellezaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Publicar()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Detalle(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
