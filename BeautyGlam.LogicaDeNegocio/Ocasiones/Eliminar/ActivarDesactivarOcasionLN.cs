using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.ActivarDesactivar;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.ActivarDesactivar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Ocasiones.ActivarDesactivar;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Ocasiones.ActivarDesactivar
{
    public class ActivarDesactivarOcasionLN : IActivarDesactivarOcasionLN
    {
        private readonly IActivarDesactivarOcasionAD _activarDesactivarOcasionAD;

        public ActivarDesactivarOcasionLN()
        {
            _activarDesactivarOcasionAD = new ActivarDesactivarOcasionAD();
        }

        public async Task<int> ActivarDesactivar(OcasionDto ocasion)
        {
            return await _activarDesactivarOcasionAD.ActivarDesactivar(ocasion);
        }
    }
}