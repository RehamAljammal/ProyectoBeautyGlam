using BeautyGlam.Abstracciones.AccesoADatos.Devolucion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Devolucion
{
    public class ListaDevolucionAD : IListaDevolucionAD
    {
        private readonly Contexto _contexto;

        public ListaDevolucionAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<DevolucionListadoDto> Obtener()
        {
            return _contexto.Devolucion
                .Select(d => new DevolucionListadoDto
                {
                    id_Devolucion = d.id_Devolucion,
                    motivo = d.motivo,
                    observacion = d.observacion,
                    admin = d.Admin.nombre,
                    fecha = d.fecha_Devolucion,
                    estado = d.estado
                })
                .OrderByDescending(d => d.fecha)
                .ToList();
        }
    }
}
