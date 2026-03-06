using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Tono.CrearTono;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Tono
{
    public class CrearTonoLN
    {
        private CrearTonoAD _crearTonoAD;

        public CrearTonoLN()
        {
            _crearTonoAD = new CrearTonoAD();
        }

        public async Task<int> Crear(TonoDTO tono)
        {
            return await _crearTonoAD.Crear(tono);
        }
    }
}