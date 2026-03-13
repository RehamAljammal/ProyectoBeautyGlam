using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ActivarDesactivarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.ActivarDesactivarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.GuiaRegalo.ActivarDesactivarGuiaRegalo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.GuiaRegalo.ActivarDesactivarGuiaRegalo
{
    public class ActivarDesactivarGuiaRegaloLN : IActivarDesactivarGuiaRegaloLN
    {
        private readonly IActivarDesactivarGuiaRegaloAD _activarDesactivarAD;

        public ActivarDesactivarGuiaRegaloLN()
        {
            _activarDesactivarAD = new ActivarDesactivarGuiaRegaloAD();
        }

        public async Task<int> ActivarDesactivar(GuiaRegaloDto guia)
        {
            return await _activarDesactivarAD.ActivarDesactivar(guia);
        }
    }
}