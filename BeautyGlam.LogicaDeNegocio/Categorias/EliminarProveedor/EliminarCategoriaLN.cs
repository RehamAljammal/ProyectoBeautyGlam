using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EliminarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.EliminarCategoria;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Categorias.EliminarCategoria
{
    public class EliminarCategoriaLN : IEliminarCategoriaLN
    {
        private EliminarCategoriaAD _eliminarCategoriaAD;

        public EliminarCategoriaLN()
        {
            _eliminarCategoriaAD = new EliminarCategoriaAD();
        }

        public async Task<int> Eliminar(CategoriasDto elCategoriaParaGuardar)
        {

            int cantidadDeFilasAfectas = await _eliminarCategoriaAD.Eliminar(elCategoriaParaGuardar);
            return cantidadDeFilasAfectas;
        }
    }
}


