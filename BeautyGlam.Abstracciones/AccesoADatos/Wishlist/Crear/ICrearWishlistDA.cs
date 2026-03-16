using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Wishlist.CrearWishlist
{
    public interface ICrearWishlistAD
    {
        Task<int> Crear(WishlistDto wishlistParaGuardar);
    }
}