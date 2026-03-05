using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Blog.CrearBlog
{
    public interface ICrearBlogAD
    {
        Task<int> Crear(BlogDto blogParaGuardar);
    }
}