using BeautyGlam.Abstracciones.LogicaDeNegocio.Producto.EditarProducto;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Producto.EditarProducto;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Productos.EditarProductos
{
    public class EditarProductoLN : IEditarProductoLN
    {
        private EditarProductoAD _editarProductoAD;

        public EditarProductoLN()
        {
            _editarProductoAD = new EditarProductoAD();
        }

        public async Task<int> Editar(ProductosDTO elProductoParaGuardar)
        {
            int cantidadDeFilasAfectadas =
                await _editarProductoAD.Editar(elProductoParaGuardar);

            return cantidadDeFilasAfectadas;
        }

        public async Task<ProductosDTO> ObtenerPorId(int id)
        {
            return await _editarProductoAD.ObtenerPorId(id);
        }
    }
}
