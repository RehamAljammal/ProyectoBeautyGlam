using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class ReporteFiltroDto
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCategoria { get; set; }
    }
}
