using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo
{
    public interface IEliminarComboPromocionalLN
    {
        Task<int> Eliminar(int idPromocion);
    }
}
