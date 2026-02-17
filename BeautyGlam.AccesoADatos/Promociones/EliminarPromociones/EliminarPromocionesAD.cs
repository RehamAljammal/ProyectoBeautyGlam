using BeautyGlam.Abstracciones.AccesoADatos.Promocion.DesactivarPromocion;
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EliminarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Promociones.EliminarPromociones
{
    public class EliminarPromocionesAD : IEliminarPromocionesAD
    {
        private Contexto _elContexto;

        public EliminarPromocionesAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(PromocionesDTO laPromocionParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            int idPromocion = laPromocionParaGuardar.id_Promocion;

            PromocionesAD laPromocionEnBaseDeDatos =
                await _elContexto.Promocion
                    .FirstOrDefaultAsync(p => p.id_Promocion == idPromocion);

            if (laPromocionEnBaseDeDatos != null)
            {
                laPromocionEnBaseDeDatos.estado = false;
                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

    }

}


