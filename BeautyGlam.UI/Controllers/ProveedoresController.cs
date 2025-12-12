using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
        public class ProveedoresController : Controller
        {
            // Listar proveedores
            public ActionResult Index()
            {
                return View();
            }

            // Ver detalles del proveedor
            public ActionResult Detalles(int id = 0)
            {
                return View();
            }

            // Crear proveedor
            public ActionResult Crear()
            {
                return View();
            }

            // Editar proveedor
            public ActionResult Editar(int id = 0)
            {
                return View();
            }
        }
    }

