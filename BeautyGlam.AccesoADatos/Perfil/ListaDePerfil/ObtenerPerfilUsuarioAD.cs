using BeautyGlam.Abstracciones.AccesoADatos.Perfil.ListaDePerfil;
using BeautyGlam.Abstracciones.AccesoADatos.Usuario.Perfil;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Usuario.Perfil
{
    public class ObtenerPerfilUsuarioAD : IObtenerPerfilUsuarioAD
    {
        private Contexto _elContexto;

        public ObtenerPerfilUsuarioAD()
        {
            _elContexto = new Contexto();
        }

        public UsuarioDto Obtener(int idUsuario)
        {
            UsuarioDto elUsuario =
                (from usuario in _elContexto.Usuario
                 where usuario.id_Usuario == idUsuario
                 select new UsuarioDto
                 {
                     id_Usuario = usuario.id_Usuario,
                     nombre = usuario.nombre,
                     apellido = usuario.apellido,
                     correo = usuario.correo,
                     direccion = usuario.direccion,
                     telefono = usuario.telefono,
                     estado = usuario.estado
                 }).FirstOrDefault();

            return elUsuario;
        }
    }
}