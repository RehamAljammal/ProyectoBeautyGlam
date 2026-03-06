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

        public DbSet<UsuarioAD> Usuario { get; set; }

        public DbSet<ProveedorAD> Proveedor { get; set; }
        public DbSet<CategoriaAD> Categoria { get; set; }
        public DbSet<MarcaAD> Marca { get; set; }
        public DbSet<ProductoAD> Producto { get; set; }
        public DbSet<InventarioAD> Inventario { get; set; }
        public DbSet<MovimientoInventarioAD> Movimiento { get; set; }

        public DbSet<GuiaRegaloAD> GuiaRegalo { get; set; }
        public DbSet<GuiaProductoAD> GuiaProducto { get; set; }

        public DbSet<PromocionesAD> Promocion { get; set; }
        public DbSet<PromocionProductoAD> PromocionProducto { get; set; }

        public DbSet<PasswordResetAD> PasswordReset { get; set; }

        public DbSet<RolAD> Rol { get; set; }

        public DbSet<VentaAD> Venta { get; set; }
        public DbSet<DetalleVentaAD> Detalle_Venta { get; set; }
        public DbSet<PagoAD> Pago { get; set; }
        public DbSet<FacturaAD> Factura { get; set; }

        public DbSet<DevolucionAD> Devolucion { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ===============================
            // GUIA – PRODUCTO
            // ===============================

            modelBuilder.Entity<GuiaProductoAD>()
                .HasKey(gp => new { gp.id_Guia, gp.id });

            modelBuilder.Entity<GuiaProductoAD>()
                .HasRequired(gp => gp.GuiaRegalo)
                .WithMany(g => g.GuiaProducto)
                .HasForeignKey(gp => gp.id_Guia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GuiaProductoAD>()
                .HasRequired(gp => gp.Producto)
                .WithMany(p => p.GuiaProducto)
                .HasForeignKey(gp => gp.id)
                .WillCascadeOnDelete(false);

            // ===============================
            // PROMOCION – PRODUCTO
            // ===============================

            modelBuilder.Entity<PromocionProductoAD>()
                .ToTable("PROMOCION_PRODUCTO");

            modelBuilder.Entity<PromocionProductoAD>()
                .HasKey(pp => new { pp.id_Promocion, pp.id });

            // FK a PROMOCION
            modelBuilder.Entity<PromocionProductoAD>()
                .HasRequired(pp => pp.Promocion)
                .WithMany(p => p.PromocionProducto)
                .HasForeignKey(pp => pp.id_Promocion)
                .WillCascadeOnDelete(false);

            // FK a PRODUCTO
            modelBuilder.Entity<PromocionProductoAD>()
                .HasRequired(pp => pp.Producto)
                .WithMany(p => p.PromocionProducto)
                .HasForeignKey(pp => pp.id)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}