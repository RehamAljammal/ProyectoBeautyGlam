using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.Perfil
{
    public interface IObtenerPerfilUsuarioLN
    {
        UsuarioDto Obtener(int idUsuario);
    }
}