using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Rol.ListaRol
{
    public interface IObtenerListaDeRolesAD
    {
        List<RolDto> Obtener();
    }
}
