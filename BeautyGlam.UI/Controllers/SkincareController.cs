using BeautyGlam.Abstracciones.LogicaDeNegocio.AsistenteSkincare;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.AsistenteSkincare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class SkincareController : Controller
    {
        private readonly IGenerarRutinaLN _rutinaLN;

        public SkincareController()
        {
            _rutinaLN = new GenerarRutinaLN();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cuestionario()
        {
            return View(new RespuestasSkincareDTO());
        }

        [HttpPost]
        public ActionResult GenerarRutina(RespuestasSkincareDTO respuestas)
        {
            if (string.IsNullOrEmpty(respuestas.tipoPiel))
            {
                ModelState.AddModelError("", "Debe seleccionar tipo de piel");
                return View("Cuestionario", respuestas);
            }

            if (respuestas.problema == null || !respuestas.problema.Any())
            {
                ModelState.AddModelError("", "Selecciona al menos una preocupación");
                return View("Cuestionario", respuestas);
            }

            var rutina = _rutinaLN.Generar(respuestas);

            Session["Respuestas"] = respuestas;

            return View("Rutina", rutina);
        }

        public ActionResult PasoAPaso()
        {
            return View();
        }

        public ActionResult Repeticion()
        {
            Session.Clear();
            TempData.Clear();

            return RedirectToAction("Cuestionario");
        }
    }
}