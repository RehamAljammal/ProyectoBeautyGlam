using BeautyGlam.Abstracciones.AccesoADatos.Marca.ActivarDesactivar;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.EliminarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marcaes.ActivarDesactivar;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Marca.ActivarDesactivar
{
    public class ActivarDesactivarMarcaLN : IActivarDesactivarMarcaLN
    {
        private readonly IActivarDesactivarMarcaAD _activarDesactivarMarcaAD;

        public ActivarDesactivarMarcaLN()
        {
            _activarDesactivarMarcaAD = new ActivarDesactivarMarcaAD();
        }

        public async Task<int> ActivarDesactivar(MarcaDto marca)
        {
            return await _activarDesactivarMarcaAD.ActivarDesactivar(marca);
        }
    }
}