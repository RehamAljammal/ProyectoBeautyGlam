using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.EditarUsuario
{
    public interface IEditarUsuarioAD
    {
        Task<int> Editar(UsuarioDto elUsuarioParaGuardar);
        Task<UsuarioDto> ObtenerPorId(int id);
    }
}
