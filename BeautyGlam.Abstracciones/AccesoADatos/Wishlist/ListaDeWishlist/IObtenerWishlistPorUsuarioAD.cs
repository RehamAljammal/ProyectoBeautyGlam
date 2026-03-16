using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Wishlist.ListaDeWishlist
{
    public interface IObtenerWishlistPorUsuarioAD
    {
        Task<IEnumerable<WishlistProductoDto>> Obtener(int idUsuario);

    }
}
