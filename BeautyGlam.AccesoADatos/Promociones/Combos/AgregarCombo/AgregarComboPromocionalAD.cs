using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Promociones.Combo
{
    public class AgregarComboPromocionalAD : IAgregarComboPromocionalAD
    {
        public async Task<int> Agregar(ComboPromocionalDTO combo)
        {
            using (var contexto = new Contexto())
            {
                var promocion = new PromocionesAD
                {
                    titulo = combo.titulo,
                    descripcion = combo.descripcion,
                    estado = true,

                    fecha_Inicio = DateTime.Now,
                    fecha_Fin = DateTime.Now.AddMonths(1)
                };

                contexto.Promocion.Add(promocion);

                await contexto.SaveChangesAsync();

                // protección
                if (combo.productos != null)
                {
                    foreach (var producto in combo.productos)
                    {
                        var relacion = new PromocionProductoAD
                        {
                            id_Promocion = promocion.id_Promocion,
                            id = producto.id_Producto

                        };

                        contexto.PromocionProducto.Add(relacion);
                    }
                }

                return await contexto.SaveChangesAsync();
            }
        }
    }
}