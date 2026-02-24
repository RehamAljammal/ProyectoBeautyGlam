using BeautyGlam.Abstracciones.AccesoADatos.Promociones.Combo;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Promociones.Combo
{
    public class EliminarComboPromocionalAD : IEliminarComboPromocionalAD
    {
        public async Task<int> Eliminar(int idPromocion)
        {
            using (var contexto = new Contexto())
            {
                var promocion = await contexto.Promocion
                    .FirstOrDefaultAsync(p => p.id_Promocion == idPromocion);

                if (promocion == null)
                    return 0;

                // Eliminar relaciones primero
                var relaciones = contexto.PromocionProducto
                    .Where(x => x.id_Promocion == idPromocion)
                    .ToList();

                contexto.PromocionProducto.RemoveRange(relaciones);

                // Eliminar el combo (promoción)
                contexto.Promocion.Remove(promocion);

                return await contexto.SaveChangesAsync();
            }
        }
    }
}