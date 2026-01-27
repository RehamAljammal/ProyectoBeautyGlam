using BeautyGlam.Abstracciones.AccesoADatos.Inventario.Movimiento.ListaDeMovimientos;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.Movimiento.ListaDeMovimientos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Movimiento.ListaMovimiento;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Inventario.Movimiento.ListaDeMovimientos
{
    public class ObtenerLaListaDeMovimientosLN : IObtenerListaDeMovimientosLN
    {
        private readonly IObtenerMovimientosAD _obtenerMovimientosAD;

        public ObtenerLaListaDeMovimientosLN()
        {
            _obtenerMovimientosAD = new ObtenerLaListaDeMovimientosAD();
        }

        public List<MovimientoInventarioDto> Obtener()
        {
            List<MovimientoInventarioDto> laListaDeMovimientos =
                _obtenerMovimientosAD.Obtener();

            return laListaDeMovimientos;
        }
    }
}
