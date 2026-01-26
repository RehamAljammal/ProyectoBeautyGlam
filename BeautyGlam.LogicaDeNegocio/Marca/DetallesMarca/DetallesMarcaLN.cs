using BeautyGlam.Abstracciones.AccesoADatos.Marca.DetallesMarca;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.DetallesDeMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marca.DetallesDeMarca;
using System.Threading.Tasks;

namespace BeautyGlam.LogicaDeNegocio.Marca.DetallesMarca
{
 
        public class DetallesMarcaLN : IDetallesMarcaLN
        {
            private IDetallesMarcaAD _detallesMarcaAD;
        
            public DetallesMarcaLN()
            {
                _detallesMarcaAD = new DetallesMarcaAD();
            }

            public async Task<int> Detalles(MarcaDto laMarcaParaGuardar)
            {
                int cantidadDeFilasAfectas = await _detallesMarcaAD.Detalles(laMarcaParaGuardar);
                return cantidadDeFilasAfectas;
            }
        }
    }


