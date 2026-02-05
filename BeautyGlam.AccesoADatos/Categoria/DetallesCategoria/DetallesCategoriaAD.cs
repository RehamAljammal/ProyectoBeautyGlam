using BeautyGlam.Abstracciones.AccesoADatos.Categoria.DetallesCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Categoria.DetallesCategoria
{
    public class DetallesCategoriaAD : IDetallesCategoriaAD
    {
        private readonly Contexto _elContexto;

        public DetallesCategoriaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Detalles(CategoriasDto laCategoriaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            CategoriaAD laCategoriaEnBaseDeDatos = _elContexto.Categoria
                .FirstOrDefault(CategoriaABuscar => CategoriaABuscar.id == laCategoriaParaGuardar.id);

            return cantidadDeFilasAfectadas;
        }
    }
}

