using BeautyGlam.Abstracciones.AccesoADatos.Categoria.ListaCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Categoria.ListaCategoria;
using System.Collections.Generic;

namespace BeautyGlam.LogicaDeNegocio.Categorias.ListaDeCategoria
{
    public class ObtenerLaListaDeCategoriasLN : IObtenerListaDeCategoriasAD
    {
        private readonly ObtenerListaDeCategoriasAD _obtenerListaDeCategoriasAD;

        public ObtenerLaListaDeCategoriasLN()
        {
            _obtenerListaDeCategoriasAD = new ObtenerListaDeCategoriasAD();
        }
        public List<CategoriasDto> Obtener()
        {
            List<CategoriasDto> laListaDeCategorias = _obtenerListaDeCategoriasAD.Obtener();
            return laListaDeCategorias;
        }


    }
}
