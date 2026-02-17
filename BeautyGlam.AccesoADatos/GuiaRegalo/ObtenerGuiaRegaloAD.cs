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
                    select new GuiaRegaloDto
                    {
                        idGuia = g.idGuia,
                        categoria = g.categoria,
                        presupuesto = g.presupuesto,
                        genero = g.genero,
                        tipo = g.tipo,
                        estado = g.estado,

                        // RELACIÓN CON GUIA_PRODUCTO
                        productosSeleccionados =
                            g.GuiaProducto
                             .Select(x => x.id)
                             .ToList()
                    }).ToList();
        }
    }
}


