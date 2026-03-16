using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Lista
{
    public interface IObtenerOcasionesAD
    {
        List<OcasionDto> Obtener();
    }
}