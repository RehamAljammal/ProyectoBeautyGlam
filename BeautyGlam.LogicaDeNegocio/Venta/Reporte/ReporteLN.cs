using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Venta.Reporte
{
    public class ReporteLN : IReporteLN
    {
        private readonly IReporteAD _reporteAD;

        public ReporteLN(IReporteAD reporteAD)
        {
            _reporteAD = reporteAD;
        }

        public List<ReporteVentasDto> GenerarReporteVentas(ReporteFiltroDto filtro)
        {
            return _reporteAD.GenerarReporteVentas(filtro);
        }
    }
}
