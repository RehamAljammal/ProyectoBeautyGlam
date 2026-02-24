using System.Threading.Tasks;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo
{
    public interface IEditarComboPromocionalAD
    {
        Task<int> Editar(ComboPromocionalDTO combo);
    }
}