using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class InventarioDto
    {
        public int idInventario { get; set; }

        [Display(Name = "Stock Actual")]
        public int stockActual { get; set; }

        [Display(Name = "Stock Minimo")]
        public int stockMinimo { get; set; }

        [Display(Name = "Stock Maximo")]
        public int stockMaximo { get; set; }

        public int id { get; set; }

        [Display(Name = "Producto")]
        public string nombre { get; set; }


    }
}
