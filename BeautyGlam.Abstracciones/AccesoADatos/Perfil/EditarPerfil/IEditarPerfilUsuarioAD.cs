using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Usuario.Perfil
{
    public interface IEditarPerfilUsuarioAD
    {
        Task<int> Editar(UsuarioDto elUsuarioParaGuardar);
        Task<UsuarioDto> ObtenerPorId(int id);
    }
}