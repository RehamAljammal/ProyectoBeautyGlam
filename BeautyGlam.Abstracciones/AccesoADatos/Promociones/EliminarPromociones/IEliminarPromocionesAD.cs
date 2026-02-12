using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promocion.DesactivarPromocion
{
    public interface IEliminarPromocionesAD
    {
        Task<int> Eliminar(PromocionesDTO laPromocionParaGuardar);

    }
}
