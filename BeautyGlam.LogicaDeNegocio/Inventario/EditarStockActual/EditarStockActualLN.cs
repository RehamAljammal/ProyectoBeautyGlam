using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStockActual;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Inventario.EditarInventario;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Inventario.EditarStockActual
{
    public class EditarStockActualLN : IEditarStockActualLN
    {
        private EditarStockActualAD _editarStockActualAD;

        public EditarStockActualLN()
        {
            _editarStockActualAD = new EditarStockActualAD();
        }

        public async Task<int> Editar(InventarioDto elInventarioParaGuardar)
        {
            // Obtener inventario actual de BD
            InventarioDto inventarioEnBD =
                await _editarStockActualAD.ObtenerPorProducto(elInventarioParaGuardar.idProducto);

            if (inventarioEnBD == null)
                return -1; 

            // VALIDACIONES
            if (elInventarioParaGuardar.stockActual < inventarioEnBD.stockMinimo)
                return -2; 

            if (elInventarioParaGuardar.stockActual > inventarioEnBD.stockMaximo)
                return -3; 

            // Si pasa validaciones, guardar
            return await _editarStockActualAD.Editar(elInventarioParaGuardar);
        }

        public async Task<InventarioDto> ObtenerPorProducto(int idProducto)
        {
            return await _editarStockActualAD.ObtenerPorProducto(idProducto);
        }
    }
}
