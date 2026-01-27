using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStockActual
{
    public interface IEditarStockActualLN
    {
        Task<int> Editar(InventarioDto stockActualParaGuardar);
        Task<InventarioDto> ObtenerPorProducto(int idProducto);

    }
}
