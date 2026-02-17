using BeautyGlam.Abstracciones.AccesoADatos.GuiaRegalo.RegistrarGuiaRegalo;
using BeautyGlam.Abstracciones.ModelosParaUI;
using BeautyGlam.AccesoADatos.Entidades;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos.GuiaRegalo.RegistrarGuiaRegalo
{
    public class RegistrarGuiaRegaloAD : IRegistrarGuiaRegaloAD
    {
        private Contexto _elContexto;

        public RegistrarGuiaRegaloAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(GuiaRegaloDto dto)
        {
            int filasAfectadas = 0;

            GuiaRegaloAD guia = ConvierteAEntidad(dto);
            _elContexto.GuiaRegalo.Add(guia);

            await _elContexto.SaveChangesAsync();

            foreach (int idProducto in dto.productosSeleccionados)
            {
                GuiaProductoAD relacion = new GuiaProductoAD
                {
                    id_Guia = guia.idGuia,
                    id = idProducto
                };

                _elContexto.GuiaProducto.Add(relacion);
            }

            filasAfectadas = await _elContexto.SaveChangesAsync();
            return filasAfectadas;
        }

        private GuiaRegaloAD ConvierteAEntidad(GuiaRegaloDto dto)
        {
            return new GuiaRegaloAD
            {
                categoria = dto.categoria,
                presupuesto = dto.presupuesto,
                genero = dto.genero,
                tipo = dto.tipo,
                estado = true  
            };
        }
    }
}

