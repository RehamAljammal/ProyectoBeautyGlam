using BeautyGlam.Abstracciones.LogicaDeNegocio.Marca.RegistrarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Marca.RegistrarMarca
{
    public class RegistrarMarcaAD : IRegistrarMarcaLN
    {
        private Contexto _elContexto;

        public RegistrarMarcaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(MarcaDto laMarcaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;
            MarcaAD laMarcaEnEntidad = ConvierteObjetoAEntidad(laMarcaParaGuardar);
            _elContexto.Marca.Add(laMarcaEnEntidad);
            cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            return cantidadDeFilasAfectadas;
        }
        private MarcaAD ConvierteObjetoAEntidad(MarcaDto laMarcaParaGuardar)
        {
            return new MarcaAD
            {
                id_Marca = laMarcaParaGuardar.id_Marca,
                nombre = laMarcaParaGuardar.nombre,
                estado = laMarcaParaGuardar.estado

            };

        }
    }
}
