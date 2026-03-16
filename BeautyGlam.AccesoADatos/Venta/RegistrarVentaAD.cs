using BeautyGlam.Abstracciones.AccesoADatos.Venta;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Venta
{
    public class RegistrarVentaAD : IRegistrarVentaAD
    {
        private readonly Contexto _contexto;

        public RegistrarVentaAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Registrar(VentaDto venta)
        {
            // ===== Guardar Venta =====
            var entidadVenta = new VentaAD
            {
                id_Usuario = venta.id_Usuario,
                fecha_Venta = DateTime.Now,
                total = venta.total,   
                estado = "Pagado"
            };

            _contexto.Venta.Add(entidadVenta);
            await _contexto.SaveChangesAsync();

            // ===== Guardar Detalle =====
            foreach (var detalle in venta.Detalles)
            {
                var entidadDetalle = new DetalleVentaAD
                {
                    id_Venta = entidadVenta.id_Venta,
                    id_Producto = detalle.id_Producto,
                    cantidad = detalle.cantidad,
                    precio = detalle.precio
                };

                _contexto.DetalleVenta.Add(entidadDetalle);
            }

            await _contexto.SaveChangesAsync();

            // ===== Guardar Pago =====
            var pago = new PagoAD
            {
                id_Venta = entidadVenta.id_Venta,
                metodo_Pago = venta.Pago.metodo_Pago,
                monto = entidadVenta.total,
                fecha_Pago = DateTime.Now,
                estado = "Pagado"
            };

            _contexto.Pago.Add(pago);
            await _contexto.SaveChangesAsync();

            // ===== Generar Factura =====
            var numeroFactura = $"FAC-{entidadVenta.id_Venta.ToString("D4")}";

            var factura = new FacturaAD
            {
                id_Venta = entidadVenta.id_Venta,
                numero_Factura = numeroFactura,
                fecha_Emision = DateTime.Now
            };

            _contexto.Factura.Add(factura);
            await _contexto.SaveChangesAsync();

            return entidadVenta.id_Venta;
        }
    }
}