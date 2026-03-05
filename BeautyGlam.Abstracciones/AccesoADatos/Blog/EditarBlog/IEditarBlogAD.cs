using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Blog.EditarBlog
{
    public interface IEditarBlogAD
    {
        Task<int> Editar(BlogDto blogParaGuardar);
    }
}