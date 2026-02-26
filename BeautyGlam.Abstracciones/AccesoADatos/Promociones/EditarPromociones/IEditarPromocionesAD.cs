using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promocion.EditarPromocion
{
    public interface IEditarPromocionesAD
    {
        Task<int> Editar(PromocionesDTO laPromocionParaGuardar);
        Task<PromocionesDTO> ObtenerPorId(int id);
    }
}
