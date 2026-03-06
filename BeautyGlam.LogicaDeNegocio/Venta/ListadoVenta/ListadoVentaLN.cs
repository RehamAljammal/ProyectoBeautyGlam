using System.Collections.Generic;
using BeautyGlam.Abstracciones.AccesoDatos;
using BeautyGlam.Abstracciones.LogicaNegocio;
using BeautyGlam.Abstracciones.ModelosParaUI;

public class ListadoVentaLN : IVentaLN
{
    private readonly IVentaAD _ventaAD;

    public ListadoVentaLN(IVentaAD ventaAD)
    {
        _ventaAD = ventaAD;
    }

    public List<VentaListadoDto> ObtenerVentas()
    {
        return _ventaAD.ObtenerVentas();
    }

    public VentaFacturaDto ObtenerVentaPorId(int id)
    {
        return _ventaAD.ObtenerVentaCompleta(id);
    }
}
