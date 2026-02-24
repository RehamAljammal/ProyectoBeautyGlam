using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.Combo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Promociones.Combo
{
    public class EditarComboPromocionalLN : IEditarComboPromocionalLN
    {
        private readonly IEditarComboPromocionalAD _acceso;

        public EditarComboPromocionalLN()
        {
            _acceso = new EditarComboPromocionalAD();
        }

        public Task<int> Editar(ComboPromocionalDTO combo)
        {
            return _acceso.Editar(combo);
        }
    }
}