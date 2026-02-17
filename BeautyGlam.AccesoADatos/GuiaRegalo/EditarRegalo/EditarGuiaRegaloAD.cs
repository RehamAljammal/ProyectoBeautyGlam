using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EditarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;

namespace BeautyGlam.AccesoADatos.GuiaRegalo.EditarGuiaRegalo
{
    public class EditarGuiaRegaloAD : IEditarGuiaRegaloAD
    {
        private readonly Contexto _contexto;

        public EditarGuiaRegaloAD()
        {
            _contexto = new Contexto();
        }

        public async Task Editar(GuiaRegaloDto dto)
        {
            GuiaRegaloAD guia =
                _contexto.GuiaRegalo
                .Include(g => g.GuiaProducto)
                .FirstOrDefault(g => g.idGuia == dto.idGuia);

            if (guia == null)
                return;

            // 📝 Datos básicos
            guia.categoria = dto.categoria;
            guia.presupuesto = dto.presupuesto;
            guia.genero = dto.genero;
            guia.tipo = dto.tipo;

            // 🔄 Eliminar relaciones actuales
            List<GuiaProductoAD> relacionesActuales =
                _contexto.GuiaProducto
                .Where(x => x.id_Guia == guia.idGuia)
                .ToList();

            _contexto.GuiaProducto.RemoveRange(relacionesActuales);

            // ➕ Insertar nuevas relaciones
            foreach (int idProducto in dto.productosSeleccionados)
            {
                GuiaProductoAD relacion = new GuiaProductoAD
                {
                    id_Guia = guia.idGuia,
                    id = idProducto
                };

                _contexto.GuiaProducto.Add(relacion);
            }

            await _contexto.SaveChangesAsync();
        }
    }
}
