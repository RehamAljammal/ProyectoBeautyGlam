using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

public interface IReporteAD
{
    List<ReporteVentasDto> GenerarReporteVentas(ReporteFiltroDto filtro);
}