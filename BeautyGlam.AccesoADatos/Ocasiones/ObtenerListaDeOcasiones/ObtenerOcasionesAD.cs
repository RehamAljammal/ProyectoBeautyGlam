using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Lista;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Ocasiones.Lista
{
    public class ObtenerOcasionesAD : IObtenerOcasionesAD
    {
        private Contexto _contexto;

        public ObtenerOcasionesAD()
        {
            _contexto = new Contexto();
        }

        public List<OcasionDto> Obtener()
        {
            return (from o in _contexto.Ocasiones
                    select new OcasionDto
                    {
                        idOcasion = o.idOcasion,
                        nombre = o.nombre,
                        estado = o.estado
                    }).ToList();
        }
    }
}