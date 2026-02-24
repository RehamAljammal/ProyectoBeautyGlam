using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo
{
    public interface IObtenerCombosPromocionalesLN
    {
        List<ComboPromocionalDTO> Obtener();
    }
}