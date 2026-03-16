using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRegistrarDevolucionLN
{
    Task<int> Registrar(DevolucionDto devolucion);
    List<VentaDto> ObtenerPorCliente(int idUsuario);
}