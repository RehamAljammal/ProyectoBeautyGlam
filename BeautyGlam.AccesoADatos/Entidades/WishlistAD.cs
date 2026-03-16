using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyGlam.AccesoADatos.Entidades
{
    [Table("Wishlist")]
    public class WishlistAD
    {
        [Key]
        [Column("id_Wishlist")]
        public int idWishlist { get; set; }

        [Column("id_Usuario")]
        public int idUsuario { get; set; }

        [Column("fecha_Creacion")]
        public DateTime fechaCreacion { get; set; }
    }
}