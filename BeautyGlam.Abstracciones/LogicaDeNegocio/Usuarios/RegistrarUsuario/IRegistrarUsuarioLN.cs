using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.RegistrarUsuario
{
    public interface IRegistrarUsuarioLN
    {
        Task<int> Registrar(UsuarioCrearDto elUsuario);
    }
}
