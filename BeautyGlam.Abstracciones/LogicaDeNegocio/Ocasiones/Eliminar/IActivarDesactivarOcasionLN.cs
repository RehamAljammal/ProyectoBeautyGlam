using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.ActivarDesactivar
{
    public interface IActivarDesactivarOcasionLN
    {
        Task<int> ActivarDesactivar(OcasionDto ocasion);
    }
}