using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

public interface IReporteDevolucionesAD
{
    List<ReporteDevolucionesDto> GenerarReporteDevoluciones(ReporteFiltroDto filtro);
}