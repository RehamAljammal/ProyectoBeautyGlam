using BeautyGlam.Abstracciones.AccesoADatos.Blog.DesactivarBlog;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Blog
{
    public class DesactivarBlogAD : IDesactivarBlogAD
    {
        private Contexto _elContexto;

        public DesactivarBlogAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Desactivar(int idBlog)
        {
            var entidad = await _elContexto.Blog.FirstOrDefaultAsync(b => b.id_Blog == idBlog);
            if (entidad != null)
            {
                entidad.estado = false;
                return await _elContexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}