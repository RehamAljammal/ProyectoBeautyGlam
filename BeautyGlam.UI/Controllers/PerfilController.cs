using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.Perfil;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Usuario.Perfil;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private readonly IObtenerPerfilUsuarioLN _obtenerPerfilUsuarioLN;
        private readonly IEditarPerfilUsuarioLN _editarPerfilUsuarioLN;

        // ✅ ESTE ES EL QUE TE FALTABA
        public PerfilController()
        {
            _obtenerPerfilUsuarioLN = new ObtenerPerfilUsuarioLN();
            _editarPerfilUsuarioLN = new EditarPerfilUsuarioLN();
        }

        // (puedes dejar este también, no estorba)
        public PerfilController(
            IObtenerPerfilUsuarioLN obtenerPerfilUsuarioLN,
            IEditarPerfilUsuarioLN editarPerfilUsuarioLN)
        {
            _obtenerPerfilUsuarioLN = obtenerPerfilUsuarioLN;
            _editarPerfilUsuarioLN = editarPerfilUsuarioLN;
        }

        // ---------------------------------
        // HU-09-01
        public ActionResult Index()
        {
            int idUsuario = ObtenerIdUsuario();

            UsuarioDto elPerfil =
                _obtenerPerfilUsuarioLN.Obtener(idUsuario);

            return View(elPerfil);
        }

        // ---------------------------------
        // HU-09-02
        [HttpGet]
        public async Task<ActionResult> Editar()
        {
            int idUsuario = ObtenerIdUsuario();

            UsuarioDto elUsuario =
                await _editarPerfilUsuarioLN.ObtenerPorId(idUsuario);

            return View(elUsuario);
        }

        // ---------------------------------
        // HU-09-02
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(UsuarioDto model)
        {
            model.id_Usuario = ObtenerIdUsuario();

            int filas = await _editarPerfilUsuarioLN.Editar(model);

            if (filas == 0)
            {
                ModelState.AddModelError("", "No se pudo actualizar el perfil.");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // ---------------------------------
        private int ObtenerIdUsuario()
        {
            if (Session["IdUsuario"] == null)
                throw new Exception("No hay usuario en sesión.");

            return (int)Session["IdUsuario"];
        }
    }
}