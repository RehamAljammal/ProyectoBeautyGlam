using BeautyGlam.AccesoADatos.Entidades; // <--- IMPORTANTE
using System.Data.Entity;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Wishlist.NewFolder1
{
    internal class ObtenerWishlistAD
    {
        private readonly Contexto _context;

        public ObtenerWishlistAD(Contexto context)
        {
            _context = context;
        }

        // Método de solo lectura
       // public WishlistAD ObtenerWishlistPorUsuario(int idUsuario)
      //  {
       //     return _context.Wishlist
        //        .Include(w => w.WishlistProducto.Select(wp => wp.Producto))
        //        .FirstOrDefault(w => w.id_Usuario == idUsuario);
        }
    }
