using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.AgregarProductoWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.CrearWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.EliminarProductoWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.ListaDeWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.LogicaDeNegocio.Wishlist.AgregarProductoWishlist;
using BeautyGlam.LogicaDeNegocio.Wishlist.CrearWishlist;
using BeautyGlam.LogicaDeNegocio.Wishlist.EliminarProductoWishlist;
using BeautyGlam.LogicaDeNegocio.Wishlist.ListaDeWishlist;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyGlam.Web.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly ICrearWishlistLN _crearWishlistLN;
        private readonly IAgregarProductoWishlistLN _agregarProductoLN;
        private readonly IEliminarProductoWishlistLN _eliminarProductoLN;
        private readonly IObtenerWishlistPorUsuarioLN _listaWishlistLN;
        private readonly IObtenerCombosPromocionalesLN _combosPromocionalesLN;

        public WishlistController()
        {
            _crearWishlistLN = new CrearWishlistLN();
            _agregarProductoLN = new AgregarProductoWishlistLN();
            _eliminarProductoLN = new EliminarProductoWishlistLN();
            _listaWishlistLN = new ObtenerWishlistPorUsuarioLN();
            _combosPromocionalesLN = new ObtenerCombosPromocionalesLN();
        }

        // ==================================
        // VER WISHLIST DEL USUARIO
        // ==================================
        public async Task<ActionResult> Index()
        {
            if (Session["IdUsuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            int idUsuario = (int)Session["IdUsuario"];

            var lista = await _listaWishlistLN.Obtener(idUsuario);

            // Obtener promociones
            var promociones = new ObtenerCombosPromocionalesLN().Obtener();

            ViewBag.Promociones = promociones;

            return View(lista);
        }

        // ==================================
        // AGREGAR PRODUCTO A WISHLIST (AJAX)
        // ==================================
        [HttpPost]
        public async Task<JsonResult> Agregar(int idProducto)
        {
            if (Session["IdUsuario"] == null)
            {
                return Json(new { ok = false, login = true });
            }

            int idUsuario = (int)Session["IdUsuario"];

            // Buscar wishlist del usuario
            var wishlistUsuario = await _listaWishlistLN.Obtener(idUsuario);

            int idWishlist;

            // Si no existe wishlist, crear una
            if (wishlistUsuario == null || !wishlistUsuario.Any())
            {
                WishlistDto wishlist = new WishlistDto
                {
                    id_Usuario = idUsuario
                };

                idWishlist = await _crearWishlistLN.Crear(wishlist);
            }
            else
            {
                idWishlist = wishlistUsuario.First().id_Wishlist;
            }

            // Crear relación producto-wishlist
            WishlistProductoDto producto = new WishlistProductoDto
            {
                id_Wishlist = idWishlist,
                idProducto = idProducto
            };

            await _agregarProductoLN.Agregar(producto);

            return Json(new { ok = true });
        }

        // ==================================
        // ELIMINAR PRODUCTO DE WISHLIST
        // ==================================
        [HttpPost]
        public async Task<ActionResult> Eliminar(int idWishlist, int idProducto)
        {
            if (Session["IdUsuario"] == null)
                return RedirectToAction("Login", "Cuenta");

            await _eliminarProductoLN.Eliminar(idWishlist, idProducto);

            return RedirectToAction("Index");
        }
    }
}