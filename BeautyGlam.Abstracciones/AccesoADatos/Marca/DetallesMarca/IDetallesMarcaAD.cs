using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Marca.DetallesMarca
{
    public interface IDetallesMarcaAD
    {
        Task<int> Detalles(MarcaDto laMarcaParaGuardar);

    }
}
