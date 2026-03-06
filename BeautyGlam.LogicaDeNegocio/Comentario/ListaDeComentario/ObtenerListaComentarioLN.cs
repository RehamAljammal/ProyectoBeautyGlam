using BeautyGlam.Abstracciones.AccesoADatos.Blog.ListaComentario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Blog.ListaComentario;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class ObtenerListaComentarioLN : IObtenerListaComentarioAD
    {
        private readonly ObtenerListaComentarioAD _obtenerListaComentarioAD;

        public ObtenerListaComentarioLN()
        {
            _obtenerListaComentarioAD = new ObtenerListaComentarioAD();
        }

        public List<ComentarioBlogDto> ObtenerPorBlog(int idBlog)
        {
            return _obtenerListaComentarioAD.ObtenerPorBlog(idBlog);
        }
    }
}