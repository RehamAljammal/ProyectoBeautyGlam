using BeautyGlam.Abstracciones.AccesoADatos.Rol.RegistrarRol;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.RegistrarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Rol.RegistrarRol
{
    public class RegistrarRolAD : IRegistrarRolAD
    {
        private readonly Contexto _elContexto;

        public RegistrarRolAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(RolDto elRolParaGuardar)
        {
            RolAD entidad = new RolAD();
            entidad.nombre_Rol = elRolParaGuardar.nombre_Rol;
            entidad.estado = elRolParaGuardar.estado;

            _elContexto.Rol.Add(entidad);

            int resultado = await _elContexto.SaveChangesAsync();
            return resultado;
        }
    }
}
