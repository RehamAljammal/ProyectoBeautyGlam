using BeautyGlam.Abstracciones.AccesoADatos.Usuario.EditarUsuario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Usuario.EditarUsuario
{
    public class EditarUsuarioAD : IEditarUsuarioAD
    {
        private readonly Contexto _elContexto;

        public EditarUsuarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<UsuarioDto> ObtenerPorId(int id)
        {
            UsuarioDto usuario =
                (from u in _elContexto.Usuario
                 where u.id_Usuario == id
                 select new UsuarioDto
                 {
                     id_Usuario = u.id_Usuario,
                     nombre = u.nombre,
                     apellido = u.apellido,
                     username = u.username,
                     correo = u.correo,
                     telefono = u.telefono,
                     direccion = u.direccion,
                     fecha_Registro = u.fecha_Registro,
                     rol = u.rol,
                     estado = u.estado
                 }).FirstOrDefault();

            return await Task.FromResult(usuario);
        }

        public async Task<int> Editar(UsuarioDto elUsuarioParaGuardar)
        {
            UsuarioAD usuario =
                (from u in _elContexto.Usuario
                 where u.id_Usuario == elUsuarioParaGuardar.id_Usuario
                 select u).FirstOrDefault();

            if (usuario == null)
            {
                return 0;
            }

            usuario.nombre = elUsuarioParaGuardar.nombre;
            usuario.apellido = elUsuarioParaGuardar.apellido;
            usuario.username = elUsuarioParaGuardar.username;
            usuario.correo = elUsuarioParaGuardar.correo;
            usuario.telefono = elUsuarioParaGuardar.telefono;
            usuario.direccion = elUsuarioParaGuardar.direccion;
            usuario.rol = elUsuarioParaGuardar.rol;
            usuario.estado = elUsuarioParaGuardar.estado;

            int filas = await _elContexto.SaveChangesAsync();
            return filas;
        }
    }
}
