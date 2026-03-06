using BeautyGlam.AccesoADatos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Venta.Reporte
{
    public class ReporteAD : IReporteAD
    {
        private readonly Contexto _contexto;

        public ReporteAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<ReporteVentasDto> GenerarReporteVentas(ReporteFiltroDto filtro)
        {
            var query = _contexto.Venta.AsQueryable();

            if (filtro.FechaInicio.HasValue)
            {
                var fechaInicio = filtro.FechaInicio.Value.Date;
                query = query.Where(v => v.fecha_Venta >= fechaInicio);
            }

            if (filtro.FechaFin.HasValue)
            {
                var fechaFin = filtro.FechaFin.Value.Date.AddDays(1);
                query = query.Where(v => v.fecha_Venta < fechaFin);
            }

            return query.Select(v => new ReporteVentasDto
            {
                Fecha = v.fecha_Venta,
                Cliente = v.Usuario.nombre + " " + v.Usuario.apellido,
                Total = v.total
            }).ToList();
        }
    }
}
