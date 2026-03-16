using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos;
using BeautyGlam.AccesoADatos.Entidades;
using System.Collections.Generic;
using System.Linq;

public class ObtenerDetalleVentaAD
{
    public List<DetalleVentaDto> ObtenerPorVenta(int idVenta)
    {
        using (var contexto = new Contexto())
        {
            return contexto.DetalleVenta
                .Where(d => d.id_Venta == idVenta)
                .Join(contexto.Producto,
                    d => d.id_Producto,
                    p => p.id,
                    (d, p) => new DetalleVentaDto
                    {
                        id_Producto = d.id_Producto,
                        nombreProducto = p.nombre,
                        cantidad = d.cantidad,
                        precio = d.precio
                    })
                .ToList();
        }
    }
}