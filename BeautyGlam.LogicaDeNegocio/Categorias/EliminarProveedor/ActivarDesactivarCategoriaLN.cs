using BeautyGlam.Abstracciones.AccesoADatos.Categoria.ActivarDesactivar;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.ActivarDesactivar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.ActivarDesactivar;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Categoria.ActivarDesactivar
{
    public class ActivarDesactivarCategoriaLN : IActivarDesactivarCategoriaLN
    {
        private readonly IActivarDesactivarCategoriaAD _activarDesactivarCategoriaAD;

        public ActivarDesactivarCategoriaLN()
        {
            _activarDesactivarCategoriaAD = new ActivarDesactivarCategoriaAD();
        }

        public async Task<int> ActivarDesactivar(CategoriasDto categoria)
        {
            return await _activarDesactivarCategoriaAD.ActivarDesactivar(categoria);
        }
    }
}