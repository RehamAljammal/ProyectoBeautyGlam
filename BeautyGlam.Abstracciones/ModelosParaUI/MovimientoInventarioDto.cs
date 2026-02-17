using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class MovimientoInventarioDto
    {
        public int idMovimiento { get; set; }

        [Display(Name = "Tipo Movimiento")]
        public string tipoMovimiento { get; set; }

        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Fecha Movimiento")]
        public DateTime fechaMovimiento { get; set; }

        [Display(Name = "Observacion")]
        public string observacion { get; set; }


        public int idProducto { get; set; }

        [Display(Name = "Producto")]
        public string nombre { get; set; }
    }
}
