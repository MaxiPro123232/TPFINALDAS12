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

        private string conexion = "Data Source=MAXOPC\\SQLEXPRESS;Initial Catalog=TECHSTORE;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índices únicos (requeridos - no se pueden definir solo con Data Annotations)
            modelBuilder.Entity<Producto>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Vendedor>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            modelBuilder.Entity<Venta>()
                .HasIndex(e => e.NumeroFactura)
                .IsUnique();

            // Comportamiento de eliminación para integridad referencial
            // (Las relaciones ya están definidas con [ForeignKey] en las entidades)
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.DetalleVentas)
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina una venta, se eliminan sus detalles
        }
    }
}

