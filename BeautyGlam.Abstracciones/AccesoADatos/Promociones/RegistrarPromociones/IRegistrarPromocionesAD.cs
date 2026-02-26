using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promocion.AgregarPromocion
{
    internal interface IRegistrarPromocionesAD
    {
        Task<int> Guardar(PromocionesDTO laPromocionParaGuardar);
    }
}
