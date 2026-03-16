using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.AgregarProductoWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Wishlist.AgregarProductoWishlist
{
    public class AgregarProductoWishlistAD : IAgregarProductoWishlistAD
    {
        private readonly Contexto _elContexto;

        public AgregarProductoWishlistAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Agregar(WishlistProductoDto productoParaAgregar)
        {
            // ===== VALIDAR SI YA EXISTE =====
            WishlistProductoAD registroExistente =
                _elContexto.WishlistProducto.FirstOrDefault(p =>
                p.idWishlist == productoParaAgregar.id_Wishlist &&
                p.idProducto == productoParaAgregar.idProducto);

            if (registroExistente != null)
            {
                return 0;
            }

            WishlistProductoAD nuevoProducto = ConvierteObjetoAEntidad(productoParaAgregar);

            _elContexto.WishlistProducto.Add(nuevoProducto);

            await _elContexto.SaveChangesAsync();

            return 1;
        }

        private WishlistProductoAD ConvierteObjetoAEntidad(WishlistProductoDto productoParaAgregar)
        {
            return new WishlistProductoAD
            {
                idWishlist = productoParaAgregar.id_Wishlist,
                idProducto = productoParaAgregar.idProducto
            };
    }
    }
}