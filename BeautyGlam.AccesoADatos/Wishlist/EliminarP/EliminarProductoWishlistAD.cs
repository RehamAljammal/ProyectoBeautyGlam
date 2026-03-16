using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.EliminarProductoWishlist;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Wishlist.EliminarProductoWishlist
{
    public class EliminarProductoWishlistAD : IEliminarProductoWishlistAD
    {
        private readonly Contexto _elContexto;

        public EliminarProductoWishlistAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(int idWishlist, int idProducto)
        {
            WishlistProductoAD registro =
                _elContexto.WishlistProducto.FirstOrDefault(p =>
                    p.idWishlist == idWishlist && p.idProducto == idProducto);

            if (registro == null)
            {
                return 0;
            }

            _elContexto.WishlistProducto.Remove(registro);

            await _elContexto.SaveChangesAsync();

            return 1;
        }
    }
}