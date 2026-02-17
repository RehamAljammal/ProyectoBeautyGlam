using BeautyGlam.Abstracciones.AccesoADatos.Usuario.CambiarEstadoUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.CambiarEstadoUsuario;
using BeautyGlam.AccesoADatos.Usuario.CambiarEstadoUsuario;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Usuario.CambiarEstadoUsuario
{
    public class ActualizarEstadoUsuarioLN : IActualizarEstadoUsuarioLN
    {
        private readonly IActualizarEstadoUsuarioAD _ad;

        public ActualizarEstadoUsuarioLN()
        {
            _ad = new ActualizarEstadoUsuarioAD();
        }

        public async Task<int> ActualizarEstado(int idUsuario, bool nuevoEstado)
        {
            int filas = await _ad.ActualizarEstado(idUsuario, nuevoEstado);
            return filas;
        }
    }
}
