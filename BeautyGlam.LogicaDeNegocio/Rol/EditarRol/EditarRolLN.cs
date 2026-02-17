using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EditarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Rol.EditarRol;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Rol.EditarRol
{
    public class EditarRolLN : IEditarRolLN
    {
        private readonly EditarRolAD _ad;

        public EditarRolLN()
        {
            _ad = new EditarRolAD();
        }

        public async Task<RolDto> ObtenerPorId(int id)
        {
            RolDto rol = await _ad.ObtenerPorId(id);
            return rol;
        }

        public async Task<int> Editar(RolDto elRolParaGuardar)
        {
            int resultado = await _ad.Editar(elRolParaGuardar);
            return resultado;
        }
    }
}
