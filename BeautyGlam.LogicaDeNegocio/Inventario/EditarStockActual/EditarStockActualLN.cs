using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStockActual;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Inventario.EditarInventario;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Inventario.EditarStockActual
{
    public class EditarStockActualLN : IEditarStockActualLN
    {
        private EditarStockActualAD _editarStockActualAD;
        private IRegistrarMovimientoInventarioLN _movimientoLN;

        public EditarStockActualLN()
        {
            _editarStockActualAD = new EditarStockActualAD();
            _movimientoLN = new RegistrarMovimientoInventarioLN();
        }

        public async Task<int> Editar(InventarioDto elInventarioParaGuardar)
        {
            InventarioDto inventarioEnBD =
                await _editarStockActualAD.ObtenerPorProducto(elInventarioParaGuardar.id);

            if (inventarioEnBD == null)
                return -1;

            if (elInventarioParaGuardar.stockActual < inventarioEnBD.stockMinimo)
                return -2;

            if (elInventarioParaGuardar.stockActual > inventarioEnBD.stockMaximo)
                return -3;

            int diferencia = elInventarioParaGuardar.stockActual - inventarioEnBD.stockActual;

            if (diferencia != 0)
            {
                MovimientoInventarioDto movimiento = new MovimientoInventarioDto
                {
                    idProducto = elInventarioParaGuardar.id,
                    tipoMovimiento = diferencia > 0 ? "Ingreso" : "Ajuste",
                    cantidad = diferencia,
                    observacion = "Actualización de inventario"
                };

                await _movimientoLN.Registrar(movimiento);
            }

            return await _editarStockActualAD.Editar(elInventarioParaGuardar);
        }

        public async Task<InventarioDto> ObtenerPorProducto(int id)
        {
            return await _editarStockActualAD.ObtenerPorProducto(id);
        }
    }
}
