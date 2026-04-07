using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.CompartirWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Wishlist.CompartirWishlist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Wishlist.CompartirWishlist
{
    public class ObtenerWishlistPorTokenLN
    {
        private readonly IObtenerWishlistPorTokenAD _wishlistAD;

        public ObtenerWishlistPorTokenLN()
        {
            _wishlistAD = new ObtenerWishlistPorTokenAD();
        }

        public async Task<IEnumerable<WishlistProductoDto>> Obtener(string token)
        {
            return await _wishlistAD.Obtener(token);
        }
    }
}