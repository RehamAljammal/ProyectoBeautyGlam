using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Blog.ListarBlogs
{
    public interface IObtenerListaBlogsLN
    {
        List<BlogDto> ObtenerTodos();
    }
}