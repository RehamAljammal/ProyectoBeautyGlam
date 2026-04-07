using BeautyGlam.Abstracciones.LogicaDeNegocio.Historial_de_Compras.Reclamo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.HistorialCompras.Reclamo;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Historial_Compras.Reclamo
{
    public class RegistrarReclamoLN : IRegistrarReclamoLN
    {
        private readonly RegistrarReclamoAD _ad;

        public RegistrarReclamoLN()
        {
            _ad = new RegistrarReclamoAD();
        }

        public async Task<int> Registrar(ReclamoDto r)
        {
            return await _ad.Registrar(r);
        }
    }
}
