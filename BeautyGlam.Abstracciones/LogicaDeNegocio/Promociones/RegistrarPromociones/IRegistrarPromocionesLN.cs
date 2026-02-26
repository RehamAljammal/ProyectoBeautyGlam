using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.RegistrarPromociones
{
    public interface IRegistrarPromocionesLN
    {
        Task<int> Registrar(PromocionesDTO laPromocionParaGuardar);

    }
}
