using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

public interface IReporteDevolucionesLN
{
    List<ReporteDevolucionesDto> GenerarReporteDevoluciones(ReporteFiltroDto filtro);
}