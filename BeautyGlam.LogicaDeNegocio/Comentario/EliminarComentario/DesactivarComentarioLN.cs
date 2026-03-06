using BeautyGlam.Abstracciones.AccesoADatos.ComentarioBlog.DesactivarComentario;
using BeautyGlam.AccesoADatos.Blog;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Blog
{
    public class DesactivarComentarioLN : IDesactivarComentarioAD
    {
        private readonly DesactivarComentarioAD _desactivarComentarioAD;

        public DesactivarComentarioLN()
        {
            _desactivarComentarioAD = new DesactivarComentarioAD();
        }

        public async Task<int> Desactivar(int idComentario)
        {
            return await _desactivarComentarioAD.Desactivar(idComentario);
        }
    }
}