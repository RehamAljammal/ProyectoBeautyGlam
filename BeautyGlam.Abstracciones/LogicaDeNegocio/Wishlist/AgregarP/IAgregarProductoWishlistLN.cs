using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.AgregarProductoWishlist
{
    public interface IAgregarProductoWishlistLN
    {
        Task<int> Agregar(WishlistProductoDto productoParaAgregar);
    }
}