using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.EliminarProductoWishlist;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.EliminarProductoWishlist;
using BeautyGlam.AccesoADatos.Wishlist.EliminarProductoWishlist;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Wishlist.EliminarProductoWishlist
{
    public class EliminarProductoWishlistLN : IEliminarProductoWishlistLN
    {
        private readonly IEliminarProductoWishlistAD _eliminarProductoAD;

        public EliminarProductoWishlistLN()
        {
            _eliminarProductoAD = new EliminarProductoWishlistAD();
        }

        public async Task<int> Eliminar(int idWishlist, int idProducto)
        {
            return await _eliminarProductoAD.Eliminar(idWishlist, idProducto);
        }
    }
}