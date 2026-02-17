using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.RegistrarUsuario
{
    public interface IRegistrarUsuarioAD
    {
        Task<int> Registrar(
            UsuarioCrearDto elUsuario,
            byte[] passwordHash,
            byte[] passwordSalt
        );
    }
}
