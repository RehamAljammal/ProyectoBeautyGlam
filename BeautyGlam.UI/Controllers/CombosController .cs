using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Productos.ListaProductos;
using BeautyGlam.LogicaDeNegocio.Promociones.Combo;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class CombosController : Controller
    {
        private readonly IObtenerCombosPromocionalesLN _obtenerLN;
        private readonly IAgregarComboPromocionalLN _agregarLN;
        private readonly IEditarComboPromocionalLN _editarLN;
        private readonly IEliminarComboPromocionalLN _eliminarLN;
        private readonly IObtenerComboPorIdLN _obtenerPorIdLN;

        public CombosController()
        {
            _obtenerLN = new ObtenerCombosPromocionalesLN();
            _agregarLN = new AgregarComboPromocionalLN();
            _editarLN = new EditarComboPromocionalLN();
            _eliminarLN = new EliminarComboPromocionalLN();
            _obtenerPorIdLN = new ObtenerComboPorIdLN();
        }

        // =========================
        // LISTADO
        // =========================
        public ActionResult Index()
        {
            var lista = _obtenerLN.Obtener();
            return View("CombosPromocionales", lista);
        }

        // =========================
        // CREAR
        // =========================
        public ActionResult Crear()
        {
            var productos = new ObtenerLaListaDeProductosLN().Obtener();
            ViewBag.Productos = productos;

            return View(new ComboPromocionalDTO());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(ComboPromocionalDTO combo, int[] idsProductos)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Productos = new ObtenerLaListaDeProductosLN().Obtener();
                return View(combo);
            }

            // Asignamos los IDs de productos al DTO
            combo.idsProductos = idsProductos.ToList();

            // Llamada al método con un solo parámetro
            await _agregarLN.Agregar(combo);

            return RedirectToAction("Index");
        }

        // =========================
        // EDITAR
        // =========================
        public ActionResult Editar(int id)
        {
            var combo = _obtenerPorIdLN.ObtenerPorId(id);

            if (combo == null)
                return HttpNotFound();

            var productos = new ObtenerLaListaDeProductosLN().Obtener();
            ViewBag.Productos = productos;

            return View(combo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(
            ComboPromocionalDTO combo,
            int[] idsProductos)
        {
            if (idsProductos == null || !idsProductos.Any())
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto.");

                ViewBag.Productos = new ObtenerLaListaDeProductosLN().Obtener();
                return View(combo);
            }

            combo.idsProductos = idsProductos.ToList();

            if (!ModelState.IsValid)
            {
                ViewBag.Productos = new ObtenerLaListaDeProductosLN().Obtener();
                return View(combo);
            }

            _editarLN.Editar(combo);

            return RedirectToAction("Index");
        }

        // =========================
        // ELIMINAR
        // =========================
        public ActionResult Eliminar(int id)
        {
            var combo = _obtenerPorIdLN.ObtenerPorId(id);

            if (combo == null)
                return HttpNotFound();

            return View(combo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            _eliminarLN.Eliminar(id);

            return RedirectToAction("Index");
        }
    }
}