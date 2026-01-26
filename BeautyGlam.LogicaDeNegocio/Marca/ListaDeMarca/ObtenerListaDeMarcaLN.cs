using BeautyGlam.Abstracciones.AccesoADatos.Marca.ListaDeMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Marca.ListaDeMarca;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Marcaes.ListaDeMarca
{
    public class ObtenerListaDeMarcaLN : IObtenerListaDeMarcaAD
    {
        private readonly ObtenerListaDeMarcaAD _obtenerListaDeMarcaAD;

        public ObtenerListaDeMarcaLN()
        {
            _obtenerListaDeMarcaAD = new ObtenerListaDeMarcaAD();
        }
        public List<MarcaDto> Obtener()
        {
            List<MarcaDto> laListaDeMarcas = _obtenerListaDeMarcaAD.Obtener();
            return laListaDeMarcas;
        }


    }
}
