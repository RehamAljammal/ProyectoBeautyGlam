using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Devolucion.Reporte
{
    public class ReporteDevolucionesLN : IReporteDevolucionesLN
    {
        private readonly IReporteDevolucionesAD _ad;

        public ReporteDevolucionesLN(IReporteDevolucionesAD ad)
        {
            _ad = ad;
        }

        public List<ReporteDevolucionesDto> GenerarReporteDevoluciones(ReporteFiltroDto filtro)
        {
            return _ad.GenerarReporteDevoluciones(filtro);
        }
    }
}
