using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.RegistrarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.RegistrarCategoria;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Categorias.RegistrarCategoria
{
    public class RegistrarCategoriaLN : IRegistrarCategoriaLN
    {
        private IRegistrarCategoriaLN _registrarCategoriaAD;

        public RegistrarCategoriaLN()
        {
            _registrarCategoriaAD = new RegistrarCategoriaAD();
        }

        public async Task<int> Registrar(CategoriasDto elCategoriaParaGuardar)
        {
            int cantidadDeFilasAfectas = await _registrarCategoriaAD.Registrar(elCategoriaParaGuardar);
            return cantidadDeFilasAfectas;
        }

    }
}

