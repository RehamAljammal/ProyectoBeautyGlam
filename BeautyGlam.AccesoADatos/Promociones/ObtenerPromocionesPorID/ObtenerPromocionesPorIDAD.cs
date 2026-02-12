using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Promociones.ObtenerPromocionPorId
{
    public class ObtenerPromocionPorIdAD
    {
        private Contexto _elContexto;

        public ObtenerPromocionPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public PromocionesDTO ObtenerPorId(int idDeLaPromocionABuscar)
        {
            PromocionesDTO laPromocionEnBaseDeDatos =
                (from promocion in _elContexto.Promocion
                 where promocion.id_Promocion == idDeLaPromocionABuscar
                 select new PromocionesDTO
                 {
                     id_Promocion = promocion.id_Promocion,
                     titulo = promocion.titulo,
                     descripcion = promocion.descripcion,
                     fecha_Inicio = promocion.fecha_Inicio,
                     fecha_Fin = promocion.fecha_Fin,
                     estado = promocion.estado
                 }).FirstOrDefault();

            return laPromocionEnBaseDeDatos;
        }
    }
}
