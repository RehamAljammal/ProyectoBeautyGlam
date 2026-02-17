
using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EditarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Promociones.EditarPromociones
{
    public class EditarPromocionesAD : IEditarpromocionesLN
    {
        private Contexto _elContexto;

        public EditarPromocionesAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(PromocionesDTO laPromocionParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            PromocionesAD laPromocionEnBaseDeDatos =
                await _elContexto.Promocion
                .FirstOrDefaultAsync(p => p.id_Promocion == laPromocionParaGuardar.id_Promocion);

            if (laPromocionEnBaseDeDatos != null)
            {
                laPromocionEnBaseDeDatos.titulo = laPromocionParaGuardar.titulo;
                laPromocionEnBaseDeDatos.descripcion = laPromocionParaGuardar.descripcion;
                laPromocionEnBaseDeDatos.fecha_Inicio = laPromocionParaGuardar.fecha_Inicio;
                laPromocionEnBaseDeDatos.fecha_Fin = laPromocionParaGuardar.fecha_Fin;
                laPromocionEnBaseDeDatos.estado = laPromocionParaGuardar.estado;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        public async Task<PromocionesDTO> ObtenerPorId(int id)
        {
            PromocionesAD entidad = await _elContexto.Promocion.FindAsync(id);

            if (entidad == null)
                return null;

            return new PromocionesDTO
            {
                id_Promocion = entidad.id_Promocion,
                titulo = entidad.titulo,
                descripcion = entidad.descripcion,
                fecha_Inicio = entidad.fecha_Inicio,
                fecha_Fin = entidad.fecha_Fin,
                estado = entidad.estado
            };
        }
    }
}
