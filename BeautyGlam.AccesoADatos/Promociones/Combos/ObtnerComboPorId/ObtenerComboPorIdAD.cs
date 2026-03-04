using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Data.Entity;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Promociones.Combo
{
    public class ObtenerComboPorIdAD
    {
        public ComboPromocionalDTO ObtenerPorId(int idPromocion)
        {
            using (var contexto = new Contexto())
            {
                var combo = contexto.Promocion
                    .Include(p => p.PromocionProducto.Select(pp => pp.Producto))
                    .Where(p => p.id_Promocion == idPromocion)
                    .Select(p => new ComboPromocionalDTO
                    {
                        idCombo = p.id_Promocion,
                        titulo = p.titulo,
                        descripcion = p.descripcion,
                        descuento = p.descuento,

                        productos = p.PromocionProducto
                            .Select(pp => new ProductoComboDTO
                            {
                                id_Producto = pp.Producto.id,
                                nombre = pp.Producto.nombre,
                                precio = pp.Producto.precio
                            }).ToList()
                    })
                    .FirstOrDefault();

                if (combo != null)
                {
                    combo.precioCombo =
                        combo.productos.Sum(x => x.precio);
                }

                return combo;
            }
        }
    }
}