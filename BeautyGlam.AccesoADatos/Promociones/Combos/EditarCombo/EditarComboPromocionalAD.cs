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

                // encabezado del combo
                promocion.titulo = combo.titulo;
                promocion.descripcion = combo.descripcion;
                promocion.fecha_Inicio = combo.fechaInicio;
                promocion.fecha_Fin = combo.fechaFin;

                // borrar relaciones actuales
                var relacionesActuales = contexto.PromocionProducto
                    .Where(x => x.id_Promocion == combo.idCombo)
                    .ToList();

                contexto.PromocionProducto.RemoveRange(relacionesActuales);

                // volver a insertar productos
                if (combo.productos != null)
                {
                    foreach (var producto in combo.productos)
                    {
                        contexto.PromocionProducto.Add(new PromocionProductoAD
                        {
                            id_Promocion = combo.idCombo,
                            id = producto.id_Producto
                        });
                    }
                }

                return await contexto.SaveChangesAsync();
            }
        }
    }
}