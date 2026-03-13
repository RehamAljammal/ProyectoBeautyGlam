using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class GuiaRegaloDto
    {
        public int idGuia { get; set; }

        public int idOcasion { get; set; }
        public string nombreOcasion { get; set; }

        public decimal presupuesto { get; set; }
        public string genero { get; set; }
        public int id { get; set; } 
        public string nombreCategoria { get; set; }
        public bool estado { get; set; }

        public List<int> productosSeleccionados { get; set; }
        public List<ProductoSeleccionadoDto> productosDisponibles { get; set; }
    }
}

