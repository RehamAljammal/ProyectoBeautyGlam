using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Wishlist.EliminarProductoWishlist
{
    public interface IEliminarProductoWishlistAD
    {
        Task<int> Eliminar(int idWishlist, int idProducto);
    }
}