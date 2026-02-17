using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStock;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Inventario.EditarInventario
{
    public class EditarStockAD : IEditarStockLN
    {
        private Contexto _elContexto;

        public EditarStockAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> EditarStockMinMax(InventarioDto elInventarioParaGuardar)
        {
            int filasAfectadas = 0;

            InventarioAD inventarioEnBD =
                await _elContexto.Inventario
                .FirstOrDefaultAsync(i => i.id == elInventarioParaGuardar.id);

            if (inventarioEnBD != null)
            {
                inventarioEnBD.stockMinimo = elInventarioParaGuardar.stockMinimo;
                inventarioEnBD.stockMaximo = elInventarioParaGuardar.stockMaximo;
                filasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return filasAfectadas;
        }

        public async Task<InventarioDto> ObtenerPorProducto(int id)
        {
            InventarioAD entidad =
                await _elContexto.Inventario
                .FirstOrDefaultAsync(i => i.id == id);

            if (entidad == null)
                return null;

            return new InventarioDto
            {
                idInventario = entidad.idInventario,
                stockActual = entidad.stockActual,
                stockMinimo = entidad.stockMinimo,
                stockMaximo = entidad.stockMaximo,
                id = entidad.id
            };
        }
    }
}
