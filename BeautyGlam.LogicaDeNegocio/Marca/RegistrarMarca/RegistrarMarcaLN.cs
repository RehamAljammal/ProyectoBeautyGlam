using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.RegistrarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marca.RegistrarMarca;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Marca.RegistrarMarca
{
    public class RegistrarMarcaLN : IRegistrarMarcaLN
    {
        private RegistrarMarcaAD _registrarMarcaAD;

        public RegistrarMarcaLN()
        {
            _registrarMarcaAD = new RegistrarMarcaAD();
        }

        public async Task<int> Registrar(MarcaDto laMarcaParaGuardar)
        {
            int cantidadDeFilasAfectas = await _registrarMarcaAD.Registrar(laMarcaParaGuardar);
            return cantidadDeFilasAfectas;
        }

    }
}
