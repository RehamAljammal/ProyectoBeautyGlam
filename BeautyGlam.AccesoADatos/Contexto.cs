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
        public DbSet<BlogAD> Blog { get; set; }
        public DbSet<ComentarioBlogAD> ComentarioBlog { get; set; }

        // ===============================
        // WISHLIST
        // ===============================
        //  public DbSet<WishlistAD> Wishlist { get; set; }
        // public DbSet<WishlistProductoAD> WishlistProducto { get; set; }

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

            modelBuilder.Entity<PromocionProductoAD>()
                .HasRequired(pp => pp.Promocion)
                .WithMany(p => p.PromocionProducto)
                .HasForeignKey(pp => pp.id_Promocion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PromocionProductoAD>()
                .HasRequired(pp => pp.Producto)
                .WithMany(p => p.PromocionProducto)
                .HasForeignKey(pp => pp.id)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ComentarioBlogAD>()
                .HasRequired(c => c.Blog)
                .WithMany(b => b.Comentarios)
                .HasForeignKey(c => c.id_Blog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComentarioBlogAD>()
                .HasRequired(c => c.Usuario)
                .WithMany(u => u.comentarios)
                .HasForeignKey(c => c.id_Usuario)
                .WillCascadeOnDelete(false);

            // ===============================
            // WISHLIST
            // ===============================

            //  modelBuilder.Entity<WishlistAD>()
            //    .ToTable("Wishlist")
            //    .HasKey(w => w.id_Wishlist);

            // modelBuilder.Entity<WishlistAD>()
            //     .HasRequired(w => w.Usuario)
            //// .WithMany(u => u.Wishlist)
            // .HasForeignKey(w => w.id_Usuario)
            // .WillCascadeOnDelete(false);

            // ===============================
            // WISHLIST - PRODUCTO
            // ===============================

            //* modelBuilder.Entity<WishlistProductoAD>()
            //     .ToTable("Wishlist_Producto");

            // modelBuilder.Entity<WishlistProductoAD>()
            //   .HasKey(wp => new { wp.id_Wishlist, wp.id });

            //modelBuilder.Entity<WishlistProductoAD>()
            //   .HasRequired(wp => wp.Wishlist)
            //  .WithMany(w => w.WishlistProducto)
            //  .HasForeignKey(wp => wp.id_Wishlist)
            // .WillCascadeOnDelete(false);

            // modelBuilder.Entity<WishlistProductoAD>()
            //     .HasRequired(wp => wp.Producto)
            ///    .WithMany(p => p.WishlistProducto)
            //    .HasForeignKey(wp => wp.id)
            //    .WillCascadeOnDelete(false);

            // base.OnModelCreating(modelBuilder);
        }
    }
}