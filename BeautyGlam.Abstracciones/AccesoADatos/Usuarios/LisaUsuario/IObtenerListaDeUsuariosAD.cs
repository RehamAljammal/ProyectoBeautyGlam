using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.ListaUsuario
{
    public interface IObtenerListaDeUsuariosAD
    {
        List<UsuarioDto> Obtener();
    }
}
