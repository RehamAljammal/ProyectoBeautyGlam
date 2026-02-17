using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.Movimiento.ListaDeMovimientos
{
    public interface IObtenerListaDeMovimientosLN
    {
        List<MovimientoInventarioDto> Obtener();
    }
}
