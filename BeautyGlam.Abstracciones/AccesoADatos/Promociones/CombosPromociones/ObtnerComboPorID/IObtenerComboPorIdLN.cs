using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo
{
    public interface IObtenerComboPorIdLN
    {
        ComboPromocionalDTO ObtenerPorId(int idPromocion);
    }
}
