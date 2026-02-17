using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.CambiarEstadoUsuario
{
    public interface IActualizarEstadoUsuarioAD
    {
        Task<int> ActualizarEstado(int idUsuario, bool nuevoEstado);
    }
}
