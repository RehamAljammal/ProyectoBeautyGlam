using BeautyGlam.Abstracciones.AccesoADatos.Historial_de_Compras.Reclamo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.HistorialCompras.Reclamo
{
    public class RegistrarReclamoAD : IRegistrarReclamoAD
    {
        private readonly Contexto _elContexto;

        public RegistrarReclamoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ReclamoDto r)
        {
            var nuevo = new DevolucionAD
            {
                id_Venta = r.idVenta,
                id_Producto = r.idProducto,
                motivo = r.descripcion,
                fecha_Devolucion = DateTime.Now,
                estado = "REGISTRADA"
            };

            _elContexto.Devolucion.Add(nuevo);
            await _elContexto.SaveChangesAsync();

            return 1;
        }
    }
}
