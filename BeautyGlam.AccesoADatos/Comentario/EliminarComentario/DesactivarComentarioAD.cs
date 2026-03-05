using BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.DesactivarComentario;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Blog
{
    public class DesactivarComentarioAD : IDesactivarComentarioAD
    {
        private Contexto _elContexto;

        public DesactivarComentarioAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Desactivar(int idComentario)
        {
            var entidad = await _elContexto.ComentarioBlog.FirstOrDefaultAsync(c => c.id_Comentario == idComentario);
            if (entidad != null)
            {
                entidad.estado = false;
                return await _elContexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}