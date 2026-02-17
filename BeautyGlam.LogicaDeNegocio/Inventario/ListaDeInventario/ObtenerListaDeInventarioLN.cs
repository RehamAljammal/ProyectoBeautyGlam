using BeautyGlam.Abstracciones.AccesoADatos.Inventario.ListaDeInventario;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Inventario.ListaDeInventario;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Inventario;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Inventario.ListaDeInventario
{
    public class ObtenerLaListaDeInventarioLN : IObtenerListaDeInventarioLN
    {
        private readonly IObtenerListaDeInventarioAD _obtenerListaDeInventarioAD;

        public ObtenerLaListaDeInventarioLN()
        {
            _obtenerListaDeInventarioAD = new ObtenerListaDeInventarioAD();
        }

        public List<InventarioDto> Obtener()
        {
            List<InventarioDto> laListaDeInventario =
                _obtenerListaDeInventarioAD.Obtener();

            return laListaDeInventario;
        }
    }
}
