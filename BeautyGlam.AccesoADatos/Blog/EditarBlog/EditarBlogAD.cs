using BeautyGlam.Abstracciones.AccesoADatos.Blog.EditarBlog;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Blog
{
    public class EditarBlogAD : IEditarBlogAD
    {
        private Contexto _elContexto;

        public EditarBlogAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(BlogDto blogParaEditar)
        {
            var entidad = await _elContexto.Blog.FirstOrDefaultAsync(b => b.id_Blog == blogParaEditar.id_Blog);
            if (entidad != null)
            {
                entidad.titulo = blogParaEditar.titulo;
                entidad.resumen = blogParaEditar.resumen;
                entidad.contenido = blogParaEditar.contenido;
                entidad.imagen = blogParaEditar.imagen;
                entidad.fecha_Actualizacion = DateTime.Now;

                return await _elContexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}