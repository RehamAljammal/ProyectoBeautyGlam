using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.Comentarios.ListarComentarios
{
    internal interface IObtenerComentariosLN
    {
        List<ComentarioBlogDto> ObtenerPorBlog(int idBlog);
    }
}