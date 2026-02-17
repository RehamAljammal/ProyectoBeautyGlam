using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EliminarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Rol.EliminarRol;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Rol.EliminarRol
{
    public class EliminarRolLN : IEliminarRolLN
    {
        private readonly EliminarRolAD _ad;

        public EliminarRolLN()
        {
            _ad = new EliminarRolAD();
        }

        public async Task<int> Eliminar(RolDto elRolParaGuardar)
        {
            int resultado = await _ad.Eliminar(elRolParaGuardar);
            return resultado;
        }
    }
}
