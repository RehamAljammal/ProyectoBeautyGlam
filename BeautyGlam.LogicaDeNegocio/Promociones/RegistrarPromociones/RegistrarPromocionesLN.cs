using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.RegistrarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.RegistrarPromociones;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Promociones.RegistrarPromociones
{
    public class RegistrarPromocionesLN : IRegistrarPromocionesLN
    {
        private IRegistrarPromocionesLN _registrarPromocionesAD;

        public RegistrarPromocionesLN()
        {
            _registrarPromocionesAD = new RegistrarPromocionesAD();
        }

        public async Task<int> Registrar(PromocionesDTO laPromocionParaGuardar)
        {
            int cantidadDeFilasAfectas =
                await _registrarPromocionesAD.Registrar(laPromocionParaGuardar);

            return cantidadDeFilasAfectas;
        }
    }
}

