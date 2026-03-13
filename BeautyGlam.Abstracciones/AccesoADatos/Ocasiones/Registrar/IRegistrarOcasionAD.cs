using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Registrar
{
    public interface IRegistrarOcasionAD
    {
        Task<int> Registrar(OcasionDto ocasion);
    }
}