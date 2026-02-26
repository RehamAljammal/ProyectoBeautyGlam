using System.Threading.Tasks;
using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;

namespace BeautyGlam.LogicaDeNegocio.GuiaRegalo.EditarGuiaRegalo
{
    public class EditarGuiaRegaloLN : IEditarGuiaRegaloLN
    {
        private readonly IEditarGuiaRegaloAD _editarGuiaRegaloAD;

        public EditarGuiaRegaloLN(IEditarGuiaRegaloAD editarGuiaRegaloAD)
        {
            _editarGuiaRegaloAD = editarGuiaRegaloAD;
        }

        public async Task Editar(GuiaRegaloDto dto)
        {
            await _editarGuiaRegaloAD.Editar(dto);
        }
    }
}
