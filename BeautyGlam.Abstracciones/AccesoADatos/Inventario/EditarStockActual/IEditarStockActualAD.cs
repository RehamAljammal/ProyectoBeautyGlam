using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Inventario.EditarStock
{
    public interface IEditarStockActualAD
    {
        Task<int> Editar(InventarioDto stockActualParaGuardar);
    }
}
