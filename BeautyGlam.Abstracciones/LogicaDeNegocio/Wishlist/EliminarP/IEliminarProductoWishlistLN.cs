using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Wishlist.EliminarProductoWishlist
{
    public interface IEliminarProductoWishlistLN
    {
        Task<int> Eliminar(int idWishlist, int idProducto);
    }
}
