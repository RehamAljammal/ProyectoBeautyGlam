using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.AgregarProductoWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.AgregarProductoWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Wishlist.AgregarProductoWishlist;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Wishlist.AgregarProductoWishlist
{
    public class AgregarProductoWishlistLN : IAgregarProductoWishlistLN
    {
        private readonly IAgregarProductoWishlistAD _agregarProductoAD;

        public AgregarProductoWishlistLN()
        {
            _agregarProductoAD = new AgregarProductoWishlistAD();
        }

        public async Task<int> Agregar(WishlistProductoDto productoParaAgregar)
        {
            return await _agregarProductoAD.Agregar(productoParaAgregar);
        }
    }
}