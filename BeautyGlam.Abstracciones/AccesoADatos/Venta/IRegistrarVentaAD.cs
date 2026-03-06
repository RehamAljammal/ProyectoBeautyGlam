using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Venta
{
    public interface IRegistrarVentaAD
    {
        Task<int> Registrar(VentaDto venta);
    }
}
