using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Tono;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [Authorize]
    public class TonoController : Controller
    {

        private readonly CrearTonoLN _crearTonoLN;
        private readonly EditarTonoLN _editarTonoLN;
        private readonly DesactivarTonoLN _desactivarTonoLN;
        private readonly ObtenerListaTonoLN _obtenerListaTonoLN;

        public TonoController()
        {
            _crearTonoLN = new CrearTonoLN();
            _editarTonoLN = new EditarTonoLN();
            _desactivarTonoLN = new DesactivarTonoLN();
            _obtenerListaTonoLN = new ObtenerListaTonoLN();
        }

        // ==============================
        // LISTA TONOS
        // ==============================

        public ActionResult Index()
        {
            var lista = _obtenerListaTonoLN.ObtenerTodos();
            return View(lista);
        }

        // ==============================
        // CREAR TONO
        // ==============================

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(TonoDTO modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            await _crearTonoLN.Crear(modelo);

            TempData["Msg"] = "Tono creado correctamente.";
            return RedirectToAction("Index");
        }

        // ==============================
        // EDITAR TONO
        // ==============================

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var tono = _obtenerListaTonoLN.ObtenerTodos()
                .Find(t => t.id_Tono == id);

            if (tono == null)
                return HttpNotFound();

            return View(tono);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(TonoDTO modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            await _editarTonoLN.Editar(modelo);

            TempData["Msg"] = "Tono actualizado correctamente.";
            return RedirectToAction("Index");
        }

        // ==============================
        // DESACTIVAR TONO
        // ==============================

        [HttpPost]
        public async Task<ActionResult> Desactivar(int id)
        {
            await _desactivarTonoLN.Desactivar(id);
            return RedirectToAction("Index");
        }
    }
}