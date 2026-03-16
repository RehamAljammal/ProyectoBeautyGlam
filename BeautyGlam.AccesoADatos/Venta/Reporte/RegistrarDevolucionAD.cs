using BeautyGlam.Abstracciones.AccesoADatos.Devolucion;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Devolucion
{
    public class RegistrarDevolucionAD : IRegistrarDevolucionAD
    {
        private readonly Contexto _contexto;

        public RegistrarDevolucionAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Registrar(DevolucionDto dto)
        {
            var entidad = new DevolucionAD
            {
                id_Venta = dto.id_Venta,
                id_Producto = dto.id_Producto,
                cantidad = dto.cantidad,
                motivo = dto.motivo,
                fecha_Devolucion = DateTime.Now,
                id_Admin = dto.id_Admin,
                observacion = dto.observacion,
                estado = "Registrada"
            };

            _contexto.Devolucion.Add(entidad);
            await _contexto.SaveChangesAsync();

            return entidad.id_Devolucion;
        }

        public List<VentaDto> ObtenerPorCliente(int idUsuario)
        {
            using (var contexto = new Contexto())
            {
                return contexto.Venta
                    .Where(v => v.id_Usuario == idUsuario)
                    .Select(v => new VentaDto
                    {
                        id_Venta = v.id_Venta,
                        id_Usuario = v.id_Usuario,
                        fecha_Venta = v.fecha_Venta,
                        total = v.total,
                        estado = v.estado
                    }).ToList();
            }
        }
    }
}
