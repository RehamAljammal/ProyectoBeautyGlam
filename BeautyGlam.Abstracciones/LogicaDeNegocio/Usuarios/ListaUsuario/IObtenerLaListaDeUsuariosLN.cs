using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.ListaUsuario
{
    public interface IObtenerLaListaDeUsuariosLN
    {
        List<UsuarioDto> Obtener();
    }
}
