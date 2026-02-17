using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.RegistrarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Promociones.RegistrarPromociones
{
    public class RegistrarPromocionesAD : IRegistrarPromocionesLN
    {
        private Contexto _elContexto;

        public RegistrarPromocionesAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(PromocionesDTO laPromocionParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            PromocionesAD laPromocionEnEntidad =
                ConvierteObjetoAEntidad(laPromocionParaGuardar);

            _elContexto.Promocion.Add(laPromocionEnEntidad);

            cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();

            return cantidadDeFilasAfectadas;
        }

        private PromocionesAD ConvierteObjetoAEntidad(PromocionesDTO laPromocionParaGuardar)
        {
            return new PromocionesAD
            {
                id_Promocion = laPromocionParaGuardar.id_Promocion,
                titulo = laPromocionParaGuardar.titulo,
                descripcion = laPromocionParaGuardar.descripcion,
                fecha_Inicio = laPromocionParaGuardar.fecha_Inicio,
                fecha_Fin = laPromocionParaGuardar.fecha_Fin,
                estado = laPromocionParaGuardar.estado
            };
        }
    }
}
