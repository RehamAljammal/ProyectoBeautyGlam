using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Historial_Compras.Detalle;
using BeautyGlam.LogicaDeNegocio.Historial_Compras.Lista_de_Historial;
using BeautyGlam.LogicaDeNegocio.Historial_Compras.Reclamo;
using BeautyGlam.LogicaDeNegocio.Historial_Compras.Valoracion;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [Authorize]
    public class HistorialComprasController : Controller
    {
        private readonly ObtenerHistorialComprasLN _historialLN;
        private readonly ObtenerDetalleCompraLN _detalleLN;
        private readonly RegistrarValoracionLN _valoracionLN;
        private readonly RegistrarReclamoLN _reclamoLN;

        public HistorialComprasController()
        {
            _historialLN = new ObtenerHistorialComprasLN();
            _detalleLN = new ObtenerDetalleCompraLN();
            _valoracionLN = new RegistrarValoracionLN();
            _reclamoLN = new RegistrarReclamoLN();
        }

        // ==================================
        // 📄 HISTORIAL DE COMPRAS
        // ==================================
        public async Task<ActionResult> Index()
        {
            if (Session["IdUsuario"] == null)
                return RedirectToAction("Login", "Auth");

            int idUsuario = (int)Session["IdUsuario"];

            var lista = await _historialLN.Obtener(idUsuario);

            return View(lista);
        }

        // ==================================
        // 📦 DETALLE DE COMPRA
        // ==================================
        public async Task<ActionResult> Detalle(int idVenta)
        {
            var detalle = await _detalleLN.Obtener(idVenta);
            if (!detalle.Any())
            {
                throw new Exception("NO HAY DATOS");
            }

            return View(detalle);
        }

        // ==================================
        // ⭐ VALORAR PRODUCTO
        // ==================================
        [HttpPost]
        public async Task<ActionResult> Valorar(ValoracionDto model)
        {
            if (Session["IdUsuario"] == null)
                return RedirectToAction("Login", "Auth");

            model.idUsuario = (int)Session["IdUsuario"];

            int resultado = await _valoracionLN.Registrar(model);

            if (resultado == 0)
            {
                TempData["Error"] = "Ya valoraste este producto.";
            }
            else
            {
                TempData["Msg"] = "Valoración registrada correctamente.";
            }

            return RedirectToAction("Detalle", new { idVenta = model.idVenta });
        }

        // ==================================
        // ⚠ RECLAMO
        // ==================================
        [HttpPost]
        public async Task<ActionResult> Reclamar(ReclamoDto model)
        {
            int resultado = await _reclamoLN.Registrar(model);

            if (resultado == 1)
            {
                TempData["Msg"] = "Reclamo enviado correctamente.";
            }
            else
            {
                TempData["Error"] = "No se pudo enviar el reclamo.";
            }

            return RedirectToAction("Detalle", new { idVenta = model.idVenta });
        }
    }
}