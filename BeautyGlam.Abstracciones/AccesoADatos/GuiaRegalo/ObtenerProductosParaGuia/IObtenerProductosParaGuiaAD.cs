using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ObtenerProductosParaGuia
{
    public interface IObtenerProductosParaGuiaAD
    {
        List<ProductoSeleccionadoDto> Obtener();
    }
}
