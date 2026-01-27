using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.EditarStock
{
    public interface IEditarStockLN
    {

        Task<int> EditarStockMinMax(InventarioDto stockParaGuardar);
        Task<InventarioDto> ObtenerPorProducto(int idProducto);

    }
}
