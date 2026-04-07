using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.CompartirWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Wishlist.CompartirWishlist
{
    public class ObtenerWishlistPorTokenAD : IObtenerWishlistPorTokenAD
    {
        private readonly Contexto _elContexto;

        public ObtenerWishlistPorTokenAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<IEnumerable<WishlistProductoDto>> Obtener(string token)
        {
            var lista =
                from w in _elContexto.Wishlist
                join wp in _elContexto.WishlistProducto
                    on w.idWishlist equals wp.idWishlist
                join p in _elContexto.Producto
                    on wp.idProducto equals p.id
                where w.tokenCompartir == token
                select new WishlistProductoDto
                {
                    id_Wishlist = w.idWishlist,
                    idProducto = p.id,
                    nombre = p.nombre,
                    precio = p.precio,
                    imagen = p.imagen
                };

            return await Task.FromResult(lista.ToList());
        }
    }
}