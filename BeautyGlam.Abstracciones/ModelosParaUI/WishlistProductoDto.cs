using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class WishlistProductoDto
    {
        public int id_Wishlist { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
    }
}