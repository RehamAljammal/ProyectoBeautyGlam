using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class MovimientoInventarioDto
    {
        public int idProducto { get; set; }

        public string nombreProducto { get; set; }

        public string tipoMovimiento { get; set; }

        public int cantidad { get; set; }

        public DateTime fechaMovimiento { get; set; }

        public string observacion { get; set; }
    }
}