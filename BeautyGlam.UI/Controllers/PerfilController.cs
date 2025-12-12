using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class PerfilController : Controller
    {
        // Ver información del usuario
        public ActionResult Index()
        {
            return View();
        }

        // Editar perfil
        public ActionResult Edit()
        {
            return View();
        }

        // Rutinas guardadas
        public ActionResult Rutinas()
        {
            return View();
        }

        // Recomendaciones personalizadas
        public ActionResult Recomendaciones()
        {
            return View();
        }

        // Historial
        public ActionResult Historial()
        {
            return View();
        }

        // Seguimiento (progreso de piel, hábitos, compras)
        public ActionResult Seguimiento()
        {
            return View();
        }

        public ActionResult DetallePedido(int id)
        {
            ViewBag.IdPedido = id;
            return View();
        }
    }
}
