using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo
{
    public interface IEditarComboPromocionalLN
    {
        Task<int> Editar(ComboPromocionalDTO combo);
    }
}
