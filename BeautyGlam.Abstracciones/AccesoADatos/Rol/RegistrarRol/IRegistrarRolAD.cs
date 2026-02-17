using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Rol.RegistrarRol
{
    public interface IRegistrarRolAD
    {
        Task<int> Registrar(RolDto elRolParaGuardar);
    }
}
