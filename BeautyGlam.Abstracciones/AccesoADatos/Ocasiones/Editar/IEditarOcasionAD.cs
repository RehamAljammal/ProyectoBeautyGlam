using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Editar
{
    public interface IEditarOcasionAD
    {
        Task<int> Editar(OcasionDto ocasion);
    }
}