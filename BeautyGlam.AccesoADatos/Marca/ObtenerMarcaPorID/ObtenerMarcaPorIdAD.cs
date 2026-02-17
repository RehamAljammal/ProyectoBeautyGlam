using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Marcaes.ObtenerMarcaPorID
{
    public class ObtenerMarcaPorIdAD
    {
        private Contexto _elContexto;
        public ObtenerMarcaPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public MarcaDto ObtenerPorId(int idDelMarcaABuscar)
        {
            MarcaDto elMarcaEnBaseDeDatos = (from Marca in _elContexto.Marca
                                                 where Marca.id_Marca == idDelMarcaABuscar
                                                 select new MarcaDto
                                                 {
                                                     id_Marca = Marca.id_Marca,
                                                     nombre = Marca.nombre,
                                                     estado = Marca.estado
 
                                                 }).FirstOrDefault();
            return elMarcaEnBaseDeDatos;
        }
    }
}
