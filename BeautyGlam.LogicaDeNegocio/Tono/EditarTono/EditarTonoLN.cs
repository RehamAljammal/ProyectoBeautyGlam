using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Tono.EditarTono;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Tono
{
    public class EditarTonoLN
    {
        private EditarTonoAD _editarTonoAD;

        public EditarTonoLN()
        {
            _editarTonoAD = new EditarTonoAD();
        }

        public async Task<int> Editar(TonoDTO tono)
        {
            return await _editarTonoAD.Editar(tono);
        }
    }
}
