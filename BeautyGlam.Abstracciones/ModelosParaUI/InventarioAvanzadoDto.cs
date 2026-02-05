using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class InventarioAvanzadoDto
    {
            public int? stockMenorA { get; set; }
            public string busqueda { get; set; }

            public List<InventarioDto> Inventario { get; set; }
        }
    }



