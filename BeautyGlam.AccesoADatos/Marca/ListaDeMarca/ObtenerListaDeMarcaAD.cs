using BeautyGlam.Abstracciones.AccesoADatos.Marca.ListaDeMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Marca.ListaDeMarca
{
    public class ObtenerListaDeMarcaAD : IObtenerListaDeMarcaAD
    {
        private Contexto _elContexto;

        public ObtenerListaDeMarcaAD()
        {
            _elContexto = new Contexto();
        }

        public List<MarcaDto> Obtener()
        {
            List<MarcaDto> laListaDeMarca =
                (from Marca in _elContexto.Marca
                 where Marca.estado == true
                 select new MarcaDto
                 {
                     id_Marca = Marca.id_Marca,
                     nombre = Marca.nombre,
                     estado = Marca.estado
                 }).ToList();

            return laListaDeMarca;
        }


        public List<MarcaDto> ObtenerTodos()
        {
            List<MarcaDto> laListaDeMarca =
                (from Marca in _elContexto.Marca
                 select new MarcaDto
                 {
                     id_Marca = Marca.id_Marca,
                     nombre = Marca.nombre,
                     estado = Marca.estado
                 }).ToList();

            return laListaDeMarca;
        }

    }
}
