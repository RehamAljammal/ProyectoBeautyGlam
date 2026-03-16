using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

public interface IRegistrarMovimientoInventarioAD
{
    Task<int> Registrar(MovimientoInventarioDto movimiento);
}