using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.CambiarEstadoUsuario
{
    public interface IActualizarEstadoUsuarioLN
    {
        Task<int> ActualizarEstado(int idUsuario, bool nuevoEstado);
    }
}
