using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.RegistrarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Rol.RegistrarRol;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Rol.RegistrarRol
{
    public class RegistrarRolLN : IRegistrarRolLN
    {
        private readonly RegistrarRolAD _ad;

        public RegistrarRolLN()
        {
            _ad = new RegistrarRolAD();
        }

        public async Task<int> Registrar(RolDto elRolParaGuardar)
        {
            int resultado = await _ad.Registrar(elRolParaGuardar);
            return resultado;
        }
    }
}
