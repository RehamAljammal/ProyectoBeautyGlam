using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

public interface IObtenerMovimientosInventarioAD
{
    List<MovimientoInventarioDto> ObtenerPorProducto(int idProducto);

    List<MovimientoInventarioDto> ObtenerTodos();
}