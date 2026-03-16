using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.CrearWishlist
{
    public interface ICrearWishlistLN
    {
        Task<int> Crear(WishlistDto wishlistParaGuardar);
    }
}