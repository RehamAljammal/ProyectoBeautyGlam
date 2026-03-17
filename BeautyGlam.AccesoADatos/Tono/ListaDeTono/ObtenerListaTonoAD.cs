using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Tono.ListaDeTono
{
    public class ObtenerListaTonoAD
    {
        private Contexto _contexto;

        public ObtenerListaTonoAD()
        {
            _contexto = new Contexto();
        }

        public List<TonoDTO> Obtener()
        {
            return _contexto.Tono
                .Where(t => t.estado == true)
                .Select(t => new TonoDTO
                {
                    id_Tono = t.id_Tono,
                    nombre = t.nombre,
                    descripcion = t.descripcion,
                    estado = t.estado
                })
                .ToList();
        }
    }
}
