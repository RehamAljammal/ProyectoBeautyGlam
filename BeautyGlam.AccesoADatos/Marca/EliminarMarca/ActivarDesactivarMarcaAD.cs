using BeautyGlam.Abstracciones.AccesoADatos.Marca.ActivarDesactivar;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.Marcaes.ActivarDesactivar
{
    public class ActivarDesactivarMarcaAD : IActivarDesactivarMarcaAD
    {
        private readonly Contexto _contexto;

        public ActivarDesactivarMarcaAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> ActivarDesactivar(MarcaDto dto)
        {
            MarcaAD marca = _contexto.Marca
                .FirstOrDefault(x => x.id_Marca == dto.id_Marca);

            if (marca != null)
            {
                marca.estado = !marca.estado;
                return await _contexto.SaveChangesAsync();
            }

            return 0;
        }
    }
}