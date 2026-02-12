using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Rol.EditarRol
{
    public interface IEditarRolAD
    {
        Task<int> Editar(RolDto elRolParaGuardar);
        Task<RolDto> ObtenerPorId(int id);
    }
}
