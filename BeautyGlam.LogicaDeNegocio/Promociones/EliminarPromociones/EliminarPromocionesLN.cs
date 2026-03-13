using BeautyGlam.Abstracciones.LogicaDeNegocio.Promociones.EliminarPromociones;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.Abstracciones.AccesoADatos.Promocion.DesactivarPromocion;
using BeautyGlam.AccesoADatos.Promociones.EliminarPromociones;
using System.Threading.Tasks;


    namespace BeautyGlam.LogicaDeNegocio.Promociones.EliminarPromociones
    {
        public class EliminarPromocionesLN : IEliminarPromocionesLN
        {
            private readonly IEliminarPromocionesAD _eliminarPromocionesAD;

            public EliminarPromocionesLN()
            {
                _eliminarPromocionesAD = new EliminarPromocionesAD();
            }

            public async Task<int> ActivarDesactivarPromocion(PromocionesDTO laPromocionParaGuardar)
            {
                return await _eliminarPromocionesAD.ActivarDesactivarPromocion(laPromocionParaGuardar);
            }
        }
    }

