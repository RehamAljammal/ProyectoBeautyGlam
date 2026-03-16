using System;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class VentaFacturaDto
    {
        public int id_Venta { get; set; }
        public string numeroFactura { get; set; }
        public string cliente { get; set; }
        public DateTime fecha { get; set; }
        public string metodoPago { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }

        public List<DetalleFacturaDto> Detalles { get; set; }
    }
}