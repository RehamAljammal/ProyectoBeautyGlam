using BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Detalle_Compras;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.HistorialCompras.Detalle
{
    public class ObtenerDetalleCompraAD : IObtenerDetalleCompraAD
    {
        private readonly Contexto _elContexto;

        public ObtenerDetalleCompraAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<IEnumerable<DetalleCompraDto>> Obtener(int idVenta)
        {
            var lista =
                from dv in _elContexto.DetalleVenta
                join p in _elContexto.Producto on dv.id_Producto equals p.id
                where dv.id_Venta == idVenta
                select new DetalleCompraDto
                {
                    idProducto = p.id,
                    nombre = p.nombre,
                    cantidad = dv.cantidad,
                    precio = dv.precio,
                    imagen = p.imagen
                };

            return await Task.FromResult(lista.ToList());
        }
    }
}
