using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo
{
    public interface IAgregarComboPromocionalLN
    {
        Task<int> Agregar(ComboPromocionalDTO combo);
    }
}