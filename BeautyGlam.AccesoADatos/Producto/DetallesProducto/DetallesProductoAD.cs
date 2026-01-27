using BeautyGlam.Abstracciones.AccesoADatos.Producto.DetallesProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Producto.DetallesProducto
{
    public class DetallesProductoAD : IDetallesProductoAD
    {
        private readonly Contexto _elContexto;

        public DetallesProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Detalles(ProductosDTO laProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            ProductoAD laProductoEnBaseDeDatos = _elContexto.Producto
                .FirstOrDefault(ProductoABuscar => ProductoABuscar.id == laProductoParaGuardar.id);

            return cantidadDeFilasAfectadas;
        }
    }
}