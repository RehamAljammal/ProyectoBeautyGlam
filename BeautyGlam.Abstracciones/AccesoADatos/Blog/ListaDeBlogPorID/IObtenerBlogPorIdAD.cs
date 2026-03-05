using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Blog.DetalleBlog
{
    internal interface IObtenerBlogPorIdAD
    {
        Task<BlogDto> ObtenerPorId(int idBlog);
    }
}