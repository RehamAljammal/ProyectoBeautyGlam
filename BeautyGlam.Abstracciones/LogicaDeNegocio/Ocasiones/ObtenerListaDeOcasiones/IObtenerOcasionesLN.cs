using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.Lista
{
    public interface IObtenerOcasionesLN
    {
        List<OcasionDto> Obtener();
    }
}