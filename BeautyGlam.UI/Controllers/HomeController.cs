using BeautyGlam.LogicaDeNegocio.Productos.ListaProductos;
using BeautyGlam.LogicaDeNegocio.Promociones.ListaPromociones;
using System.Linq;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Obtener todos los productos
            var ln = new ObtenerLaListaDeProductosLN();
            var todosProductos = ln.Obtener();

            // Filtrar solo productos de temporada activos
            var productosTemporada = todosProductos
                                     .Where(p => p.EsTemporada && p.estado)
                                     .ToList();

            // Guardar en ViewBag para la vista
            ViewBag.Temporada = productosTemporada;

            return View();

            // ===== Promociones activas =====
            var lnPromociones = new ObtenerLaListaDePromocionesLN();
            var promocionesActivas = lnPromociones.Obtener()
                                                  .Where(p => p.estado)
                                                  .ToList();

            ViewBag.Promociones = promocionesActivas;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
    }
}