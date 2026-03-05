using BeautyGlam.Abstracciones.AccesoADatos.Blog.ListaBlog;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Blog;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class ObtenerListaBlogLN : IObtenerListaBlogAD
    {
        private readonly ObtenerListaBlogAD _obtenerListaBlogAD;

        public ObtenerListaBlogLN()
        {
            _obtenerListaBlogAD = new ObtenerListaBlogAD();
        }

        public List<BlogDto> ObtenerTodos()
        {
            return _obtenerListaBlogAD.ObtenerTodos();
        }
    }
}