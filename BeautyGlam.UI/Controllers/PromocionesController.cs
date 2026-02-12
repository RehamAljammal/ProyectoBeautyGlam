using BeautyGlam.Abstracciones.AccesoADatos.Promocion.ListaDePromocion;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EditarPromociones;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EliminarPromociones;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.RegistrarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.ObtenerPromocionPorId;
using BeautyGlam.LogicaDeNegocio.Promociones.EditarPromociones;
using BeautyGlam.LogicaDeNegocio.Promociones.EliminarPromociones;
using BeautyGlam.LogicaDeNegocio.Promociones.ListaPromociones;
using BeautyGlam.LogicaDeNegocio.Promociones.RegistrarPromociones;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly IObtenerListaDePromocionesAD _obtenerLaListaDePromocionesLN;
        private readonly IRegistrarPromocionesLN _agregarPromocionesLN;
        private readonly IEditarpromocionesLN _editarPromocionesLN;
        private readonly IEliminarPromocionesLN _eliminarPromocionesLN;

        public PromocionesController()
        {
            _obtenerLaListaDePromocionesLN = new ObtenerLaListaDePromocionesLN();
            _agregarPromocionesLN = new RegistrarPromocionesLN();
            _editarPromocionesLN = new EditarPromocionesLN();
            _eliminarPromocionesLN = new EliminarPromocionesLN();
        }

        // GET: Promociones
        public ActionResult ListaDePromociones()
        {
            List<PromocionesDTO> laListaDePromociones =
                _obtenerLaListaDePromocionesLN.Obtener();

            return View(laListaDePromociones);
        }

        // GET: Promociones/Details/5

        // GET: Promociones/Create
        public ActionResult CrearPromociones()
        {
            return View();
        }

        // POST: Promociones/Create
        [HttpPost]
        public async Task<ActionResult> CrearPromociones(PromocionesDTO laPromocionParaGuardar)
        {
            try
            {
                int cantidadDeFilasAfectadas =
                    await _agregarPromocionesLN.Registrar(laPromocionParaGuardar);

                return RedirectToAction("ListaDePromociones");
            }
            catch
            {
                return View();
            }
        }

        // GET: Promociones/EditarPromociones/5
        public ActionResult EditarPromociones(int id)
        {
            ObtenerPromocionPorIdAD obtenerPromocionesPorIdAD =
                new ObtenerPromocionPorIdAD();

            PromocionesDTO promocion =
                obtenerPromocionesPorIdAD.ObtenerPorId(id);

            if (promocion == null)
            {
                return RedirectToAction("ListaDePromociones");
            }

            return View(promocion);
        }

        // POST: Promociones/EditarPromociones
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarPromociones(PromocionesDTO laPromocionParaGuardar)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(laPromocionParaGuardar);

                PromocionesDTO promocionActual =
                    await _editarPromocionesLN.ObtenerPorId(laPromocionParaGuardar.id_Promocion);

                if (promocionActual == null)
                {
                    ModelState.AddModelError("", "No existe la promoción.");
                    return View(laPromocionParaGuardar);
                }

                promocionActual.titulo = laPromocionParaGuardar.titulo;
                promocionActual.descripcion = laPromocionParaGuardar.descripcion;
                promocionActual.fecha_Inicio = laPromocionParaGuardar.fecha_Inicio;
                promocionActual.fecha_Fin = laPromocionParaGuardar.fecha_Fin;
                promocionActual.estado = laPromocionParaGuardar.estado;

                await _editarPromocionesLN.Editar(promocionActual);

                return RedirectToAction("ListaDePromociones");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar: " + ex.Message);
                return View(laPromocionParaGuardar);
            }
        }

        // GET: Promociones/EliminarPromociones/5
        public ActionResult EliminarPromociones(int id)
        {
            ObtenerPromocionPorIdAD obtenerPromocionesPorIdAD =
                new ObtenerPromocionPorIdAD();

            PromocionesDTO promocion =
                obtenerPromocionesPorIdAD.ObtenerPorId(id);

            if (promocion == null)
            {
                return RedirectToAction("ListaDePromociones");
            }

            return View(promocion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarPromociones(PromocionesDTO laPromocionParaGuardar)
        {
            try
            {
                await _eliminarPromocionesLN.Eliminar(laPromocionParaGuardar);

                return RedirectToAction("ListaDePromociones");
            }
            catch
            {
                return View(laPromocionParaGuardar);
            }
        }
    }
}
