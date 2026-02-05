using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Inventario.Movimiento.ListaDeMovimientos
{
    public interface IObtenerMovimientosAD
    {
        List<MovimientoInventarioDto> Obtener();

    }
}
