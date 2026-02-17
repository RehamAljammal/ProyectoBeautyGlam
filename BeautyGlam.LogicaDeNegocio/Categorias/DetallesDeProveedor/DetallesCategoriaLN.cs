using BeautyGlam.Abstracciones.AccesoADatos.Categoria.DetallesCategoria;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.DetallesCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.DetallesCategoria;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Categorias.DetallesDeCategoria
{
    public class DetallesCategoriaLN : IDetallesCategoriaLN
    {
        private IDetallesCategoriaAD _detallesCategoriaAD;

        
        public DetallesCategoriaLN()
        {
            _detallesCategoriaAD = new DetallesCategoriaAD();


        }

        public async Task<int> Detalles(CategoriasDto laCategoriaParaGuardar)
        {
            int cantidadDeFilasAfectas = await _detallesCategoriaAD.Detalles(laCategoriaParaGuardar);
            return cantidadDeFilasAfectas;
        }
    }
}


