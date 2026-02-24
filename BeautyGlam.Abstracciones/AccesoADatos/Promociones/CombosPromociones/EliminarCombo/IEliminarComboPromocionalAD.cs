using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo
{
    public interface IEliminarComboPromocionalAD
    {
        Task<int> Eliminar(int idPromocion);
    }
}