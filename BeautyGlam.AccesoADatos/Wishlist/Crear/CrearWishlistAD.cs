using BeautyGlam.Abstracciones.AccesoADatos.Wishlist.CrearWishlist;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Wishlist.CrearWishlist
{
    public class CrearWishlistAD : ICrearWishlistAD
    {
        private readonly Contexto _elContexto;

        public CrearWishlistAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Crear(WishlistDto wishlistParaGuardar)
        {
            // ===== VALIDAR SI EL USUARIO YA TIENE WISHLIST =====
            WishlistAD wishlistExistente =
                _elContexto.Wishlist.FirstOrDefault(w => w.idUsuario == wishlistParaGuardar.id_Usuario);

            if (wishlistExistente != null)
            {
                return wishlistExistente.idWishlist;
            }

            // ===== CREAR WISHLIST =====
            WishlistAD nuevaWishlist = ConvierteObjetoAEntidad(wishlistParaGuardar);

            _elContexto.Wishlist.Add(nuevaWishlist);
            await _elContexto.SaveChangesAsync();

            return nuevaWishlist.idWishlist;
        }

        private WishlistAD ConvierteObjetoAEntidad(WishlistDto wishlistParaGuardar)
        {
            return new WishlistAD
            {
                idUsuario = wishlistParaGuardar.id_Usuario,
                fechaCreacion = DateTime.Now
            };
        }
    }
}
