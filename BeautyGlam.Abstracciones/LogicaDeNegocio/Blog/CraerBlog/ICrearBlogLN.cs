using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.CrearBlog
{
    public interface ICrearBlogLN
    {
        Task<int> Crear(BlogDto blogParaGuardar);
    }
}