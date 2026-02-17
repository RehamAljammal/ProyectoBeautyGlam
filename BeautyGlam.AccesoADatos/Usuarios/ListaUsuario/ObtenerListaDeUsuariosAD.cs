using BeautyGlam.Abstracciones.AccesoADatos.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Usuario.ListaUsuario
{
    public class ObtenerListaDeUsuariosAD : IObtenerListaDeUsuariosAD
    {
        private readonly Contexto _elContexto;

        public ObtenerListaDeUsuariosAD()
        {
            _elContexto = new Contexto();
        }

        public List<UsuarioDto> Obtener()
        {
            List<UsuarioDto> laLista =
                (from u in _elContexto.Usuario
                 orderby u.fecha_Registro descending
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
                 }).ToList();

            return laLista;
        }
    }
}
