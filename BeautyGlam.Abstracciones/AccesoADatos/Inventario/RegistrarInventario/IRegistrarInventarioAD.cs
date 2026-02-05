using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Inventario
{
    public interface IRegistrarInventarioAD
    {
        Task Registrar(InventarioDto inventario);
    }
}
