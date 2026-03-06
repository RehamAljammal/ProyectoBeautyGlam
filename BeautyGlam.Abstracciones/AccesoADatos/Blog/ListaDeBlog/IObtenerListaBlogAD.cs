using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;

namespace BeautyGlam.Abstracciones.AccesoADatos.Blog.ListaBlog
{
    public interface IObtenerListaBlogAD
    {
        List<BlogDto> ObtenerTodos();
    }
}