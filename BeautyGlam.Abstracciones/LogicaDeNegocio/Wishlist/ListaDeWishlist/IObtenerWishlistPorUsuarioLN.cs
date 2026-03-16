using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.ListaDeWishlist
{
    public interface IObtenerWishlistPorUsuarioLN
    {
        Task<IEnumerable<WishlistProductoDto>> Obtener(int idUsuario);

    }
}
