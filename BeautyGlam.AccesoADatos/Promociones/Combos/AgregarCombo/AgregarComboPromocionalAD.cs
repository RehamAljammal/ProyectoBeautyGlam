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
                    fecha_Inicio = combo.fechaInicio,
                    fecha_Fin = combo.fechaFin,
                    descuento = combo.descuento
                };

                contexto.Promocion.Add(promocion);
                await contexto.SaveChangesAsync();

                if (combo.idsProductos != null && combo.idsProductos.Count > 0)
                {
                    foreach (var idProducto in combo.idsProductos)
                    {
                        var relacion = new PromocionProductoAD
                        {
                            id_Promocion = promocion.id_Promocion,
                            id = idProducto
                        };

                        contexto.PromocionProducto.Add(relacion);
                    }

                    await contexto.SaveChangesAsync();
                }

                return promocion.id_Promocion;
            }
        }
    }
    }