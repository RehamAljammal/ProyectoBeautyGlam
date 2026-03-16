using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class WishlistDto
    {
        public int id_Wishlist { get; set; }

        public int id_Usuario { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime fecha_Creacion { get; set; }
    }
}