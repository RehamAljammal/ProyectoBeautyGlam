using BeautyGlam.Abstracciones.AccesoADatos.Blog.ListaBlog;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Blog
{
    public class ObtenerListaBlogAD : IObtenerListaBlogAD
    {
        private Contexto _elContexto;

        public ObtenerListaBlogAD()
        {
            _elContexto = new Contexto();
        }

        // Obtener todos los blogs activos
        public List<BlogDto> ObtenerTodos()
        {
            return _elContexto.Blog
                .Where(b => b.estado == true)
                .OrderByDescending(b => b.fecha_Publicacion)
                .Select(b => new BlogDto
                {
                    id_Blog = b.id_Blog,
                    titulo = b.titulo,
                    resumen = b.resumen,
                    contenido = b.contenido,
                    imagen = b.imagen,
                    fecha_Publicacion = b.fecha_Publicacion,
                    fecha_Actualizacion = b.fecha_Actualizacion,
                    estado = b.estado
                })
                .ToList();
        }

        // Obtener un blog por ID
        public async Task<BlogDto> ObtenerPorId(int idBlog)
        {
            var blog = _elContexto.Blog
                .Where(b => b.id_Blog == idBlog && b.estado == true)
                .Select(b => new BlogDto
                {
                    id_Blog = b.id_Blog,
                    titulo = b.titulo,
                    resumen = b.resumen,
                    contenido = b.contenido,
                    imagen = b.imagen,
                    fecha_Publicacion = b.fecha_Publicacion,
                    fecha_Actualizacion = b.fecha_Actualizacion,
                    estado = b.estado
                }).FirstOrDefault();

            return await Task.FromResult(blog);
        }
    }
}