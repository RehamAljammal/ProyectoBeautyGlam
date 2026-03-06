using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

public interface IReporteLN
{
    List<ReporteVentasDto> GenerarReporteVentas(ReporteFiltroDto filtro);
}