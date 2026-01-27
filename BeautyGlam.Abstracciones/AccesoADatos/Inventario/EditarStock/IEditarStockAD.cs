using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Inventario.EditarStock
{
    public interface IEditarStockAD
    {
        Task<int> Editar(InventarioDto stockParaGuardar);
    }
}
