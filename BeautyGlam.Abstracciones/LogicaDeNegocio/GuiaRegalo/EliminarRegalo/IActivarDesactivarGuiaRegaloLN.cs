using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.ActivarDesactivarGuiaRegalo
{
    public interface IActivarDesactivarGuiaRegaloLN
    {
        Task<int> ActivarDesactivar(GuiaRegaloDto laGuia);
    }
}