using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Tono.ObtenerListaTono
{
    public interface IObtenerListaTonoAD
    {
        List<TonoDTO> ObtenerTodos();
    }
}