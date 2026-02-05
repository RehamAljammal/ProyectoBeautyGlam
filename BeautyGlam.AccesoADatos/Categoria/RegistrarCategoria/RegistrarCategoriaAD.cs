using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.RegistrarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Categoria.RegistrarCategoria
{
    public class RegistrarCategoriaAD : IRegistrarCategoriaLN
    {
        private Contexto _elContexto;

        public RegistrarCategoriaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(CategoriasDto laCategoriaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;
            CategoriaAD laCategoriaEnEntidad = ConvierteObjetoAEntidad(laCategoriaParaGuardar);
            _elContexto.Categoria.Add(laCategoriaEnEntidad);
            cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            return cantidadDeFilasAfectadas;
        }
        private CategoriaAD ConvierteObjetoAEntidad(CategoriasDto laCategoriaParaGuardar)
        {
            return new CategoriaAD
            {
                id = laCategoriaParaGuardar.id,
                nombre = laCategoriaParaGuardar.nombre,
                descripcion = laCategoriaParaGuardar.descripcion,
                estado = laCategoriaParaGuardar.estado

            };

        }
    }
}