using BeautyGlam.Abstracciones.AccesoADatos.Rol.EliminarRol;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EliminarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Rol.EliminarRol
{
    public class EliminarRolAD : IEliminarRolAD
    {
        private readonly Contexto _elContexto;

        public EliminarRolAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(RolDto elRolParaGuardar)
        {
            RolAD rol = _elContexto.Rol.FirstOrDefault(x => x.id_Rol == elRolParaGuardar.id_Rol);
            if (rol == null) return 0;

            rol.estado = false; // soft delete

            int resultado = await _elContexto.SaveChangesAsync();
            return resultado;
        }
    }
}
