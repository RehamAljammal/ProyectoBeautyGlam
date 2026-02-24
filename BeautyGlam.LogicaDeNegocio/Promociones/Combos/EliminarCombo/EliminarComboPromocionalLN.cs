using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.Combo;
using BeautyGlam.AccesoADatos.Promociones.Combo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Promociones.Combo
{
    public class EliminarComboPromocionalLN : IEliminarComboPromocionalLN
    {
        private readonly IEliminarComboPromocionalAD _acceso;

        public EliminarComboPromocionalLN()
        {
            _acceso = new EliminarComboPromocionalAD();
        }

        public Task<int> Eliminar(int idPromocion)
        {
            return _acceso.Eliminar(idPromocion);
        }
    }
}