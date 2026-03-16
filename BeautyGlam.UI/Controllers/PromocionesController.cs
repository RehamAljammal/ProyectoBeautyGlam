using BeautyGlam.Abstracciones.AccesoADatos.Promocion.ListaDePromocion;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EditarPromociones;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EliminarPromociones;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.RegistrarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.ObtenerPromocionPorId;
using BeautyGlam.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.LogicaDeNegocio.Promociones.EditarPromociones;
using BeautyGlam.LogicaDeNegocio.Promociones.EliminarPromociones;
using BeautyGlam.LogicaDeNegocio.Promociones.ListaPromociones;
using BeautyGlam.LogicaDeNegocio.Promociones.RegistrarPromociones;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // -----------------------------
        // LISTADO PROMOCIONES (ADMIN)
        // -----------------------------
        public ActionResult ListaDePromociones(string buscar, int pagina = 1)
        {
            int registrosPorPagina = 10;

            List<PromocionesDTO> lista =
                _obtenerLaListaDePromocionesLN.Obtener();

            // BUSCADOR
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                buscar = buscar.ToLower().Trim();
                pagina = 1; 

                lista = lista.Where(p =>
                    (p.titulo ?? "").ToLower().Contains(buscar)
                ).ToList();
            }

            // ORDENAR POR MÁS NUEVO
            lista = lista.OrderByDescending(x => x.estado)
                .OrderByDescending(x => x.id_Promocion).ToList();

            int totalRegistros = lista.Count();

            var promocionesPaginadas = lista
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);
            ViewBag.Buscar = buscar;

            return View(promocionesPaginadas);
        }

        // -----------------------------
        // CREAR PROMOCIÓN
        // -----------------------------
        public ActionResult CrearPromociones()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CrearPromociones(PromocionesDTO laPromocionParaGuardar)
        {
            try
            {
                await _agregarPromocionesLN.Registrar(laPromocionParaGuardar);
                return RedirectToAction("ListaDePromociones");
            }
            catch
            {
                return View();
            }
        }

        // -----------------------------
        // EDITAR PROMOCIÓN
        // -----------------------------
        public ActionResult EditarPromociones(int id)
        {
            ObtenerPromocionPorIdAD obtenerPromocionesPorIdAD =
                new ObtenerPromocionPorIdAD();

            PromocionesDTO promocion =
                obtenerPromocionesPorIdAD.ObtenerPorId(id);

            if (promocion == null)
                return RedirectToAction("ListaDePromociones");

            return View(promocion);
        }

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

        // -----------------------------
        // DESACTIVAR PROMOCIÓN
        // -----------------------------
        public async Task<ActionResult> ActivarDesactivar(int id)
        {
            PromocionesDTO promocion = new PromocionesDTO();
            promocion.id_Promocion = id;

            await _eliminarPromocionesLN.ActivarDesactivarPromocion(promocion);

            return RedirectToAction("ListaDePromociones");
        }

        // -----------------------------
        // LISTADO DE COMBOS
        // -----------------------------
        public ActionResult CombosPromocionales()
        {
            var ln = new ObtenerCombosPromocionalesLN();

            List<ComboPromocionalDTO> lista = ln.Obtener();

            return View(lista);
        }
    }
}