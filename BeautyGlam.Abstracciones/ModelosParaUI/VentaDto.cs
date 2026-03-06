using System;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class VentaDto
    {
        public int id_Venta { get; set; }
        public int id_Usuario { get; set; }
        public DateTime fecha_Venta { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }

        public List<DetalleVentaDto> Detalles { get; set; }
        public PagoDto Pago { get; set; } = new PagoDto();

        public List<VentaItemDto> VentaItems { get; set; } = new List<VentaItemDto>();
    }
}