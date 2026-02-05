using BeautyGlam.Abstracciones.ModelosParaUI;
using System.Collections.Generic;
using System.Linq;

namespace BeautyGlam.AccesoADatos.Catalogo
{
    public class ObtenerCatalogoAD
    {
        private readonly Contexto _elContexto;

        public ObtenerCatalogoAD()
        {
            _elContexto = new Contexto();
        }

        public List<ProductosDTO> Obtener(string q, int? idCategoria, int? idMarca, decimal? min, decimal? max)
        {
            string texto = (q ?? "").Trim();

            IQueryable<ProductosDTO> consulta =
                from p in _elContexto.Producto
                join c in _elContexto.Categoria on p.idCategoria equals c.id
                join m in _elContexto.Marca on p.idMarca equals m.id_Marca
                where p.estado == true
                select new ProductosDTO
                {
                    id = p.id,
                    nombre = p.nombre,
                    descripcion = p.descripcion,
                    precio = p.precio,
                    imagen = p.imagen,

                    idCategoria = p.idCategoria,
                    nombreCategoria = c.nombre,

                    idMarca = p.idMarca,
                    nombreMarca = m.nombre,

                    idProveedor = p.idProveedor,
                    estado = p.estado
                };

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(x =>
                    x.nombre.Contains(texto) ||
                    x.nombreCategoria.Contains(texto) ||
                    x.nombreMarca.Contains(texto)
                );
            }

            if (idCategoria.HasValue && idCategoria.Value > 0)
            {
                int categoriaId = idCategoria.Value;
                consulta = consulta.Where(x => x.idCategoria == categoriaId);
            }

            if (idMarca.HasValue && idMarca.Value > 0)
            {
                int marcaId = idMarca.Value;
                consulta = consulta.Where(x => x.idMarca == marcaId);
            }

            if (min.HasValue)
            {
                decimal minimo = min.Value;
                consulta = consulta.Where(x => x.precio >= minimo);
            }

            if (max.HasValue)
            {
                decimal maximo = max.Value;
                consulta = consulta.Where(x => x.precio <= maximo);
            }

            List<ProductosDTO> resultado = consulta
                .OrderBy(x => x.nombre)
                .ToList();

            return resultado;
        }
    }
}
