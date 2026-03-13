using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.ActivarDesactivarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia;
using BeautyGlam.LogicaDeNegocio;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo.ActivarDesactivarGuiaRegalo;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class GuiaRegalosController : Controller
    {
        private readonly ObtenerGuiaRegaloLN _obtenerListaGuiaRegaloLN;
        private readonly IRegistrarGuiaRegaloLN _registrarGuiaRegaloLN;
        private readonly ObtenerProductosParaGuiaLN _obtenerProductosLN;
        private readonly IObtenerProductosParaGuiaAD _obtenerProductosAD;
        private readonly IEditarGuiaRegaloLN _editarGuiaRegaloLN;
        private readonly IActivarDesactivarGuiaRegaloLN _activarDesactivarGuiaLN;
        public GuiaRegalosController()
        {
            _obtenerListaGuiaRegaloLN = new ObtenerGuiaRegaloLN();
            _registrarGuiaRegaloLN = new RegistrarGuiaRegaloLN();

            _obtenerProductosAD = new ObtenerProductosParaGuiaAD();
            _obtenerProductosLN = new ObtenerProductosParaGuiaLN(_obtenerProductosAD);
            IEditarGuiaRegaloAD editarAD = new EditarGuiaRegaloAD();
            _editarGuiaRegaloLN = new EditarGuiaRegaloLN(editarAD);
            _activarDesactivarGuiaLN = new ActivarDesactivarGuiaRegaloLN();
        }

        public ActionResult Index(
            int? idOcasion,
            int? idCategoria,
            decimal? precioMin,
            decimal? precioMax,
            string genero,
            int pagina = 1)
        {
            int registrosPorPagina = 8;

            var lista = _obtenerListaGuiaRegaloLN.Obtener();

            if (idOcasion.HasValue)
                lista = lista.Where(x => x.idOcasion == idOcasion.Value).ToList();

            if (idCategoria.HasValue)
                lista = lista.Where(x => x.id == idCategoria.Value).ToList();

            if (precioMin.HasValue)
                lista = lista.Where(x => x.presupuesto >= precioMin.Value).ToList();

            if (precioMax.HasValue)
                lista = lista.Where(x => x.presupuesto <= precioMax.Value).ToList();

            if (!string.IsNullOrEmpty(genero))
                lista = lista.Where(x => x.genero == genero).ToList();

            lista = lista.OrderByDescending(x => x.estado)
                         .ThenByDescending(x => x.idGuia)
                         .ToList();

            int totalRegistros = lista.Count();
            var guiasPaginadas = lista
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);

            var contexto = new Contexto();
            ViewBag.Ocasiones = contexto.Ocasiones.Where(o => o.estado).ToList();
            ViewBag.Categorias = contexto.Categoria.Where(c => c.estado).ToList();

            return View(guiasPaginadas);
        }

        public ActionResult Filtrar(int? idOcasion, int? idCategoria, decimal? precioMin, decimal? precioMax, string genero)
        {
            var lista = _obtenerListaGuiaRegaloLN.Obtener();

            if (idOcasion.HasValue)
                lista = lista.Where(x => x.idOcasion == idOcasion.Value).ToList();

            if (idCategoria.HasValue)
                lista = lista.Where(x => x.id == idCategoria.Value).ToList();

            if (precioMin.HasValue)
                lista = lista.Where(x => x.presupuesto >= precioMin.Value).ToList();

            if (precioMax.HasValue)
                lista = lista.Where(x => x.presupuesto <= precioMax.Value).ToList();

            if (!string.IsNullOrEmpty(genero))
                lista = lista.Where(x => x.genero == genero).ToList();

            return PartialView("_TablaGuias", lista);
        }



        public async Task<ActionResult> RegistrarRegalo()
        {
            var contexto = new Contexto();

            ViewBag.Ocasiones = contexto.Ocasiones
                .Where(o => o.estado)
                .ToList();

            ViewBag.Categorias = contexto.Categoria
                .Where(c => c.estado)
                .ToList();

            GuiaRegaloDto modelo = new GuiaRegaloDto
            {
                productosDisponibles = await _obtenerProductosLN.Obtener(),
                productosSeleccionados = new List<int>()
            };

            return View(modelo);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> RegistrarRegalo(GuiaRegaloDto elRegaloParaGuardar)
        {
            if (!ModelState.IsValid)
            {
                elRegaloParaGuardar.productosDisponibles =
                    await _obtenerProductosLN.Obtener();

                var ocasiones = new Contexto().Ocasiones
                    .Where(o => o.estado)
                    .ToList();

                ViewBag.Ocasiones = ocasiones;

                return View(elRegaloParaGuardar);
            }

            elRegaloParaGuardar.estado = true;

            await _registrarGuiaRegaloLN.Registrar(elRegaloParaGuardar);
            return RedirectToAction("Index");
        }

        
        public async Task<ActionResult> Editar(int id)
        {
            List<GuiaRegaloDto> guias =
                _obtenerListaGuiaRegaloLN.Obtener();

            GuiaRegaloDto guia =
                guias.FirstOrDefault(g => g.idGuia == id);

            if (guia == null)
                return HttpNotFound();

            List<ProductoSeleccionadoDto> productos =
                await _obtenerProductosLN.Obtener();

            guia.productosDisponibles = productos;

            if (guia.productosSeleccionados == null)
                guia.productosSeleccionados = new List<int>();


            var contexto = new Contexto();

            ViewBag.Ocasiones = contexto.Ocasiones
                .Where(o => o.estado)
                .ToList();

            ViewBag.Categorias = contexto.Categoria
                .Where(c => c.estado)
                .ToList();

            return View(guia);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(GuiaRegaloDto modelo)
        {
            if (!ModelState.IsValid)
            {
                List<ProductoSeleccionadoDto> productos =
                    await _obtenerProductosLN.Obtener();

                modelo.productosDisponibles = productos;

                var contexto = new Contexto();

                ViewBag.Ocasiones = contexto.Ocasiones
                    .Where(o => o.estado)
                    .ToList();

                ViewBag.Categorias = contexto.Categoria
                    .Where(c => c.estado)
                    .ToList();

                return View(modelo);
            }

            await _editarGuiaRegaloLN.Editar(modelo);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ActivarDesactivar(int id)
        {
            var guia = _obtenerListaGuiaRegaloLN
                .Obtener()
                .FirstOrDefault(g => g.idGuia == id);

            if (guia == null)
                return RedirectToAction("Index");

            await _activarDesactivarGuiaLN.ActivarDesactivar(guia);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Detalle(int id)
        {
            GuiaRegaloDto guia = _obtenerListaGuiaRegaloLN
                .Obtener()
                .FirstOrDefault(g => g.idGuia == id);

            if (guia == null)
                return HttpNotFound();

            List<ProductoSeleccionadoDto> productos = await _obtenerProductosLN.Obtener();

            guia.productosDisponibles = productos
                .Where(p => guia.productosSeleccionados.Contains(p.id))
                .ToList();

            return View(guia);
        }


    }
}
