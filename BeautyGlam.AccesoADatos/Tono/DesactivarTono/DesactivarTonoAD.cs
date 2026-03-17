using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Tono.DesactivarTono
{
    public class DesactivarTonoAD
    {
        private Contexto _elContexto;

        public DesactivarTonoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Desactivar(int idTono)
        {
            var tonoEnBD = _elContexto.Tono
                .FirstOrDefault(t => t.id_Tono == idTono);

            if (tonoEnBD != null)
            {
                tonoEnBD.estado = false;
            }

            return await _elContexto.SaveChangesAsync();
        }
    }
}