using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.Perfil
{
    public interface IEditarPerfilUsuarioLN
    {
        Task<int> Editar(UsuarioDto usuario);
        Task<UsuarioDto> ObtenerPorId(int id);
    }
}