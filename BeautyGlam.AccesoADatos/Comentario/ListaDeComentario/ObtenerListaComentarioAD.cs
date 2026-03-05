using BeautyGlam.Abstracciones.AccesoADatos.Blog.ListaComentario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Blog.ListaComentario
{
    public class ObtenerListaComentarioAD : IObtenerListaComentarioAD
    {
        private readonly Contexto _elContexto;

        public ObtenerListaComentarioAD()
        {
            _elContexto = new Contexto();
        }

        public List<ComentarioBlogDto> ObtenerPorBlog(int idBlog)
        {
            var comentarios = (from c in _elContexto.ComentarioBlog
                               join u in _elContexto.Usuario
                               on c.id_Usuario equals u.id_Usuario
                               where c.id_Blog == idBlog && c.estado == true
                               orderby c.fecha descending
                               select new ComentarioBlogDto
                               {
                                   id_Comentario = c.id_Comentario,
                                   id_Blog = c.id_Blog,
                                   id_Usuario = c.id_Usuario,
                                   comentario = c.comentario,
                                   fecha = c.fecha,
                                   nombreUsuario = u.nombre + " " + u.apellido,
                                   estado = c.estado
                               }).ToList();

            return comentarios;
        }
    }
}