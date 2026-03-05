using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Blog.ListaComentario
{
    public interface IObtenerListaComentarioAD
    {
        List<ComentarioBlogDto> ObtenerPorBlog(int idBlog);
    }
}
