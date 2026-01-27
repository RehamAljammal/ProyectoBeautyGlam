using BeautyGlam.Abstracciones.AccesoADatos.Marca.EditarMarca;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;
using System.Threading.Tasks;


namespace BeautyGlam.AccesoADatos.Marca.EditarMarca
{
    public class EditarMarcaAD : IEditarMarcaAD
    {
        private Contexto _elContexto;


        public EditarMarcaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(MarcaDto laMarcaParaGuardar)
        {
            int cantidadDeFilasAfectadas = 0;

            MarcaAD laMarcaEnBaseDeDatos = await _elContexto.Marca
                .FirstOrDefaultAsync(p => p.id_Marca == laMarcaParaGuardar.id_Marca);

            if (laMarcaEnBaseDeDatos != null)
            {
                laMarcaEnBaseDeDatos.nombre = laMarcaParaGuardar.nombre;
                laMarcaEnBaseDeDatos.estado = laMarcaParaGuardar.estado;

                cantidadDeFilasAfectadas = await _elContexto.SaveChangesAsync();
            }

            return cantidadDeFilasAfectadas;
        }

        public async Task<MarcaDto> ObtenerPorId(int id)
        {
            MarcaAD entidad = await _elContexto.Marca.FindAsync(id);

            if (entidad == null)
                return null;

            return new MarcaDto
            {
                id_Marca = entidad.id_Marca,
                nombre = entidad.nombre,
                estado = entidad.estado
            };
        }
    }
}

