using BeautyGlam.Abstracciones.AccesoADatos.Modulo.ListaModulo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Modulo.ListaModulo
{
    public class ObtenerListaDeModulosAD : IObtenerListaDeModulosAD
    {
        private readonly Contexto _contexto;

        public ObtenerListaDeModulosAD()
        {
            _contexto = new Contexto();
        }

        public List<ModuloDto> Obtener()
        {
            List<ModuloDto> lista = (from m in _contexto.Modulo
                                     select new ModuloDto
                                     {
                                         id_Modulo = m.id_Modulo,
                                         nombre_Modulo = m.nombre_Modulo,
                                         estado = m.estado
                                     }).ToList();

            return lista;
        }
    }
}