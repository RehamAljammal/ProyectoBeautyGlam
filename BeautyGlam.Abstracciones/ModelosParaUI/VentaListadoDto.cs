using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class VentaListadoDto
    {
        public int id_Venta { get; set; }
        public string nombreCliente { get; set; }
        public DateTime fecha_Venta { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public bool pagado { get; set; }
    }
}