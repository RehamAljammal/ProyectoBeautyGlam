using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.EliminarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.GuiaRegalo.EliminarGuiaRegalo
{
    public class EliminarGuiaRegaloAD : IEliminarGuiaRegaloAD
    {
        private readonly Contexto _elContexto;

        public EliminarGuiaRegaloAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Eliminar(GuiaRegaloDto laGuiaParaEliminar)
        {
            int cantidadFilas = 0;

            GuiaRegaloAD guiaBD = _elContexto.GuiaRegalo
                .FirstOrDefault(g => g.idGuia == laGuiaParaEliminar.idGuia);

            if (guiaBD != null)
            {
                guiaBD.estado = false; // 👈 Inactivar
                cantidadFilas = await _elContexto.SaveChangesAsync();
            }

            return cantidadFilas;
        }
    }
}
