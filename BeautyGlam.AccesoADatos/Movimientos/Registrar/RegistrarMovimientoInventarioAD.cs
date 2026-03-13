using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Threading.Tasks;

public class RegistrarMovimientoInventarioAD : IRegistrarMovimientoInventarioAD
{
    private Contexto _contexto;

    public RegistrarMovimientoInventarioAD()
    {
        _contexto = new Contexto();
    }

    public async Task<int> Registrar(MovimientoInventarioDto dto)
    {
        MovimientoInventarioAD movimiento = new MovimientoInventarioAD
        {
            tipoMovimiento = dto.tipoMovimiento,
            cantidad = dto.cantidad,
            fechaMovimiento = DateTime.Now,
            observacion = dto.observacion,
            idProducto = dto.idProducto
        };

        _contexto.MovimientoInventario.Add(movimiento);

        return await _contexto.SaveChangesAsync();
    }
}