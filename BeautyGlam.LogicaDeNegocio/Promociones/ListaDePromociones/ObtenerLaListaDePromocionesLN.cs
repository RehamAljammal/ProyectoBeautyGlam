using BeautyGlam.Abstracciones.AccesoADatos.Promocion.ListaDePromocion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Promociones.ObtenerListaPromociones;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Promociones.ListaPromociones
{
    public class ObtenerLaListaDePromocionesLN : IObtenerListaDePromocionesAD
    {
        private readonly ObtenerListaPromocionesAD _obtenerLaListaDePromocionesAD;

        public ObtenerLaListaDePromocionesLN()
        {
            _obtenerLaListaDePromocionesAD = new ObtenerListaPromocionesAD();
        }

        public List<PromocionesDTO> Obtener()
        {
            List<PromocionesDTO> laListaDePromociones =
                _obtenerLaListaDePromocionesAD.Obtener();

            return laListaDePromociones;
        }
    }
}
