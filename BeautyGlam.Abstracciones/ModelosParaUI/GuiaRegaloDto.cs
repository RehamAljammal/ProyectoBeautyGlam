using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class GuiaRegaloDto
    {
        public int idGuia { get; set; }
        public string categoria { get; set; }
        public decimal presupuesto { get; set; }
        public string genero { get; set; }
        public string tipo { get; set; }
        public bool estado { get; set; }
        public List<int> productosSeleccionados { get; set; }
        public List<ProductoSeleccionadoDto> productosDisponibles { get; set; }
    }
}

