using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaNegocio
{
    public interface IVentaLN
    {
        List<VentaListadoDto> ObtenerVentas();

        VentaFacturaDto ObtenerVentaPorId(int id);
    }
}
