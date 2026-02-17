using BeautyGlam.Abstracciones.AccesoADatos.Usuario.CambiarEstadoUsuario;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Usuario.CambiarEstadoUsuario
{
    public class ActualizarEstadoUsuarioAD : IActualizarEstadoUsuarioAD
    {
        private readonly Contexto _elContexto;

        public ActualizarEstadoUsuarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> ActualizarEstado(int idUsuario, bool nuevoEstado)
        {
            UsuarioAD usuario =
                (from u in _elContexto.Usuario
                 where u.id_Usuario == idUsuario
                 select u).FirstOrDefault();

            if (usuario == null)
            {
                return 0;
            }

            usuario.estado = nuevoEstado;

            int filas = await _elContexto.SaveChangesAsync();
            return filas;
        }
    }
}
