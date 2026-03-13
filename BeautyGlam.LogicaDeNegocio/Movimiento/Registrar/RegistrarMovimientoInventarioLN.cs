using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

public class RegistrarMovimientoInventarioLN : IRegistrarMovimientoInventarioLN
{
    private IRegistrarMovimientoInventarioAD _ad;

    public RegistrarMovimientoInventarioLN()
    {
        _ad = new RegistrarMovimientoInventarioAD();
    }

    public async Task<int> Registrar(MovimientoInventarioDto movimiento)
    {
        return await _ad.Registrar(movimiento);
    }
}