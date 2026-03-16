using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoDatos
{
    public interface IVentaAD
    {
        List<VentaListadoDto> ObtenerVentas();
        VentaFacturaDto ObtenerVentaCompleta(int id);
    }
}