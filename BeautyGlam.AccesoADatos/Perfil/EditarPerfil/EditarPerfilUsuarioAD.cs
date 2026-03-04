using BeautyGlam.Abstracciones.AccesoADatos.Usuario.Perfil;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Usuario.Perfil
{
    public class EditarPerfilUsuarioAD : IEditarPerfilUsuarioAD
    {
        private Contexto _elContexto;

        public EditarPerfilUsuarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(UsuarioDto elUsuarioParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            UsuarioAD elUsuarioEnBaseDeDatos = await _elContexto.Usuario
                .FirstOrDefaultAsync(u => u.id_Usuario == elUsuarioParaGuardar.id_Usuario);

            if (elUsuarioEnBaseDeDatos != null)
            {
                elUsuarioEnBaseDeDatos.nombre = elUsuarioParaGuardar.nombre;
                elUsuarioEnBaseDeDatos.apellido = elUsuarioParaGuardar.apellido;
                elUsuarioEnBaseDeDatos.correo = elUsuarioParaGuardar.correo;
                elUsuarioEnBaseDeDatos.direccion = elUsuarioParaGuardar.direccion;
                elUsuarioEnBaseDeDatos.telefono = elUsuarioParaGuardar.telefono;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        public async Task<UsuarioDto> ObtenerPorId(int id)
        {
            UsuarioAD entidad = await _elContexto.Usuario
                                    .FirstOrDefaultAsync(u => u.id_Usuario == id);

            if (entidad == null)
                return null;

            return new UsuarioDto
            {
                id_Usuario = entidad.id_Usuario,
                nombre = entidad.nombre,
                apellido = entidad.apellido,
                correo = entidad.correo,
                direccion = entidad.direccion,
                telefono = entidad.telefono,
                estado = entidad.estado
            };
        }
    }
}