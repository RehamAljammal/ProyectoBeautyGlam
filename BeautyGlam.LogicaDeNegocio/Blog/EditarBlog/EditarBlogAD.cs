using BeautyGlam.Abstracciones.AccesoADatos.Blog.EditarBlog;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Blog;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class EditarBlogLN : IEditarBlogAD
    {
        private readonly EditarBlogAD _editarBlogAD;

        public EditarBlogLN()
        {
            _editarBlogAD = new EditarBlogAD();
        }

        public async Task<int> Editar(BlogDto blogParaActualizar)
        {
            return await _editarBlogAD.Editar(blogParaActualizar);
        }
    }
}
