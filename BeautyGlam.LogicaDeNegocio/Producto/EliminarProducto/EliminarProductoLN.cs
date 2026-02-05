using BeautyGlam.Abstracciones.AccesoADatos.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EliminarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.EliminarProducto;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Productos.EliminarProducto
{
    public class EliminarProductoLN : IEliminarProductoLN
    {
        private EliminarProductoAD _eliminarProductoAD;

        public EliminarProductoLN()
        {
            _eliminarProductoAD = new EliminarProductoAD();
        }

        public async Task<int> Eliminar(ProductosDTO elProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas =
                await _eliminarProductoAD.Eliminar(elProductoParaGuardar);

            return cantidadDeFilasAfectadas;
        }
    }
}
