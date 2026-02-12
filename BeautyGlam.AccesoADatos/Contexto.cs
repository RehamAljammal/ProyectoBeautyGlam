using BeautyGlam.AccesoADatos.Entidades;
using System.Data.Entity;

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
        public DbSet<GuiaRegaloAD> GuiaRegalo { get; set; }
        public DbSet<GuiaProductoAD> GuiaProducto { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 🔑 Clave compuesta
            modelBuilder.Entity<GuiaProductoAD>()
                .HasKey(gp => new { gp.id_Guia, gp.id });

            // 🔗 Relación con GuiaRegalo
            modelBuilder.Entity<GuiaProductoAD>()
                .HasRequired(gp => gp.GuiaRegalo)
                .WithMany(g => g.GuiaProducto)
                .HasForeignKey(gp => gp.id_Guia)
                .WillCascadeOnDelete(false);

            // 🔗 Relación con Producto
            modelBuilder.Entity<GuiaProductoAD>()
                .HasRequired(gp => gp.Producto)
                .WithMany(p => p.GuiaProducto)
                .HasForeignKey(gp => gp.id)
                .WillCascadeOnDelete(false);
        }



    }
}
