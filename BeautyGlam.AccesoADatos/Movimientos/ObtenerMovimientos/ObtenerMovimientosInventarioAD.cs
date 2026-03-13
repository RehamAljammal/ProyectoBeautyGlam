using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Entidades;
using System.Collections.Generic;
using System.Linq;

public class ObtenerMovimientosInventarioAD : IObtenerMovimientosInventarioAD
{
    private Contexto _contexto;

    public ObtenerMovimientosInventarioAD()
    {
        _contexto = new Contexto();
    }

    public List<MovimientoInventarioDto> ObtenerPorProducto(int idProducto)
    {
        var lista = _contexto.MovimientoInventario
            .Where(m => m.idProducto == idProducto)
            .Select(m => new MovimientoInventarioDto
            {
                idProducto = m.idProducto,
                tipoMovimiento = m.tipoMovimiento,
                cantidad = m.cantidad,
                fechaMovimiento = m.fechaMovimiento,
                observacion = m.observacion
            })
            .OrderByDescending(m => m.fechaMovimiento)
            .ToList();

        return lista;
    }
    public List<MovimientoInventarioDto> ObtenerTodos()
    {
        return _contexto.MovimientoInventario
            .Join(_contexto.Producto,
                m => m.idProducto,
                p => p.id,
                (m, p) => new MovimientoInventarioDto
                {
                    idProducto = m.idProducto,
                    nombreProducto = p.nombre,
                    tipoMovimiento = m.tipoMovimiento,
                    cantidad = m.cantidad,
                    fechaMovimiento = m.fechaMovimiento,
                    observacion = m.observacion
                })
            .OrderByDescending(x => x.fechaMovimiento)
            .ToList();
    }

}