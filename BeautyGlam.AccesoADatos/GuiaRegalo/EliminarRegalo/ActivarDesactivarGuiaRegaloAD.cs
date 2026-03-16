using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.ActivarDesactivarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.GuiaRegalo.ActivarDesactivarGuiaRegalo
{
    public class ActivarDesactivarGuiaRegaloAD : IActivarDesactivarGuiaRegaloAD
    {
        private readonly Contexto _contexto;

        public ActivarDesactivarGuiaRegaloAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> ActivarDesactivar(GuiaRegaloDto dto)
        {
            int filas = 0;

            GuiaRegaloAD guiaBD = _contexto.GuiaRegalo
                .FirstOrDefault(g => g.idGuia == dto.idGuia);

            if (guiaBD != null)
            {
                guiaBD.estado = !guiaBD.estado;
                filas = await _contexto.SaveChangesAsync();
            }

            return filas;
        }
    }
}