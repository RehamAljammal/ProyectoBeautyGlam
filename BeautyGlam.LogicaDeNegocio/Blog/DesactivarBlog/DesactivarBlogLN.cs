using BeautyGlam.Abstracciones.AccesoADatos.Blog.DesactivarBlog;
using BeautyGlam.AccesoADatos.Blog;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class DesactivarBlogLN : IDesactivarBlogAD
    {
        private readonly DesactivarBlogAD _desactivarBlogAD;

        public DesactivarBlogLN()
        {
            _desactivarBlogAD = new DesactivarBlogAD();
        }

        public async Task<int> Desactivar(int idBlog)
        {
            return await _desactivarBlogAD.Desactivar(idBlog);
        }
    }
}
