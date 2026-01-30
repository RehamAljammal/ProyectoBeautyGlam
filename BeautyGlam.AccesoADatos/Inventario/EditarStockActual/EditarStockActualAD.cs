using BeautyGlam.Abstracciones.AccesoADatos.Inventario.EditarStock;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Inventario.EditarInventario
{
    public class EditarStockActualAD : IEditarStockActualAD
    {
        private Contexto _elContexto;

        public EditarStockActualAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(InventarioDto elInventarioParaGuardar)
        {
            int filasAfectadas = 0;

            InventarioAD inventarioEnBD =
                await _elContexto.Inventario
                .FirstOrDefaultAsync(i => i.id == elInventarioParaGuardar.id);

            if (inventarioEnBD != null)
            {
                inventarioEnBD.stockActual = elInventarioParaGuardar.stockActual;
                filasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return filasAfectadas;
        }
        public async Task<InventarioDto> ObtenerPorProducto(int id)
        {
            InventarioAD inventario =
                await _elContexto.Inventario
                    .FirstOrDefaultAsync(i => i.id == id);

            if (inventario == null)
                return null;

            ProductoAD producto =
                await _elContexto.Producto
                    .FirstOrDefaultAsync(p => p.id == id);

            if (producto == null)
                return null;

            InventarioDto dto = new InventarioDto
            {
                idInventario = inventario.idInventario,
                id = inventario.id,
                nombre = producto.nombre,
                stockActual = inventario.stockActual,
                stockMinimo = inventario.stockMinimo,
                stockMaximo = inventario.stockMaximo
            };

            return dto;
        }
    }
}
