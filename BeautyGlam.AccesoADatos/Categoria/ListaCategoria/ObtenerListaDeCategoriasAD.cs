using BeautyGlam.Abstracciones.AccesoADatos.Categoria.ListaCategoria;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Categoria.ListaCategoria
{

        public class ObtenerListaDeCategoriasAD : IObtenerListaDeCategoriasAD
        {
            private Contexto _elContexto;

            public ObtenerListaDeCategoriasAD()
            {
                _elContexto = new Contexto();
            }

            public List<CategoriasDto> Obtener()
            {
                List<CategoriasDto> laListaDeCategoria =
                    (from Categoria in _elContexto.Categoria
                     where Categoria.estado == true
                     select new CategoriasDto
                     {
                         id = Categoria.id,
                         nombre = Categoria.nombre,
                         descripcion = Categoria.descripcion,
                         estado = Categoria.estado

                     }).ToList();

                return laListaDeCategoria;
            }


            public List<CategoriasDto> ObtenerTodos()
            {
                List<CategoriasDto> laListaDeCategoria =
                    (from Categoria in _elContexto.Categoria
                     select new CategoriasDto
                     {
                         id = Categoria.id,
                         nombre = Categoria.nombre,
                         descripcion = Categoria.descripcion,
                         estado = Categoria.estado

                     }).ToList();

                return laListaDeCategoria;
            }

        }
    
}
