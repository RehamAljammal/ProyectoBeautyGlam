using BeautyGlam.Abstracciones.AccesoADatos.Tono.ObtenerListaTono;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Tono.ListaDeTono;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Tono
{
    public class ObtenerListaTonoLN : IObtenerListaTonoAD
    {
        private readonly ObtenerListaTonoAD _obtenerListaTonoAD;

        public ObtenerListaTonoLN()
        {
            _obtenerListaTonoAD = new ObtenerListaTonoAD();
        }

        public List<TonoDTO> ObtenerTodos()
        {
            return _obtenerListaTonoAD.Obtener();
        }
    }
}