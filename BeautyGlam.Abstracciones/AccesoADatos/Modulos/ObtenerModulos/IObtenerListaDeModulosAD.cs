using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Modulo.ListaModulo
{
    public interface IObtenerListaDeModulosAD
    {
        List<ModuloDto> Obtener();
    }
}