using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.Recuperacion
{
    public interface IUsuarioRecuperacionAD
    {
        Task<int?> ObtenerIdUsuarioPorCorreo(string correo);
        Task<int> ActualizarPassword(int idUsuario, byte[] passwordHash, byte[] passwordSalt);
    }
}
