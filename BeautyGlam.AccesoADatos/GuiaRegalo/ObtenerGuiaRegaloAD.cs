using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.Lista;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.GuiaRegalo.Lista
{
    public class ObtenerGuiaRegaloAD : IObtenerGuiaRegaloAD
    {
        private Contexto _contexto;

        public ObtenerGuiaRegaloAD()
        {
            _contexto = new Contexto();
        }

        public List<GuiaRegaloDto> Obtener()
        {
            return (from g in _contexto.GuiaRegalo
                    join o in _contexto.Ocasiones
                        on g.idOcasion equals o.idOcasion
                    join c in _contexto.Categoria
                        on g.id equals c.id

                    select new GuiaRegaloDto
                    {
                        idGuia = g.idGuia,
                        idOcasion = g.idOcasion,
                        nombreOcasion = o.nombre,
                        id = c.id,
                        nombreCategoria = c.nombre,
                        presupuesto = g.presupuesto,
                        genero = g.genero,
                        estado = g.estado,
                        productosSeleccionados = g.GuiaProducto
                                                   .Select(x => x.id)
                                                   .ToList()
                    }).ToList();
        }
    }
}


