using BeautyGlam.Abstracciones.AccesoADatos.Usuario.ObtenerUsuarioPorId;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Usuario.ObtenerUsuarioPorId
{
    public class ObtenerUsuarioPorIdAD : IObtenerUsuarioPorIdAD
    {
        private readonly Contexto _elContexto;

        public ObtenerUsuarioPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public UsuarioDto ObtenerPorId(int idDeUsuarioABuscar)
        {
            UsuarioDto elUsuario =
                (from u in _elContexto.Usuario
                 where u.id_Usuario == idDeUsuarioABuscar
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

            return elUsuario;
        }
    }
}
