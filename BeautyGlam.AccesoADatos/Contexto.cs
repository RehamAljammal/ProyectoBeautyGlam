using BeautyGlam.AccesoADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyGlam.AccesoADatos
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public DbSet<ProveedorAD> Proveedor { get; set; }
        public DbSet<CategoriaAD> Categoria { get; set; }
        public DbSet<MarcaAD> Marca { get; set; }
        public DbSet<ProductoAD> Producto { get; set; }
        public DbSet<InventarioAD> Inventario { get; set; }
        public DbSet<MovimientoInventarioAD> Movimiento { get; set; }
        public DbSet<PromocionesAD> Promocion { get; set; }





    }
}
