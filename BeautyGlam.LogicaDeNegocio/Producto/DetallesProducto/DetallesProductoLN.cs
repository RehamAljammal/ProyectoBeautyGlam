using BeautyGlam.Abstracciones.AccesoADatos.Producto.DetallesProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.DetallesProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.DetallesProducto;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Productos.DetallesDeProducto
{
    public class DetallesProductoLN : IDetallesProductoLN
    {
        private IDetallesProductoAD _detallesProductoAD;

        public DetallesProductoLN()
        {
            _detallesProductoAD = new DetallesProductoAD();
        }

        public async Task<int> Detalles(ProductosDTO elProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas =
                await _detallesProductoAD.Detalles(elProductoParaGuardar);

            return cantidadDeFilasAfectadas;
        }
    }
}
