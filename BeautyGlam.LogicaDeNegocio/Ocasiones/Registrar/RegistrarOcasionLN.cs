using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Registrar;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.Registrar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Ocasiones.Registrar;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Ocasiones.Registrar
{
    public class RegistrarOcasionLN : IRegistrarOcasionLN
    {
        private readonly IRegistrarOcasionAD _ad;

        public RegistrarOcasionLN()
        {
            _ad = new RegistrarOcasionAD();
        }

        public async Task<int> Registrar(OcasionDto ocasion)
        {
            return await _ad.Registrar(ocasion);
        }
    }
}