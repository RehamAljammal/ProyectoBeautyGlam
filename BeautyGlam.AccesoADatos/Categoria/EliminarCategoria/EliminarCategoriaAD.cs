using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EliminarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Categoria.EliminarCategoria
{
    public class EliminarCategoriaAD : IEliminarCategoriaLN
    {
        private readonly Contexto _elContexto;

        public EliminarCategoriaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(CategoriasDto laCategoriaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            CategoriaAD laCategoriaEnBaseDeDatos = _elContexto.Categoria
                .FirstOrDefault(CategoriaABuscar => CategoriaABuscar.id == laCategoriaParaGuardar.id);

            if (laCategoriaEnBaseDeDatos != null)
            {
                _elContexto.Categoria.Remove(laCategoriaEnBaseDeDatos);
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }
    }
}