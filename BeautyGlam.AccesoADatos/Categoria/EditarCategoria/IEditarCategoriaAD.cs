using BeautyGlam.Abstracciones.LogicaDeNegocio.Categoria.EditarCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Categoria.EditarCategoria
{
    public class EditarCategoriaAD : IEditarCategoriaLN
    {
        private Contexto _elContexto;


        public EditarCategoriaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(CategoriasDto laCategoriaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            CategoriaAD laCategoriaEnBaseDeDatos = await _elContexto.Categoria
                .FirstOrDefaultAsync(p => p.id == laCategoriaParaGuardar.id);

            if (laCategoriaEnBaseDeDatos != null)
            {
                laCategoriaEnBaseDeDatos.nombre = laCategoriaParaGuardar.nombre;
                laCategoriaEnBaseDeDatos.descripcion = laCategoriaParaGuardar.descripcion;
                laCategoriaEnBaseDeDatos.estado = laCategoriaParaGuardar.estado;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        public async Task<CategoriasDto> ObtenerPorId(int id)
        {
            CategoriaAD entidad = await _elContexto.Categoria.FindAsync(id);

            if (entidad == null)
                return null;

            return new CategoriasDto
            {
                id = entidad.id,
                nombre = entidad.nombre,
                descripcion = entidad.descripcion,
                estado = entidad.estado

            };
        }
    }
}

