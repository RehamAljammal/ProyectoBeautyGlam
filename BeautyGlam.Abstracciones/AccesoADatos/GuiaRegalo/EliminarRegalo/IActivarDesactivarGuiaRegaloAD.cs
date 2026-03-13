using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ActivarDesactivarGuiaRegalo
{
    public interface IActivarDesactivarGuiaRegaloAD
    {
        Task<int> ActivarDesactivar(GuiaRegaloDto laGuia);
    }
}