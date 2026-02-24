using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo
{
    public interface IAgregarComboPromocionalAD
    {
        Task<int> Agregar(ComboPromocionalDTO combo);
    }
}