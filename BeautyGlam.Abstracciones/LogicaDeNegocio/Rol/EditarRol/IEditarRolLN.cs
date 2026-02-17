using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EditarRol
{
    public interface IEditarRolLN
    {
        Task<int> Editar(RolDto elRolParaGuardar);
        Task<RolDto> ObtenerPorId(int id);
    }
}
