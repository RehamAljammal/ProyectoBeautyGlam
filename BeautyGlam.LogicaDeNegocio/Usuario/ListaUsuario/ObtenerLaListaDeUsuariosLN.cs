using BeautyGlam.Abstracciones.AccesoADatos.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Usuario.ListaUsuario;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Usuario.ListaUsuario
{
    public class ObtenerLaListaDeUsuariosLN : IObtenerLaListaDeUsuariosLN
    {
        private readonly IObtenerListaDeUsuariosAD _ad;

        public ObtenerLaListaDeUsuariosLN()
        {
            _ad = new ObtenerListaDeUsuariosAD();
        }

        public List<UsuarioDto> Obtener()
        {
            List<UsuarioDto> lista = _ad.Obtener();
            return lista;
        }
    }
}
