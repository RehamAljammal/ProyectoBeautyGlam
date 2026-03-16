using BeautyGlam.Abstracciones.AccesoADatos.Ocasiones.Lista;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Ocasiones.Lista;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Ocasiones.Lista;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Ocasiones.Lista
{
    public class ObtenerOcasionesLN : IObtenerOcasionesLN
    {
        private readonly IObtenerOcasionesAD _ad;

        public ObtenerOcasionesLN()
        {
            _ad = new ObtenerOcasionesAD();
        }

        public List<OcasionDto> Obtener()
        {
            return _ad.Obtener();
        }
    }
}