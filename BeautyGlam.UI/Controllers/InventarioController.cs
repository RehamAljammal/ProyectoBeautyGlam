using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class InventarioController : Controller
    {
        // LISTADO SIMPLE
        public ActionResult Index()
        {
            return View();
        }

        // LISTADO AVANZADO
        public ActionResult Avanzado()
        {
            return View();
        }

        // EDITAR STOCK
        public ActionResult Editar(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // DEFINIR MÍNIMOS / MÁXIMOS
        public ActionResult Minimos(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // MOVIMIENTOS DE INVENTARIO
        public ActionResult Movimientos(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
