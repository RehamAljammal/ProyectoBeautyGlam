using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStock;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStockActual;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.ListaDeInventario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.Movimiento.ListaDeMovimientos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Inventario.EditarStock;
using BeautyGlam.LogicaDeNegocio.Inventario.EditarStockActual;
using BeautyGlam.LogicaDeNegocio.Inventario.ListaDeInventario;
using BeautyGlam.LogicaDeNegocio.Inventario.Movimiento.ListaDeMovimientos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;


namespace BeautyGlam.UI.Controllers
{
    public class InventarioController : Controller
    {
        private readonly IObtenerListaDeInventarioLN _obtenerListaDeInventarioLN;
        private readonly IEditarStockLN _editarStockLN;                 
        private readonly IEditarStockActualLN _editarStockActualLN;
        private readonly IObtenerListaDeMovimientosLN _listaMovimientosLN;


        public InventarioController()
        {
            _obtenerListaDeInventarioLN = new ObtenerLaListaDeInventarioLN();
            _editarStockLN = new EditarStockLN();
            _editarStockActualLN = new EditarStockActualLN();
            _listaMovimientosLN = new ObtenerLaListaDeMovimientosLN();
        }

        // ================== LISTA ==================
        public ActionResult ListaDeInventario()
        {
            List<InventarioDto> inventario =
                _obtenerListaDeInventarioLN.Obtener();

            return View(inventario);
        }

        // ================== EDITAR STOCK ACTUAL ==================
        public async Task<ActionResult> EditarStockActual(int id)
        {
            var inventario = await _editarStockActualLN.ObtenerPorProducto(id);
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

        // ================== MOVIMIENTOS ==================
        public ActionResult MovimientosI(int id)
        {
            // id = idProducto
            List<MovimientoInventarioDto> movimientos =
                _listaMovimientosLN.Obtener();

            movimientos = movimientos
                            .Where(m => m.idProducto == id)
                            .ToList();

            return View(movimientos);
        }

    }
}
