
using BeautyGlam.Abstracciones.AccesoADatos.Promocion.ListaDePromocion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Promociones.ObtenerListaPromociones
{
    public class ObtenerListaPromocionesAD : IObtenerListaDePromocionesAD
    {
        private Contexto _elContexto;

        public ObtenerListaPromocionesAD()
        {
            _elContexto = new Contexto();
        }

        public List<PromocionesDTO> Obtener()
        {
            List<PromocionesDTO> laListaDePromociones =
                (from p in _elContexto.Promocion
                 select new PromocionesDTO
                 {
                     id_Promocion = p.id_Promocion,
                     titulo = p.titulo,
                     descripcion = p.descripcion,
                     fecha_Inicio = p.fecha_Inicio,
                     fecha_Fin = p.fecha_Fin,
                     estado = p.estado
                 }).ToList();

            return laListaDePromociones;
        }
    }
}
