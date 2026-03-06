using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Blog;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        // LN publicaciones
        private readonly CrearBlogLN _crearBlogLN;
        private readonly EditarBlogLN _editarBlogLN;
        private readonly DesactivarBlogLN _desactivarBlogLN;
        private readonly ObtenerListaBlogLN _obtenerListaBlogLN;

        // LN comentarios
        private readonly CrearComentarioLN _crearComentarioLN;
        private readonly DesactivarComentarioLN _desactivarComentarioLN;
        private readonly ObtenerListaComentarioLN _obtenerListaComentarioLN;

        public BlogController()
        {
            _crearBlogLN = new CrearBlogLN();
            _editarBlogLN = new EditarBlogLN();
            _desactivarBlogLN = new DesactivarBlogLN();
            _obtenerListaBlogLN = new ObtenerListaBlogLN();

            _crearComentarioLN = new CrearComentarioLN();
            _desactivarComentarioLN = new DesactivarComentarioLN();
            _obtenerListaComentarioLN = new ObtenerListaComentarioLN();
        }

        // ================================
        // Lista de publicaciones
        // ================================
        public ActionResult Index()
        {
            var publicaciones = _obtenerListaBlogLN.ObtenerTodos();
            return View(publicaciones);
        }

        // ================================
        // Crear publicación
        // ================================
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(BlogDto model, HttpPostedFileBase imagenArchivo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // ===== GUARDAR IMAGEN =====
                if (imagenArchivo != null && imagenArchivo.ContentLength > 0)
                {
                    string carpeta = Server.MapPath("~/img/blog/");

                    if (!Directory.Exists(carpeta))
                        Directory.CreateDirectory(carpeta);

                    string nombreArchivo = Guid.NewGuid() + Path.GetExtension(imagenArchivo.FileName);

                    string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                    imagenArchivo.SaveAs(rutaCompleta);

                    model.imagen = "/img/blog/" + nombreArchivo;
                }
                else
                {
                    model.imagen = "/img/blog/default.png";
                }

                await _crearBlogLN.Crear(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        // ================================
        // Editar publicación
        // ================================
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var publicacion = _obtenerListaBlogLN.ObtenerTodos().Find(b => b.id_Blog == id);
            if (publicacion == null) return HttpNotFound();
            return View(publicacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(BlogDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _editarBlogLN.Editar(model);
            TempData["Msg"] = "Publicación actualizada exitosamente.";
            return RedirectToAction("Index");
        }

        // ================================
        // Desactivar publicación
        // ================================
        [HttpPost]
        public async Task<ActionResult> Desactivar(int id)
        {
            await _desactivarBlogLN.Desactivar(id);
            return RedirectToAction("Index");
        }

        // ================================
        // Crear comentario
        // ================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearComentario(ComentarioBlogDto model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            // Seguridad: tomar id del usuario de sesión
            model.id_Usuario = (int)Session["IdUsuario"];

            await _crearComentarioLN.Crear(model);
            return RedirectToAction("Detalle", new { id = model.id_Blog });
        }

        // ================================
        // Desactivar comentario
        // ================================
        [HttpPost]
        public async Task<ActionResult> DesactivarComentario(int idComentario, int idBlog)
        {
            await _desactivarComentarioLN.Desactivar(idComentario);
            return RedirectToAction("Detalle", new { id = idBlog });
        }

        // ================================
        // Detalle publicación + comentarios
        // ================================
        public ActionResult Detalle(int id)
        {
            var publicacion = _obtenerListaBlogLN.ObtenerTodos().Find(b => b.id_Blog == id);
            if (publicacion == null) return HttpNotFound();

            var comentarios = _obtenerListaComentarioLN.ObtenerPorBlog(id);
            ViewBag.Comentarios = comentarios;

            return View(publicacion);
        }
    }
}