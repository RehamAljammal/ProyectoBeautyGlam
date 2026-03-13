using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.ActivarDesactivar
{
    public interface IActivarDesactivarOcasionAD
    {
        Task<int> ActivarDesactivar(OcasionDto ocasion);
    }
}