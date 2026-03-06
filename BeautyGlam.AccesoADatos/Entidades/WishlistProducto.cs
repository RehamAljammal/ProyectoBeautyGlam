using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Entidades
{
    public class WishlistProducto
    {
        public int id_Wishlist { get; set; }
        public int id { get; set; }  

        public Wishlist Wishlist { get; set; }
    }
}