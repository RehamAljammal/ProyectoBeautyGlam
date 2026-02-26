using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo
{
    public interface IRegistrarGuiaRegaloLN
    {
        Task<int> Registrar(GuiaRegaloDto elRegaloParaGuardar);
    }
}
