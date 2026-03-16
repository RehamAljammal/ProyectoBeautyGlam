using BeautyGlam.AccesoADatos.Tono.DesactivarTono;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Tono
{
    public class DesactivarTonoLN
    {
        private DesactivarTonoAD _desactivarTonoAD;

        public DesactivarTonoLN()
        {
            _desactivarTonoAD = new DesactivarTonoAD();
        }

        public async Task<int> Desactivar(int id)
        {
            return await _desactivarTonoAD.Desactivar(id);
        }
    }
}