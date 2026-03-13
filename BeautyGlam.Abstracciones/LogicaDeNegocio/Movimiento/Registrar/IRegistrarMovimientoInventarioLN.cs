using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

public interface IRegistrarMovimientoInventarioLN
{
    Task<int> Registrar(MovimientoInventarioDto movimiento);
}