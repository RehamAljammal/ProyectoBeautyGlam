using BeautyGlam.AccesoADatos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Devolucion.Reporte
{
    public class ReporteDevolucionesAD : IReporteDevolucionesAD
    {
        private readonly Contexto _contexto;

        public ReporteDevolucionesAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<ReporteDevolucionesDto> GenerarReporteDevoluciones(ReporteFiltroDto filtro)
        {
            var query = _contexto.Devolucion.AsQueryable();

            if (filtro.FechaInicio.HasValue)
            {
                var fi = filtro.FechaInicio.Value.Date;
                query = query.Where(d => d.fecha_Devolucion >= fi);
            }

            if (filtro.FechaFin.HasValue)
            {
                var ff = filtro.FechaFin.Value.Date.AddDays(1);
                query = query.Where(d => d.fecha_Devolucion < ff);
            }

            var reporte = query
                .Select(d => new ReporteDevolucionesDto
                {
                    Fecha = d.fecha_Devolucion,
                    Admin = d.Admin.nombre + " " + d.Admin.apellido,
                    Venta = d.id_Venta ?? 0
                })
                .ToList();

            return reporte;
        }
    }
    }