using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Devolucion
{
    public interface IListaDevolucionAD
    {
        List<DevolucionListadoDto> Obtener();
    }
}