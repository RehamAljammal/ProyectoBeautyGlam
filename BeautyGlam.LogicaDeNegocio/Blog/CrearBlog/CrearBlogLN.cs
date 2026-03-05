using BeautyGlam.Abstracciones.AccesoADatos.Blog.CrearBlog;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Blog;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class CrearBlogLN : ICrearBlogAD
    {
        private readonly CrearBlogAD _crearBlogAD;

        public CrearBlogLN()
        {
            _crearBlogAD = new CrearBlogAD();
        }

        public async Task<int> Crear(BlogDto blogParaGuardar)
        {
            return await _crearBlogAD.Crear(blogParaGuardar);
        }
    }
}