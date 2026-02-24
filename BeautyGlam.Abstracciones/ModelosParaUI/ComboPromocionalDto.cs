using System;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class ComboPromocionalDTO
    {
        public int idCombo { get; set; }

        public string titulo { get; set; }
        public string descripcion { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

        public decimal precioCombo { get; set; }

        public bool estado { get; set; }

        public List<int> idsProductos { get; set; }
        public List<ProductoComboDTO> productos { get; set; }
        public List<ProductosDTO> Productos { get; set; }

    }
}
