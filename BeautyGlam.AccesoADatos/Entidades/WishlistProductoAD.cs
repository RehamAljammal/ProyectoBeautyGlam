using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Wishlist_Producto")]
    public class WishlistProductoAD
    {
        [Key, Column("id_Wishlist", Order = 0)]
        public int idWishlist { get; set; }

        [Key, Column("id", Order = 1)]
        public int idProducto { get; set; }
    }
}