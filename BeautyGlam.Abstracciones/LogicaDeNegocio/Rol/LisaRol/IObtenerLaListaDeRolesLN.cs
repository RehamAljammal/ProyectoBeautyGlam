using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.ListaRol
{
    public interface IObtenerLaListaDeRolesLN
    {
        List<RolDto> Obtener();
    }
}
