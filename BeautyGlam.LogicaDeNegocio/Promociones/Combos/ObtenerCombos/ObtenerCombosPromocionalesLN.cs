using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.Combo;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Promociones.Combo
{
    public class ObtenerCombosPromocionalesLN : IObtenerCombosPromocionalesLN
    {
        private readonly IObtenerCombosPromocionalesAD _acceso;

        public ObtenerCombosPromocionalesLN()
        {
            _acceso = new ObtenerCombosPromocionalesAD();
        }

        public List<ComboPromocionalDTO> Obtener()
        {
            return _acceso.Obtener();
        }
    }
}