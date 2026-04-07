using BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Valoracion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.HistorialCompras.Valoración
{
        public class ObtenerValoracionesPorUsuarioAD : IObtenerValoracionesPorUsuarioLN
        {
            private readonly Contexto _elContexto;

            public ObtenerValoracionesPorUsuarioAD()
            {
                _elContexto = new Contexto();
            }

        public async Task<IEnumerable<ValoracionDto>> Obtener(int idUsuario)
        {
            var lista =
                from v in _elContexto.ValoracionProducto
                join p in _elContexto.Producto
                    on v.id equals p.id  
                where v.idUsuario == idUsuario
                select new ValoracionDto
                {
                    idProducto = p.id,
                    nombre = p.nombre, 
                    estrellas = v.estrellas,   
                    comentario = v.comentario, 
                    fecha = v.fecha,          
                    imagen = p.imagen          
                };

            return await Task.FromResult(lista.ToList());
        }
    }
    }