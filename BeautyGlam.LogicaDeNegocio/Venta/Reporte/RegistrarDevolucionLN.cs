using BeautyGlam.Abstracciones.AccesoADatos.Devolucion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RegistrarDevolucionLN : IRegistrarDevolucionLN
{
    private readonly IRegistrarDevolucionAD _ad;
    private readonly IRegistrarMovimientoInventarioLN _movimientoLN;

    public RegistrarDevolucionLN(IRegistrarDevolucionAD ad, IRegistrarMovimientoInventarioLN movimientoLN)
    {
        _ad = ad;
        _movimientoLN = movimientoLN;
    }

    public async Task<int> Registrar(DevolucionDto devolucion)
    {
        if (devolucion == null)
            throw new Exception("La devolución no puede ser nula.");


        if (string.IsNullOrEmpty(devolucion.motivo))
            throw new Exception("Debe indicar el motivo.");

        MovimientoInventarioDto movimiento = new MovimientoInventarioDto
        {
            idProducto = devolucion.id_Producto,
            tipoMovimiento = "Devolucion",
            cantidad = devolucion.cantidad,
            observacion = devolucion.motivo
        };

        await _movimientoLN.Registrar(movimiento);

        return await _ad.Registrar(devolucion);
    }

    public List<VentaDto> ObtenerPorCliente(int idUsuario)
    {
        return _ad.ObtenerPorCliente(idUsuario);
    }
}