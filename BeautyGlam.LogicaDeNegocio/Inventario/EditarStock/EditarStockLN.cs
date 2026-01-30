using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStock;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Inventario.EditarInventario;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Inventario.EditarStock
{
    public class EditarStockLN : IEditarStockLN
    {
        private EditarStockAD _editarStockAD;

        public EditarStockLN()
        {
            _editarStockAD = new EditarStockAD();
        }

        public async Task<int> EditarStockMinMax(InventarioDto elInventarioParaGuardar)
        {
            int cantidadDeFilasAfectadas =
                await _editarStockAD.EditarStockMinMax(elInventarioParaGuardar);

            return cantidadDeFilasAfectadas;
        }

        public async Task<InventarioDto> ObtenerPorProducto(int id)
        {
            return await _editarStockAD.ObtenerPorProducto(id);
        }
    }
}
