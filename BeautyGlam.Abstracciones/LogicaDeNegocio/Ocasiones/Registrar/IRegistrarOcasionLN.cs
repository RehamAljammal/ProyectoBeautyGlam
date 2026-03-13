using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.Registrar
{
    public interface IRegistrarOcasionLN
    {
        Task<int> Registrar(OcasionDto ocasion);
    }
}