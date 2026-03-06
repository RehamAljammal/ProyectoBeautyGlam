using BeautyGlam.Abstracciones.AccesoADatos.Perfil.ListaDePerfil;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.Perfil;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Usuario.Perfil;

namespace BeautyGlam.LogicaDeNegocio.Usuario.Perfil
{
    public class ObtenerPerfilUsuarioLN : IObtenerPerfilUsuarioLN
    {
        private readonly IObtenerPerfilUsuarioAD _obtenerPerfilUsuarioAD;

        public ObtenerPerfilUsuarioLN()
        {
            _obtenerPerfilUsuarioAD = new ObtenerPerfilUsuarioAD();
        }
        public ObtenerPerfilUsuarioLN(IObtenerPerfilUsuarioAD obtenerPerfilUsuarioAD)
        {
            _obtenerPerfilUsuarioAD = obtenerPerfilUsuarioAD;
        }

        public UsuarioDto Obtener(int idUsuario)
        {
            return _obtenerPerfilUsuarioAD.Obtener(idUsuario);
        }
    }
}