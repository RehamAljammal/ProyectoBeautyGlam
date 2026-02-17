using BeautyGlam.Abstracciones.AccesoADatos.Rol.ListaRol;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Rol.ListaRol
{
    public class ObtenerListaDeRolesAD : IObtenerListaDeRolesAD
    {
        private readonly Contexto _elContexto;

        public ObtenerListaDeRolesAD()
        {
            _elContexto = new Contexto();
        }

        public List<RolDto> Obtener()
        {
            List<RolDto> lista =
                (from r in _elContexto.Rol
                 select new RolDto
                 {
                     id_Rol = r.id_Rol,
                     nombre_Rol = r.nombre_Rol,
                     estado = r.estado
                 }).OrderBy(x => x.nombre_Rol).ToList();

            return lista;
        }
    }
}
