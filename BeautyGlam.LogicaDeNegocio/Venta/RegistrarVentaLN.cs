using BeautyGlam.Abstracciones.AccesoADatos.Producto.ListaProducto;
using BeautyGlam.Abstracciones.AccesoADatos.Usuario.ListaUsuario;
using BeautyGlam.Abstracciones.AccesoADatos.Venta;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RegistrarVentaLN : IRegistrarVentaLN
{
    private readonly IRegistrarVentaAD _registrarVentaAD;
    private readonly IObtenerListaDeUsuariosAD _obtenerListaDeUsuariosAD;
    private readonly IObtenerListaDeProductosAD _obtenerListaDeProductosAD;
    private readonly IRegistrarMovimientoInventarioLN _movimientoLN;

    public RegistrarVentaLN(IRegistrarVentaAD registrarVentaAD, IObtenerListaDeUsuariosAD usuarioAD, IObtenerListaDeProductosAD productoAD, IRegistrarMovimientoInventarioLN movimientoLN)
    {
        _registrarVentaAD = registrarVentaAD;
        _obtenerListaDeUsuariosAD = usuarioAD;
        _obtenerListaDeProductosAD = productoAD;
        _movimientoLN = movimientoLN;
    }

    public async Task<int> Registrar(VentaDto venta)
    {
        if (venta == null)
            throw new Exception("La venta no puede ser nula.");

        if (venta.VentaItems == null || !venta.VentaItems.Any())
            throw new Exception("Debe agregar al menos un producto.");

        if (venta.Pago == null)
            throw new Exception("Debe seleccionar un método de pago.");

        venta.Detalles = venta.VentaItems.Select(x => new DetalleVentaDto
        {
            id_Producto = x.id_Producto,
            cantidad = x.cantidad,
            precio = x.precio
        }).ToList();

        venta.total = venta.Detalles.Sum(d => d.precio * d.cantidad);

        foreach (var item in venta.VentaItems)
        {
            MovimientoInventarioDto movimiento = new MovimientoInventarioDto
            {
                idProducto = item.id_Producto,
                tipoMovimiento = "Venta",
                cantidad = -item.cantidad,
                observacion = "Venta realizada"
            };

            await _movimientoLN.Registrar(movimiento);
        }

        return await _registrarVentaAD.Registrar(venta);
    }

    public List<UsuarioDto> ObtenerClientesActivos()
    {
        var usuarios = _obtenerListaDeUsuariosAD.Obtener();

        return usuarios
            .Where(u => u.estado && u.rol == "Usuario")
            .ToList();
    }

    public List<ProductosDTO> ObtenerProductosActivos()
    {
        var productos = _obtenerListaDeProductosAD.Obtener();

        return productos
            .Where(p => p.estado == true)
            .ToList();
    }
}