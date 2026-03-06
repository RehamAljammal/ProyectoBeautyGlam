using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class DetalleVentaDto
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public decimal precio_Unitario { get; set; }
        public decimal subtotal { get; set; }
    }
}
