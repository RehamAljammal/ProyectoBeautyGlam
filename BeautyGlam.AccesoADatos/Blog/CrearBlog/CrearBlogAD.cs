using BeautyGlam.Abstracciones.AccesoADatos.Blog.CrearBlog;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Blog
{
    public class CrearBlogAD : ICrearBlogAD
    {
        private Contexto _elContexto;

        public CrearBlogAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Crear(BlogDto blogParaGuardar)
        {
            var entidad = ConvierteObjetoAEntidad(blogParaGuardar);
            _elContexto.Blog.Add(entidad);
            return await _elContexto.SaveChangesAsync();
        }

        private BlogAD ConvierteObjetoAEntidad(BlogDto blog)
        {
            return new BlogAD
            {
                titulo = blog.titulo,
                resumen = blog.resumen,
                contenido = blog.contenido,
                imagen = blog.imagen,
                estado = true
            };
        }
    }
}