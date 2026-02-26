using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EliminarGuiaRegalo;
using BeautyGlam.Abstracciones.LogicaDeNegocio.GuiaRegalo.EliminarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.GuiaRegalo.EliminarGuiaRegalo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.GuiaRegalo.EliminarGuiaRegalo
{
    public class EliminarGuiaRegaloLN : IEliminarGuiaRegaloLN
    {
        private readonly IEliminarGuiaRegaloAD _ad;

        public EliminarGuiaRegaloLN()
        {
            _ad = new EliminarGuiaRegaloAD();
        }

        public async Task<int> Eliminar(GuiaRegaloDto laGuiaParaEliminar)
        {
            return await _ad.Eliminar(laGuiaParaEliminar);
        }
    }
}
