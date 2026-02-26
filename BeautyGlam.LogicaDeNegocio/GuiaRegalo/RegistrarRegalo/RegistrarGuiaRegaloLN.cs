using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.RegistrarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.GuiaRegalo.RegistrarGuiaRegalo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.GuiaRegalo.RegistrarGuiaRegalo
{
    public class RegistrarGuiaRegaloLN : IRegistrarGuiaRegaloLN
    {
        private IRegistrarGuiaRegaloAD _registrarGuiaRegaloAD;

        public RegistrarGuiaRegaloLN()
        {
            _registrarGuiaRegaloAD = new RegistrarGuiaRegaloAD();
        }

        public async Task<int> Registrar(GuiaRegaloDto elRegaloParaGuardar)
        {
            return await _registrarGuiaRegaloAD.Registrar(elRegaloParaGuardar);
        }
    }
}
