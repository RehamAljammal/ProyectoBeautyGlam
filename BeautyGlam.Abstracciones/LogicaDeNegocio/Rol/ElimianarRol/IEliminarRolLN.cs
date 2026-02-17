using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EliminarRol
{
    public interface IEliminarRolLN
    {
        Task<int> Eliminar(RolDto elRolParaGuardar);
    }
}
