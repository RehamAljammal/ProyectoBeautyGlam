using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Tono.CrearTono
{
    public interface ICrearTonoAD
    {
        Task<int> Crear(TonoDTO tonoParaGuardar);
    }
}