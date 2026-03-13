using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.Editar
{
    public interface IEditarOcasionLN
    {
        Task<int> Editar(OcasionDto ocasion);
    }
}