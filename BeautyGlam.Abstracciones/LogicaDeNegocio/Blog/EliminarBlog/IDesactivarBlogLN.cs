using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.DesactivarBlog
{
    internal interface IDesactivarBlogLN
    {
        Task<int> Desactivar(int idBlog);
    }
}