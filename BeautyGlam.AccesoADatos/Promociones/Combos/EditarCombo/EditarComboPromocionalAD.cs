using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Promociones.Combo
{
    public class EditarComboPromocionalAD : IEditarComboPromocionalAD
    {
        public async Task<int> Editar(ComboPromocionalDTO combo)
        {
            using (var contexto = new Contexto())
            {
                var promocion = await contexto.Promocion
                    .FirstOrDefaultAsync(p => p.id_Promocion == combo.idCombo);

                if (promocion == null)
                    return 0;

                promocion.titulo = combo.titulo;
                promocion.descripcion = combo.descripcion;
                promocion.fecha_Inicio = combo.fechaInicio;
                promocion.fecha_Fin = combo.fechaFin;
                promocion.descuento = combo.descuento;

                var relacionesActuales = contexto.PromocionProducto
                    .Where(x => x.id_Promocion == combo.idCombo)
                    .ToList();

                contexto.PromocionProducto.RemoveRange(relacionesActuales);

                // ✅ USAR idsProductos
                if (combo.idsProductos != null)
                {
                    foreach (var idProducto in combo.idsProductos)
                    {
                        contexto.PromocionProducto.Add(new PromocionProductoAD
                        {
                            id_Promocion = combo.idCombo,
                            id = idProducto
                        });
                    }
                }

                return await contexto.SaveChangesAsync();
            }
        }
    }
}