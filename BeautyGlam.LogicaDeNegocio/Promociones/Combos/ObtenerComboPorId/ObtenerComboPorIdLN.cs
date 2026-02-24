using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.Combo;

namespace BeautyGlam.LogicaDeNegocio.Promociones.Combo
{
    public class ObtenerComboPorIdLN : IObtenerComboPorIdLN
    {
        private readonly ObtenerComboPorIdAD _acceso;

        public ObtenerComboPorIdLN()
        {
            _acceso = new ObtenerComboPorIdAD();
        }

        public ComboPromocionalDTO ObtenerPorId(int idPromocion)
        {
            return _acceso.ObtenerPorId(idPromocion);
        }
    }
}