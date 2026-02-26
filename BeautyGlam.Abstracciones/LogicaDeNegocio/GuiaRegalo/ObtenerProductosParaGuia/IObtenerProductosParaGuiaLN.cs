using System.Collections.Generic;
using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.Flujo
{
    public interface IObtenerProductosParaGuiaLN
    {
        Task<List<ProductoSeleccionadoDto>> Obtener();
    }
}
