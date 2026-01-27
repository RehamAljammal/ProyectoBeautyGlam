using BeautyGlam.Abstracciones.AccesoADatos.Inventario.Movimiento.ListaDeMovimientos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Movimiento.ListaMovimiento
{
    public class ObtenerLaListaDeMovimientosAD : IObtenerMovimientosAD
    {
        private Contexto _elContexto;

        public ObtenerLaListaDeMovimientosAD()
        {
            _elContexto = new Contexto();
        }

        public List<MovimientoInventarioDto> Obtener()
        {
            List<MovimientoInventarioDto> laListaDeMovimientos =
                (from m in _elContexto.Movimiento
                 join p in _elContexto.Producto
                     on m.idProducto equals p.id
                 select new MovimientoInventarioDto
                 {
                     idMovimiento = m.idMovimiento,
                     tipoMovimiento = m.tipoMovimiento,
                     cantidad = m.cantidad,
                     fechaMovimiento = m.fechaMovimiento,
                     observacion = m.observacion,
                     idProducto = p.id,
                     nombre = p.nombre
                 }).ToList();

            return laListaDeMovimientos;
        }
    }
}
