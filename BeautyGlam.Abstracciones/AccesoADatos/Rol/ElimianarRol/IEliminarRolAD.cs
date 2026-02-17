using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Rol.EliminarRol
{
    public interface IEliminarRolAD
    {
        Task<int> Eliminar(RolDto elRolParaGuardar);
    }
}
