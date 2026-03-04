using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Entidades
{
    public class Wishlist
    {
        [Column("id_Wishlist")]
        public int id_Wishlist { get; set; }
        [Column("id_Usuario")]
        public int id_Usuario { get; set; }
        [Column("fecha_Creacion")]
        public DateTime fecha_Creacion { get; set; }

        public ICollection<WishlistProducto> WishlistProductos { get; set; }
    }
}
