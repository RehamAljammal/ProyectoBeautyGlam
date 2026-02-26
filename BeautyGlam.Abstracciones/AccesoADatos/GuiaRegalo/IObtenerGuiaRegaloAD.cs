using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.Lista
{
    public interface IObtenerGuiaRegaloAD
    {
        List<GuiaRegaloDto> Obtener();
    }
}

