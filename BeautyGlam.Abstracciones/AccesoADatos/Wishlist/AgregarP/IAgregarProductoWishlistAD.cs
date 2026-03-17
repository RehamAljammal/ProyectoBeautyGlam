using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Wishlist.AgregarProductoWishlist
{
    public interface IAgregarProductoWishlistAD
    {
        Task<int> Agregar(WishlistProductoDto productoParaAgregar);
    }
}