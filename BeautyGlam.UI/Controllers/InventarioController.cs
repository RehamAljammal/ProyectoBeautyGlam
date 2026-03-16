using BeautyGlam.Abstracciones.AccesoADatos.Categoria.ListaCategoria;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStock;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStockActual;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.ListaDeInventario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.Movimiento.ListaDeMovimientos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.ListaCategoria;
using BeautyGlam.LogicaDeNegocio.Inventario.EditarStock;
using BeautyGlam.LogicaDeNegocio.Inventario.EditarStockActual;
using BeautyGlam.LogicaDeNegocio.Inventario.ListaDeInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace BeautyGlam.UI.Controllers
{

    public class InventarioController : Controller
    {
        private readonly IObtenerListaDeInventarioLN _obtenerListaDeInventarioLN;
        private readonly IEditarStockLN _editarStockLN;
        private readonly IEditarStockActualLN _editarStockActualLN;
        private readonly IObtenerListaDeMovimientosLN _listaMovimientosLN;
        private readonly IObtenerListaDeCategoriasAD _obtenerListaCategoriasLN;


        public InventarioController()
        {
            _obtenerListaDeInventarioLN = new ObtenerLaListaDeInventarioLN();
            _editarStockLN = new EditarStockLN();
            _editarStockActualLN = new EditarStockActualLN();
            _obtenerListaCategoriasLN = new ObtenerListaDeCategoriasAD();
        }

        // ================== LISTA ==================
        public ActionResult ListaDeInventario(string buscar, int pagina = 1)
        {
            int registrosPorPagina = 10;

            List<InventarioDto> inventario = _obtenerListaDeInventarioLN.Obtener();

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                buscar = buscar.ToLower().Trim();
                inventario = inventario.Where(i => i.nombre.ToLower().Contains(buscar)).ToList();
            }

            inventario = inventario.OrderByDescending(i => i.nombre).ToList();

            int totalRegistros = inventario.Count();

            var inventarioPaginado = inventario
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);
            ViewBag.Buscar = buscar;

            return View(inventarioPaginado);
        }

        // ================== EDITAR STOCK ACTUAL ==================
        public async Task<ActionResult> EditarStockActual(int id)
        {
            InventarioDto inventario =
                await _editarStockActualLN.ObtenerPorProducto(id);

            if (inventario == null)
                throw new System.Exception("NO SE ENCONTRÓ INVENTARIO. ID RECIBIDO: " + id);

            return View(inventario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarStockActual(InventarioDto modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            int resultado = await _editarStockActualLN.Editar(modelo);

            switch (resultado)
            {
                case -1:
                    ModelState.AddModelError("", "No existe inventario para este producto.");
                    return View(modelo);

                case -2:
                    ModelState.AddModelError("stockActual",
                        "El stock actual no puede ser menor al stock mínimo.");
                    return View(modelo);

                case -3:
                    ModelState.AddModelError("stockActual",
                        "El stock actual no puede ser mayor al stock máximo.");
                    return View(modelo);

                default:
                    TempData["MensajeExito"] = "Stock actualizado correctamente.";
                    return RedirectToAction("ListaDeInventario");
            }
        }


        // ================== EDITAR MIN / MAX ==================
        public async Task<ActionResult> EditarStock(int id)
        {
            var inventario = await _editarStockLN.ObtenerPorProducto(id);
            return View(inventario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarStock(InventarioDto modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            await _editarStockLN.EditarStockMinMax(modelo);
            return RedirectToAction("ListaDeInventario");
        }

        /*
        // ================== MOVIMIENTOS ==================
        public ActionResult MovimientosI(int id)
        {
            // id = id
            List<MovimientoInventarioDto> movimientos =
                _listaMovimientosLN.Obtener();

            movimientos = movimientos
                            .Where(m => m.id == id)
                            .ToList();

            return View(movimientos);
        }
        */

        // ================== Avanzado ==================
        public ActionResult Avanzado(
            string nombre = null,
            int? stockMenorA = null)
        {
            List<InventarioDto> lista =
                _obtenerListaDeInventarioLN.Obtener();

            if (!string.IsNullOrEmpty(nombre))
            {
                lista = lista
                    .Where(i => i.nombre.ToLower().Contains(nombre.ToLower()))
                    .ToList();
            }

            if (stockMenorA.HasValue)
            {
                lista = lista
                    .Where(i => i.stockActual <= stockMenorA.Value)
                    .ToList();
            }

            return View(lista);
        }


        public ActionResult Movimientos(DateTime? fechaInicio, DateTime? fechaFin, int pagina = 1)
        {
            IObtenerMovimientosInventarioAD ad =
                new ObtenerMovimientosInventarioAD();

            IObtenerMovimientosInventarioLN ln =
                new ObtenerMovimientosInventarioLN(ad);

            var movimientos = ln.ObtenerTodos();

            if (fechaInicio.HasValue)
            {
                movimientos = movimientos
                    .Where(x => x.fechaMovimiento.Date >= fechaInicio.Value.Date)
                    .ToList();
            }

            if (fechaFin.HasValue)
            {
                movimientos = movimientos
                    .Where(x => x.fechaMovimiento.Date <= fechaFin.Value.Date)
                    .ToList();
            }

            movimientos = movimientos.OrderByDescending(x => x.fechaMovimiento).ToList();

            int registrosPorPagina = 10;
            int totalRegistros = movimientos.Count();
            var movimientosPaginados = movimientos
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = Math.Ceiling((double)totalRegistros / registrosPorPagina);
            ViewBag.FechaInicio = fechaInicio;
            ViewBag.FechaFin = fechaFin;

            if (!movimientosPaginados.Any())
            {
                ViewBag.Mensaje = "No hay movimientos para ese rango de fechas.";
            }

            return View(movimientosPaginados);
        }
    }
}
