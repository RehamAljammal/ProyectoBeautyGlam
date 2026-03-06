using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.ListaComentarios
{
    public interface IObtenerComentariosPorBlogAD
    {
        List<ComentarioBlogDto> ObtenerPorBlog(int idBlog);
    }
}