using BeautyGlam.Abstracciones.AccesoADatos.Categoria.ActivarDesactivar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Categoria.ActivarDesactivar
{
    public class ActivarDesactivarCategoriaAD : IActivarDesactivarCategoriaAD
    {
        private readonly Contexto _contexto;

        public ActivarDesactivarCategoriaAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> ActivarDesactivar(CategoriasDto dto)
        {
            CategoriaAD categoria = _contexto.Categoria
                .FirstOrDefault(x => x.id == dto.id);

            if (categoria != null)
            {
                categoria.estado = !categoria.estado;
                return await _contexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}