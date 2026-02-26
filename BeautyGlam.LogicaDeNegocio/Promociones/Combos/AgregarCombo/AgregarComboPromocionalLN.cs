using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.Combo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Promociones.Combo
{
    public class AgregarComboPromocionalLN : IAgregarComboPromocionalLN
    {
        private readonly IAgregarComboPromocionalAD _acceso;

        public AgregarComboPromocionalLN()
        {
            _acceso = new AgregarComboPromocionalAD();
        }

        public Task<int> Agregar(ComboPromocionalDTO combo)
        {
            return _acceso.Agregar(combo);
        }
    }
}