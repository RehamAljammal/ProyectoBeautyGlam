using BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Valoracion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.HistorialCompras.Valoración
{
    public class RegistrarValoracionAD : IRegistrarValoracionAD
    {
        private readonly Contexto _elContexto;

        public RegistrarValoracionAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ValoracionDto v)
        {
            var existe = _elContexto.ValoracionProducto
                .FirstOrDefault(x =>
                    x.idUsuario == v.idUsuario &&
                    x.idProducto == v.idProducto);

            if (existe != null)
                return 0;

            var nueva = new ValoracionProductoAD
            {
                idUsuario = v.idUsuario,
                idProducto = v.idProducto,
                estrellas = v.estrellas,
                comentario = v.comentario,
                fecha = DateTime.Now
            };

            _elContexto.ValoracionProducto.Add(nueva);
            await _elContexto.SaveChangesAsync();

            return 1;
        }
    }
}
