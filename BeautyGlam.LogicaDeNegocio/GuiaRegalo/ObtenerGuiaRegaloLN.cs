using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.GuiaRegalo.Lista;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.GuiaRegalo
{
    public class ObtenerGuiaRegaloLN
    {
        private readonly ObtenerGuiaRegaloAD _ad;

        public ObtenerGuiaRegaloLN()
        {
            _ad = new ObtenerGuiaRegaloAD();
        }

        public List<GuiaRegaloDto> Obtener()
        {
            return _ad.Obtener();
        }
    }
}

