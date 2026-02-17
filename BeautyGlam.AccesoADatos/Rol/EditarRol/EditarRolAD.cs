using BeautyGlam.Abstracciones.AccesoADatos.Rol.EditarRol;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.EditarRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Rol.EditarRol
{
    public class EditarRolAD : IEditarUsuarioAD
    {
        private readonly Contexto _elContexto;

        public EditarRolAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<RolDto> ObtenerPorId(int id)
        {
            RolDto rol =
                (from r in _elContexto.Rol
                 where r.id_Rol == id
                 select new RolDto
                 {
                     id_Rol = r.id_Rol,
                     nombre_Rol = r.nombre_Rol,
                     estado = r.estado
                 }).FirstOrDefault();

            return await Task.FromResult(rol);
        }

        public async Task<int> Editar(RolDto elRolParaGuardar)
        {
            RolAD rol = _elContexto.Rol.FirstOrDefault(x => x.id_Rol == elRolParaGuardar.id_Rol);
            if (rol == null) return 0;

            rol.nombre_Rol = elRolParaGuardar.nombre_Rol;
            rol.estado = elRolParaGuardar.estado;

            int resultado = await _elContexto.SaveChangesAsync();
            return resultado;
        }
    }
}
