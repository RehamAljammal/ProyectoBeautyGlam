using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Devolucion
{
    public interface IRegistrarDevolucionAD
    {
        Task<int> Registrar(DevolucionDto devolucion);

        List<VentaDto> ObtenerPorCliente(int idUsuario);
    }
}