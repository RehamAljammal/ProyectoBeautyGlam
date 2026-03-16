using System.Collections.Generic;
using System.Linq;
using BeautyGlam.Abstracciones.AccesoDatos;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;

public class ListaVentaAD : IVentaAD
{
    private readonly Contexto _contexto;

    public ListaVentaAD(Contexto contexto)
    {
        _contexto = contexto;
    }

    public List<VentaListadoDto> ObtenerVentas()
    {
        return (from v in _contexto.Venta
                join u in _contexto.Usuario on v.id_Usuario equals u.id_Usuario
                join p in _contexto.Pago on v.id_Venta equals p.id_Venta into pagos
                from pago in pagos.DefaultIfEmpty()
                select new VentaListadoDto
                {
                    id_Venta = v.id_Venta,
                    nombreCliente = u.nombre + " " + u.apellido,
                    fecha_Venta = v.fecha_Venta,
                    total = v.total,
                    estado = v.estado,
                    pagado = pago != null && pago.estado == "Pagado"
                }).ToList();
    }

    public VentaFacturaDto ObtenerVentaCompleta(int id)
    {
        var venta = _contexto.Venta
            .Where(v => v.id_Venta == id)
            .Select(v => new VentaFacturaDto
            {
                id_Venta = v.id_Venta,
                fecha = v.fecha_Venta,
                total = v.total,
                estado = v.estado,
                cliente = v.Usuario.nombre,
                metodoPago = v.Pago.FirstOrDefault().metodo_Pago,
                numeroFactura = v.Factura.FirstOrDefault().numero_Factura,
                Detalles = v.Detalle_Venta.Select(d => new DetalleFacturaDto
                {
                    producto = d.Producto.nombre,
                    cantidad = d.cantidad,
                    precio = d.precio,
                    subtotal = d.precio * d.cantidad
                }).ToList()
            })
            .FirstOrDefault();

        return venta;
    }
}