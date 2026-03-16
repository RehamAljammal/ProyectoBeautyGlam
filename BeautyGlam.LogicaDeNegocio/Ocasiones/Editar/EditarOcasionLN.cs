using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Editar;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.Editar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Ocasiones.Editar;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Ocasiones.Editar
{
    public class EditarOcasionLN : IEditarOcasionLN
    {
        private readonly IEditarOcasionAD _editarOcasionAD;

        public EditarOcasionLN()
        {
            _editarOcasionAD = new EditarOcasionAD();
        }

        public async Task<int> Editar(OcasionDto ocasion)
        {
            return await _editarOcasionAD.Editar(ocasion);
        }
    }
}