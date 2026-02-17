using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Categoria.ObtenerCategoriaPorID
{
    public class ObtenerCategoriaPorIdAD
    {
        private Contexto _elContexto;
        public ObtenerCategoriaPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public CategoriasDto ObtenerPorId(int idDeLaCategoriaABuscar)
        {
            CategoriasDto laCategoriaEnBaseDeDatos = (from Categoria in _elContexto.Categoria
                                                      where Categoria.id == idDeLaCategoriaABuscar
                                                      select new CategoriasDto
                                                      {
                                                          id = Categoria.id,
                                                          nombre = Categoria.nombre,
                                                          descripcion = Categoria.descripcion,
                                                          estado = Categoria.estado

                                                      }).FirstOrDefault();
            return laCategoriaEnBaseDeDatos;
        }
    }
}