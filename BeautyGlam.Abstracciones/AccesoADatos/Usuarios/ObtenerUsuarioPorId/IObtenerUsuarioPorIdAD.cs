using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.ObtenerUsuarioPorId
{
    public interface IObtenerUsuarioPorIdAD
    {
        UsuarioDto ObtenerPorId(int idDeUsuarioABuscar);
    }
}
