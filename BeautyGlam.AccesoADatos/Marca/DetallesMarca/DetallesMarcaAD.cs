using BeautyGlam.Abstracciones.AccesoADatos.Marca.DetallesMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Marca.DetallesDeMarca
{
    public class DetallesMarcaAD : IDetallesMarcaAD
    {
        private readonly Contexto _elContexto;

        public DetallesMarcaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Detalles(MarcaDto laMarcaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            MarcaAD laMarcaEnBaseDeDatos = _elContexto.Marca
                .FirstOrDefault(MarcaABuscar => MarcaABuscar.id_Marca == laMarcaParaGuardar.id_Marca);

            return cantidadDeFilasAfectadas;
        }
    }
}

