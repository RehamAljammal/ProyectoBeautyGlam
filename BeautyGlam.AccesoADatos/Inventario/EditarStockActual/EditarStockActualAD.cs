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
                .FirstOrDefaultAsync(i => i.idProducto == elInventarioParaGuardar.idProducto);

            if (inventarioEnBD != null)
            {
                inventarioEnBD.stockActual = elInventarioParaGuardar.stockActual;
                filasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return filasAfectadas;
        }

        public async Task<InventarioDto> ObtenerPorProducto(int idProducto)
        {
            InventarioAD entidad =
                await _elContexto.Inventario
                .FirstOrDefaultAsync(i => i.idProducto == idProducto);

            if (entidad == null)
                return null;

            return new InventarioDto
            {
                idInventario = entidad.idInventario,
                stockActual = entidad.stockActual,
                stockMinimo = entidad.stockMinimo,
                stockMaximo = entidad.stockMaximo,
                idProducto = entidad.idProducto
            };
        }
    }
}
