using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Catalogo;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Catalogo
{
    public class ObtenerCatalogoLN
    {
        private readonly ObtenerCatalogoAD _ad;

        public ObtenerCatalogoLN()
        {
            _ad = new ObtenerCatalogoAD();
        }

        public List<ProductosDTO> Obtener(string q, int? idCategoria, int? idMarca, decimal? min, decimal? max)
        {
            List<ProductosDTO> lista = _ad.Obtener(q, idCategoria, idMarca, min, max);
            return lista;
        }
    }
}