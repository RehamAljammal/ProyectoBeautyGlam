using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Promociones.Combo
{
    public class ObtenerCombosPromocionalesAD : IObtenerCombosPromocionalesAD
    {
        public List<ComboPromocionalDTO> Obtener()
        {
            using (var contexto = new Contexto())
            {
                var datos = contexto.Promocion
                    .Include(p => p.PromocionProducto.Select(pp => pp.Producto))
                    .Where(p => p.estado)
                    .Select(p => new ComboPromocionalDTO
                    {
                        idCombo = p.id_Promocion,
                        titulo = p.titulo,
                        descripcion = p.descripcion,

                        productos = p.PromocionProducto
                            .Select(pp => new ProductoComboDTO
                            {
                                id_Producto = pp.Producto.id,
                                nombre = pp.Producto.nombre,
                                precio = pp.Producto.precio
                            }).ToList()
                    })
                    .ToList();

                foreach (var combo in datos)
                {
                    combo.precioCombo = combo.productos.Sum(x => x.precio);
                }

                return datos;
            }
        }
    }
}