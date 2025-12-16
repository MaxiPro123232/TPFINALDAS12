using Microsoft.EntityFrameworkCore;
using TechStore.Entidades;

namespace TechStore.Modelo
{
    public class TechStoreDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TECHSTORE;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.Codigo).IsUnique();
                entity.HasOne(p => p.Categoria)
                      .WithMany(c => c.Productos)
                      .HasForeignKey(p => p.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Sucursal)
                      .WithMany(s => s.Productos)
                      .HasForeignKey(p => p.SucursalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.Codigo).IsUnique();
            });

            // Configuración de Venta
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasIndex(e => e.NumeroFactura).IsUnique();
                entity.HasOne(v => v.Cliente)
                      .WithMany(c => c.Ventas)
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(v => v.Vendedor)
                      .WithMany(v => v.Ventas)
                      .HasForeignKey(v => v.VendedorId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(v => v.Sucursal)
                      .WithMany(s => s.Ventas)
                      .HasForeignKey(v => v.SucursalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de DetalleVenta
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasOne(d => d.Venta)
                      .WithMany(v => v.DetalleVentas)
                      .HasForeignKey(d => d.VentaId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.Producto)
                      .WithMany(p => p.DetalleVentas)
                      .HasForeignKey(d => d.ProductoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Vendedor
            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasIndex(e => e.Codigo).IsUnique();
            });
        }
    }
}

