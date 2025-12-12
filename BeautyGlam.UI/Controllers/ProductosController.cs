using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class ProductosController : Controller
    {
        // LISTA
        public ActionResult Index()
        {
            return View();
        }

        // CREAR
        public ActionResult Crear()
        {
            return View();
        }

        // EDITAR (id opcional)
        public ActionResult Editar(int? id)
        {
            return View();
        }

        // DETALLE (id opcional)
        public ActionResult Detalle(int? id)
        {
            return View();
        }

        // ELIMINAR (id opcional)
        public ActionResult Eliminar(int? id)
        {
            return View();
        }
    }
}
