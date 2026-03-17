using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.CrearWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.CrearWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Wishlist.CrearWishlist;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Wishlist.CrearWishlist
{
    public class CrearWishlistLN : ICrearWishlistLN
    {
        private readonly ICrearWishlistAD _crearWishlistAD;

        public CrearWishlistLN()
        {
            _crearWishlistAD = new CrearWishlistAD();
        }

        public async Task<int> Crear(WishlistDto wishlistParaGuardar)
        {
            return await _crearWishlistAD.Crear(wishlistParaGuardar);
        }
    }
}