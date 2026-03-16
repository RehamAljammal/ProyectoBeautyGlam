using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

public class ObtenerMovimientosInventarioLN : IObtenerMovimientosInventarioLN
{
    private IObtenerMovimientosInventarioAD _ad;

    public ObtenerMovimientosInventarioLN(IObtenerMovimientosInventarioAD ad)
    {
        _ad = ad;
    }

    public List<MovimientoInventarioDto> ObtenerPorProducto(int idProducto)
    {
        return _ad.ObtenerPorProducto(idProducto);
    }

    public List<MovimientoInventarioDto> ObtenerTodos()
    {
        return _ad.ObtenerTodos();
    }
}