using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.ListaDeWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Wishlist.ListaDeWishlist
{
    public class ObtenerWishlistPorUsuarioAD : IObtenerWishlistPorUsuarioAD
    {
        private readonly Contexto _elContexto;

        public ObtenerWishlistPorUsuarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<IEnumerable<WishlistProductoDto>> Obtener(int idUsuario)
        {
            var lista =
                from w in _elContexto.Wishlist
                join wp in _elContexto.WishlistProducto
                    on w.idWishlist equals wp.idWishlist
                join p in _elContexto.Producto
                    on wp.idProducto equals p.id
                where w.idUsuario == idUsuario
                select new WishlistProductoDto
                {
                    id_Wishlist = wp.idWishlist,
                    idProducto = p.id,
                    nombre = p.nombre,
                    precio = p.precio,
                    imagen = p.imagen
                };

            return await Task.FromResult(lista.ToList());
        }
    }
}