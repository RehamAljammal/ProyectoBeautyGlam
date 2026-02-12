using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.AccesoADatos.Promocion.ListaDePromocion
{
    public interface IObtenerListaDePromocionesAD
    {
        List<PromocionesDTO> Obtener();
    }
}
