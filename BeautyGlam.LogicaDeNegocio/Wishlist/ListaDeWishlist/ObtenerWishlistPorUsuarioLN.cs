using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.ListaDeWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.ListaDeWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Wishlist.ListaDeWishlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Wishlist.ListaDeWishlist
{
    public class ObtenerWishlistPorUsuarioLN : IObtenerWishlistPorUsuarioLN
    {
        private readonly IObtenerWishlistPorUsuarioAD _listaWishlistAD;

        public ObtenerWishlistPorUsuarioLN()
        {
            _listaWishlistAD = new ObtenerWishlistPorUsuarioAD();
        }

        public async Task<IEnumerable<WishlistProductoDto>> Obtener(int idUsuario)
        {
            return await _listaWishlistAD.Obtener(idUsuario);
        }
    }
}
