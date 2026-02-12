using BeautyGlam.Abstracciones.LogicaDeNegocio.Rol.ListaRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Rol.ListaRol;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Rol.ListaRol
{
    public class ObtenerLaListaDeRolesLN : IObtenerLaListaDeRolesLN
    {
        private readonly ObtenerListaDeRolesAD _ad;

        public ObtenerLaListaDeRolesLN()
        {
            _ad = new ObtenerListaDeRolesAD();
        }

        public List<RolDto> Obtener()
        {
            List<RolDto> lista = _ad.Obtener();
            return lista;
        }
    }
}
