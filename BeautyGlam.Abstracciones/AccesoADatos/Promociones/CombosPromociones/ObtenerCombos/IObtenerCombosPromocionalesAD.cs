using System.Collections.Generic;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo
{
    public interface IObtenerCombosPromocionalesAD
    {
        List<ComboPromocionalDTO> Obtener();
    }
}