using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Blog.DesactivarBlog
{
    public interface IDesactivarBlogAD
    {
        Task<int> Desactivar(int idBlog);
    }
}