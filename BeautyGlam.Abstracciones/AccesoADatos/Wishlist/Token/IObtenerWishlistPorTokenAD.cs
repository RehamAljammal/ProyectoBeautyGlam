using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Wishlist.CompartirWishlist
{
    public interface IObtenerWishlistPorTokenAD
    {
        Task<IEnumerable<WishlistProductoDto>> Obtener(string token);
    }
}