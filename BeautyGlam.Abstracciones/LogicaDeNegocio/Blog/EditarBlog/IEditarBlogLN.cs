using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.EditarBlog
{
    public interface IEditarBlogLN
    {
        Task<int> Editar(BlogDto blogParaActualizar);
        Task<BlogDto> ObtenerPorId(int idBlog);
    }
}