using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.RegistrarRol
{
    public interface IRegistrarRolLN
    {
        Task<int> Registrar(RolDto elRolParaGuardar);
    }
}
