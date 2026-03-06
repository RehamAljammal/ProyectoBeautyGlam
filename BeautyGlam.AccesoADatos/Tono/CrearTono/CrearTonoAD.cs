using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Tono.CrearTono
{
    public class CrearTonoAD
    {
        private Contexto _contexto;

        public CrearTonoAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> Crear(TonoDTO tono)
        {
            TonoAD entidad = new TonoAD
            {
                nombre = tono.nombre,
                descripcion = tono.descripcion,
                estado = true
            };

            _contexto.Tono.Add(entidad);

            return await _contexto.SaveChangesAsync();
        }
    }
}
