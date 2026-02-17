using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.EditarUsuario
{
    public interface IEditarUsuarioLN
    {
        Task<int> Editar(UsuarioDto elUsuarioParaGuardar);
        Task<UsuarioDto> ObtenerPorId(int id);
    }
}
