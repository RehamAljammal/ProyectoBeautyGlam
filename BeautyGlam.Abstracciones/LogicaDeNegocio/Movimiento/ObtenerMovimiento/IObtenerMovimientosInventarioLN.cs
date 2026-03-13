using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

public interface IObtenerMovimientosInventarioLN
{
    List<MovimientoInventarioDto> ObtenerPorProducto(int idProducto);

    List<MovimientoInventarioDto> ObtenerTodos();
}